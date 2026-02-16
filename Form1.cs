using System.IO;

namespace mediaplayerapp
{
    public partial class Form1 : Form
    {
        List<string> filteredFiles = new List<string>();
        FolderBrowserDialog browser = new FolderBrowserDialog();
        int currentFile = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFolderEvent(object sender, EventArgs e)
        {
            VideoPlayer.Ctlcontrols.stop();

            if (filteredFiles.Count > 0)
            {
                filteredFiles.Clear();
                filteredFiles = null;
                PlayList.Items.Clear();
                currentFile = 0;
            }
            DialogResult result = browser.ShowDialog();
            if (result == DialogResult.OK)
            {
                filteredFiles = Directory.GetFiles(browser.SelectedPath, "*")
                    .Where(file => file.ToLower().EndsWith("webm") || file.ToLower().EndsWith("mp4")
                    || file.ToLower().EndsWith("mkv") || file.ToLower().EndsWith("avi")).ToList();
                LoadPlayList();
            }
        }

        private void ShowAboutEvent(object sender, EventArgs e)
        {
            MessageBox.Show("This app is made by Shreyas K" + Environment.NewLine + "This is a simple Media Player" + Environment.NewLine
                + "I'm planning to expand this app to load music, merge videos etc" + Environment.NewLine
                + "For now, Click on Open Folder Button to load the video folder to the app and it will start auto playing for you","Hello There!!!");
        }

        private void MediaPlayerStateChangeEvent(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 0)
            {
                lblDuration.Text = "Media Player is Ready to be loaded";
            }
            else if (e.newState == 1)
            {
                lblDuration.Text = "Media Player is stopped";

            }
            else if (e.newState == 3)
            {
                lblDuration.Text = "Duration" + VideoPlayer.currentMedia.durationString;
            }
            else if (e.newState == 8)
            {
                if (currentFile >= filteredFiles.Count - 1)
                {
                    currentFile = 0;
                }
                else
                {
                    currentFile++;
                }
                PlayList.SelectedIndex = currentFile;
                ShowFileName(lblFileName);
            }
            else if (e.newState == 9)
            {
                lblDuration.Text = "Loading new Video";
            }
            else if(e.newState == 10)
            {
                timer1.Start();
            }
        }

        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        private void PlayListChanged(object sender, EventArgs e)
        {
            currentFile = PlayList.SelectedIndex;
            PlayFile(PlayList.SelectedItem.ToString());
            ShowFileName(lblFileName);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TimerEvent(object sender, EventArgs e)
        {
            VideoPlayer.Ctlcontrols.play();
            timer1.Stop();
        }

        private void LoadPlayList()
        {
            VideoPlayer.currentPlaylist = VideoPlayer.newPlaylist("PlayList", "");

            foreach(string videos in filteredFiles)
            {
                VideoPlayer.currentPlaylist.appendItem(VideoPlayer.newMedia(videos));
                PlayList.Items.Add(videos);
            }
            if (filteredFiles.Count > 0)
            {
                lblFileName.Text = "Files Found" + filteredFiles.Count;

                PlayList.SelectedIndex = currentFile;

                PlayFile(PlayList.SelectedItem.ToString());

            }
            else
            {
                MessageBox.Show("No Video files found in this folder");
            }
        }

        private void PlayFile(string url)
        {
            VideoPlayer.URL = url;
        }

        private void ShowFileName(Label name)
        {
            string file = Path.GetFileName(PlayList.SelectedItem.ToString());
            name.Text = "Currently Playing " + file;
        }
    }
}
