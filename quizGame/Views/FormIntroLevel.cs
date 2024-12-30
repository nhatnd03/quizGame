using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using WMPLib;

namespace quizGame.Views
{
    public partial class FormIntroLevel : Form
    {
        private string videoPath;

        public FormIntroLevel()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            axWindowsMediaPlayer1.Dock = DockStyle.Fill;
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.Enabled = false;
        }

        public void SetVideoPath(string videoPath)
        {
            try
            {
                axWindowsMediaPlayer1.URL = videoPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải video: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AxWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == (int)WMPLib.WMPPlayState.wmppsPlaying)
            {
                // Video has started playing, wait for video to end
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 0;
                axWindowsMediaPlayer1.URL = videoPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
            else if (e.newState == (int)WMPLib.WMPPlayState.wmppsStopped)
            {
                this.Close();
            }
        }

        private async void FormIntroLevel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsPlaying)
            {
                // Stop the video before closing
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }

            // Add a small delay before closing
            await Task.Delay(500); // Delay for 500ms (adjust if necessary)

            FormLevel form2 = new FormLevel();
            this.Close();
            form2.Show();
        }
    }
}
