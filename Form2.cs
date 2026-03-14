using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mediaplayerapp
{
    public partial class Form2 : Form
    {
        List<string> file1 = new List<string>();
        List<string> file2 = new List<string>();
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\"; // opens at C drive by default
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.webm;*.mkv|All Files|*.*"; // filter dropdown: user can choose to see only video files or all files

                if (openFileDialog.ShowDialog() == DialogResult.OK)// display selected file path in label
                {
                    label3.Text = openFileDialog.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.webm;*.mkv|All Files|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    label4.Text = openFileDialog.FileName;
                }
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
