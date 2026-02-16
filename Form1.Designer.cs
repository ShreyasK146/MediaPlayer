namespace mediaplayerapp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            filToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            VideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            PlayList = new ListBox();
            lblFileName = new Label();
            lblDuration = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VideoPlayer).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { filToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1366, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // filToolStripMenuItem
            // 
            filToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, aboutToolStripMenuItem });
            filToolStripMenuItem.Name = "filToolStripMenuItem";
            filToolStripMenuItem.Size = new Size(37, 20);
            filToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(180, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += LoadFolderEvent;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(180, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += ShowAboutEvent;
            // 
            // VideoPlayer
            // 
            VideoPlayer.Enabled = true;
            VideoPlayer.Location = new Point(0, 27);
            VideoPlayer.Name = "VideoPlayer";
            VideoPlayer.OcxState = (AxHost.State)resources.GetObject("VideoPlayer.OcxState");
            VideoPlayer.Size = new Size(1024, 709);
            VideoPlayer.TabIndex = 1;
            VideoPlayer.PlayStateChange += MediaPlayerStateChangeEvent;
            // 
            // PlayList
            // 
            PlayList.FormattingEnabled = true;
            PlayList.ItemHeight = 15;
            PlayList.Location = new Point(1030, 27);
            PlayList.Name = "PlayList";
            PlayList.RightToLeft = RightToLeft.Yes;
            PlayList.Size = new Size(324, 709);
            PlayList.TabIndex = 2;
            PlayList.SelectedIndexChanged += PlayListChanged;
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(0, 746);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(57, 15);
            lblFileName.TabIndex = 3;
            lblFileName.Text = "FileName";
            // 
            // lblDuration
            // 
            lblDuration.AutoSize = true;
            lblDuration.Location = new Point(1030, 746);
            lblDuration.Name = "lblDuration";
            lblDuration.Size = new Size(65, 15);
            lblDuration.TabIndex = 4;
            lblDuration.Text = "Duration: 0";
            lblDuration.Click += label1_Click;
            // 
            // timer1
            // 
            timer1.Tick += TimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1366, 768);
            Controls.Add(lblDuration);
            Controls.Add(lblFileName);
            Controls.Add(PlayList);
            Controls.Add(VideoPlayer);
            Controls.Add(menuStrip1);
            ForeColor = Color.Snow;
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Media Player";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VideoPlayer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem filToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer VideoPlayer;
        private ListBox PlayList;
        private Label lblFileName;
        private Label lblDuration;
        private System.Windows.Forms.Timer timer1;
    }
}
