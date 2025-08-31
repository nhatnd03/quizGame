using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace quizGame.Views
{
    
    public partial class FormIntro : Form
    {
        public FormIntro()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void FormIntro_Load(object sender, EventArgs e)
        {
            try
            {
                axWindowsMediaPlayer1.uiMode = "none";
                axWindowsMediaPlayer1.URL = "intro.mp4";
                axWindowsMediaPlayer1.settings.autoStart = true;
                axWindowsMediaPlayer1.Enabled = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Không tìm thấy file âm thanh", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Kiểm tra nếu video đã kết thúc
            if (e.newState == (int)WMPPlayState.wmppsMediaEnded)
            {
                // Sau khi video kết thúc, chuyển sang FormLevel
                FormLevel formLevel = new FormLevel();
                formLevel.Show();
                this.Hide();
                this.Dispose();// Ẩn FormIntro
            }
        }

        private async void FormIntro_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsPlaying)
            {
                // Stop the video before closing
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }

            // Add a small delay before closing
            await Task.Delay(500); // Delay for 500ms (adjust if necessary)

            Form2 form2 = new Form2();
            this.Close();
            form2.Show();
        }
    }
}
