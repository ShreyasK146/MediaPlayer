using System.IO;

namespace mediaplayerapp
{
    public partial class Form1 : Form
    {


       

        List<string> filteredFiles = new List<string>();
        FolderBrowserDialog browser = new FolderBrowserDialog();
        int currentFile = 0;// tracks which file is currently playing (index)
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadFolderEvent(object sender, EventArgs e)
        {
            VideoPlayer.Ctlcontrols.stop();
            
            if (filteredFiles.Count > 0)
            {
                // clean up previous session before loading new folder
                filteredFiles.Clear();
                filteredFiles = null;
                PlayList.Items.Clear();
                currentFile = 0;
            }
            DialogResult result = browser.ShowDialog(); // opens folder picker popup
            if (result == DialogResult.OK)
            {
                //// get ALL files, then keep only media files by checking their extensions
                filteredFiles = Directory.GetFiles(browser.SelectedPath, "*")
                    .Where(file => file.ToLower().EndsWith("webm") || file.ToLower().EndsWith("mp4") || file.ToLower().EndsWith("mp3")
                    || file.ToLower().EndsWith("mkv") || file.ToLower().EndsWith("avi")).ToList();
                LoadPlayList();
            }
        }

        private void ShowAboutEvent(object sender, EventArgs e)
        {
            MessageBox.Show("This app is made by Shreyas K" + Environment.NewLine + "This is a simple Media Player" + Environment.NewLine
                + "I'm planning to expand this app to load music, merge videos etc" + Environment.NewLine
                + "For now, Click on Open Folder Button to load the video folder to the app and it will start auto playing for you", "Hello There!!!");
        }

        private void MediaPlayerStateChangeEvent(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Windows media player(WMP) fires this event with a state number whenever playback state changes
            if (e.newState == 0)// Ready
            {
                lblDuration.Text = "Media Player is Ready to be loaded";
            }
            else if (e.newState == 1)// Stopped
            {
                lblDuration.Text = "Media Player is stopped";

            }
            else if (e.newState == 3)// Playing safe to read media info now
            {
                lblDuration.Text = "Duration " + VideoPlayer.currentMedia.durationString;
            }
            else if (e.newState == 8)  // Media ended auto advance to next file
            {
                if (currentFile >= filteredFiles.Count - 1)
                {
                    currentFile = 0; // loop back to start if at last file
                }
                else
                {
                    currentFile++;
                }
                PlayList.SelectedIndex = currentFile; // this triggers PlayListChanged
                ShowFileName(lblFileName);
            }
            else if (e.newState == 9) // Transitioning
            {
                lblDuration.Text = "Loading new Video";
            }
            else if (e.newState == 10)// Ready to play but needs a nudge — start timer
            {
                timer1.Start();
            }
        }

        //private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        //When auto advancing to next video or 
        // When user manually clicks a file in the playlist listbox  event fires and belwo executes
        //
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
            // timer is used as a small delay before calling play()
            // directly calling play() on state==10 sometimes fails, timer avoids that race condition
            VideoPlayer.Ctlcontrols.play();
            timer1.Stop();
        }

        private void LoadPlayList()
        {
            VideoPlayer.currentPlaylist = VideoPlayer.newPlaylist("PlayList", "");

            foreach (string videos in filteredFiles)
            {
                VideoPlayer.currentPlaylist.appendItem(VideoPlayer.newMedia(videos));// add to WMP's internal playlist
                PlayList.Items.Add(videos);// add to the visible listbox on screen
            }
            if (filteredFiles.Count > 0)
            {
                lblFileName.Text = "Files Found" + filteredFiles.Count;

                PlayList.SelectedIndex = currentFile;

                PlayFile(PlayList.SelectedItem.ToString());// start playing first file

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

        // is to show which file is currently playing
        private void ShowFileName(Label name)
        {
            string file = Path.GetFileName(PlayList.SelectedItem.ToString());
            name.Text = "Currently Playing " + file;
        }

        private void filToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // open up new form when you click on merge video option
        private void OnMergeVideoAudioClick(object sender, EventArgs e)
        {
            Form2 mergeWindow = new Form2();
            mergeWindow.Show();
            //DialogResult result = browser.ShowDialog();
            //if(result == DialogResult.GetName())
            //{
            //    Console.WriteLine("selected item is correct");
            //}
        }   
    }
}
