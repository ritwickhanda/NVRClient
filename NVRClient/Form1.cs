using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Linq;

// VLC
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace NVRClient
{
    public partial class Form1 : Form
    {
        private readonly string logFile =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "nvr_client.log");

        // VLC
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        private VideoView _videoView;

        public Form1()
        {
            InitializeComponent();
            ApplyStyle();
            InitVLC();

            // Force attach buttons (designer safe)
            btnPlayLive.Click += btnPlayLive_Click;
            btnPlayback.Click += btnPlayback_Click;

            Log("Application started");
        }

        // ===============================
        // UI STYLE
        // ===============================
        private void ApplyStyle()
        {
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.Font = new Font("Segoe UI", 9F);

            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Height = 28;
                    btn.ForeColor = Color.White;
                    btn.BackColor = Color.FromArgb(52, 152, 219);
                }
            }

            btnDisconnect.BackColor = Color.FromArgb(231, 76, 60);
            btnExport.BackColor = Color.FromArgb(46, 204, 113);
            btnStartListener.BackColor = Color.FromArgb(155, 89, 182);
            btnStopListener.BackColor = Color.FromArgb(127, 140, 141);

            if (grpPTZ != null)
            {
                grpPTZ.ForeColor = Color.FromArgb(60, 60, 60);
                foreach (Control c in grpPTZ.Controls)
                {
                    if (c is Button btn)
                    {
                        btn.BackColor = Color.FromArgb(52, 73, 94);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    }
                }
            }

            videoPanel.BackColor = Color.Black;
        }

        // ===============================
        // VLC INIT (32-bit)
        // ===============================
        private void InitVLC()
        {
            string vlcPath = @"C:\Program Files (x86)\VideoLAN\VLC";

            if (!Directory.Exists(vlcPath))
                throw new Exception("32-bit VLC not found at: " + vlcPath);

            Core.Initialize(vlcPath);

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            _videoView = new VideoView
            {
                MediaPlayer = _mediaPlayer,
                Dock = DockStyle.Fill
            };

            videoPanel.Controls.Clear();
            videoPanel.Controls.Add(_videoView);
        }

        // ===============================
        // DESIGNER REQUIRED
        // ===============================
        private void lblBaseUrl_Click(object sender, EventArgs e) { }
        private void btnConnect_Click(object sender, EventArgs e) { }

        // ===============================
        // CONNECT → FETCH CHANNELS
        // ===============================
        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            try
            {
                LoadNvrChannels();
                MessageBox.Show("Connected & channels loaded");
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        // ===============================
        // BASE URI
        // ===============================
        private Uri GetSafeBaseUri()
        {
            string baseUrl = txtBaseUrl.Text.Trim();

            if (!baseUrl.StartsWith("http://") && !baseUrl.StartsWith("https://"))
                baseUrl = "http://" + baseUrl;

            if (!baseUrl.EndsWith("/"))
                baseUrl += "/";

            return new Uri(baseUrl);
        }

        // ===============================
        // FETCH CHANNELS
        // ===============================
        private void LoadNvrChannels()
        {
            cmbCameraId.Items.Clear();

            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(
                    txtUsername.Text.Trim(),
                    txtPassword.Text
                ),
                PreAuthenticate = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = GetSafeBaseUri();

                var response = client
                    .GetAsync("pramaAPI/ContentMgmt/InputProxy/channels/status")
                    .Result;

                response.EnsureSuccessStatusCode();

                string xml = Encoding.UTF8.GetString(
                    response.Content.ReadAsByteArrayAsync().Result
                );

                XDocument doc = XDocument.Parse(xml);

                var channels = doc.Descendants()
                    .Where(x => x.Name.LocalName == "InputProxyChannelStatus");

                foreach (var ch in channels)
                {
                    string id = ch.Elements()
                        .FirstOrDefault(e => e.Name.LocalName == "id")?.Value;

                    string online = ch.Elements()
                        .FirstOrDefault(e => e.Name.LocalName == "online")?.Value;

                    if (!string.IsNullOrEmpty(id))
                        cmbCameraId.Items.Add(id + " | Online: " + online);
                }
            }
        }

        // ===============================
        // ▶ LIVE VIEW
        // ===============================
        private void btnPlayLive_Click(object sender, EventArgs e)
        {
            if (cmbCameraId.SelectedItem == null)
            {
                MessageBox.Show("Select camera first");
                return;
            }

            int channel = int.Parse(
                cmbCameraId.SelectedItem.ToString().Split('|')[0].Trim()
            );

            int rtspChannel = (channel * 100) + 1;

            string ip = txtBaseUrl.Text
                .Replace("http://", "")
                .Replace("https://", "");

            string rtsp =
                $"rtsp://{txtUsername.Text}:{txtPassword.Text}@{ip}:554/Streaming/Channels/{rtspChannel}";

            Log("LIVE RTSP: " + rtsp);

            using (var media = new Media(_libVLC, rtsp, FromType.FromLocation))
                _mediaPlayer.Play(media);
        }

        // ===============================
        // ▶ PLAYBACK BUTTON
        // ===============================
        private void btnPlayback_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCameraId.SelectedItem == null)
                    throw new Exception("Select camera first");

                int channel = int.Parse(
                    cmbCameraId.SelectedItem.ToString().Split('|')[0].Trim()
                );

                var (start, end) = GetFromToTime();

                if (end <= start)
                    throw new Exception("End time must be after start time");

                SearchPlayback(channel, start, end);
            }
            catch (Exception ex)
            {
                Log(ex.ToString());
                MessageBox.Show(ex.Message);
            }
        }

        // ===============================
        // GET FROM / TO DATETIME (NAME SAFE)
        // ===============================
        private (DateTime from, DateTime to) GetFromToTime()
        {
            var pickers = this.Controls
                .OfType<DateTimePicker>()
                .OrderBy(p => p.TabIndex)
                .ToList();

            if (pickers.Count < 2)
                throw new Exception("From / To DateTimePickers not found");

            return (pickers[0].Value, pickers[1].Value);
        }

        // ===============================
        // PLAYBACK SEARCH API
        // ===============================
        private void SearchPlayback(int channel, DateTime start, DateTime end)
        {
            int trackId = (channel * 100) + 1;

            string xml = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<CMSearchDescription>
  <searchID>{Guid.NewGuid()}</searchID>
  <trackList>
    <trackID>{trackId}</trackID>
  </trackList>
  <timeSpanList>
    <timeSpan>
      <startTime>{start.ToUniversalTime():yyyy-MM-ddTHH:mm:ssZ}</startTime>
      <endTime>{end.ToUniversalTime():yyyy-MM-ddTHH:mm:ssZ}</endTime>
    </timeSpan>
  </timeSpanList>
  <maxResults>100</maxResults>
  <searchResultPostion>0</searchResultPostion>
</CMSearchDescription>";

            Log("Playback Search XML:\n" + xml);

            var handler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(
                    txtUsername.Text.Trim(),
                    txtPassword.Text
                ),
                PreAuthenticate = true
            };

            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = GetSafeBaseUri();
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");
                client.PostAsync("pramaAPI/ContentMgmt/search", content).Wait();
            }

            PlayPlayback(trackId, start, end);
        }

        // ===============================
        // ▶ PLAYBACK RTSP
        // ===============================
        private void PlayPlayback(int trackId, DateTime start, DateTime end)
        {
            string ip = txtBaseUrl.Text
                .Replace("http://", "")
                .Replace("https://", "");

            string s = start.ToUniversalTime().ToString("yyyyMMddTHHmmssZ");
            string e = end.ToUniversalTime().ToString("yyyyMMddTHHmmssZ");

            string rtsp =
                $"rtsp://{txtUsername.Text}:{txtPassword.Text}@{ip}:554/Streaming/tracks/{trackId}" +
                $"?starttime={s}&endtime={e}";

            Log("PLAYBACK RTSP: " + rtsp);

            using (var media = new Media(_libVLC, rtsp, FromType.FromLocation))
                _mediaPlayer.Play(media);
        }

        // ===============================
        // LOGGING
        // ===============================
        private void Log(string msg)
        {
            File.AppendAllText(
                logFile,
                $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {msg}\r\n"
            );
        }
    }
}
