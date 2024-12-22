using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quizGame
{
    public partial class Form2 : Form
    {
        private System.Media.SoundPlayer backgroundMusicPlayer;
        private FormLevel FormLevel = new FormLevel();
        private StartForm _startForm;

        public Form2()
        {
            InitializeComponent();
            _startForm = new StartForm(this);
            this.StartPosition = FormStartPosition.CenterScreen;

            string musicPath = "cool-hip-hop-loop-251857.wav";
            try
            {
                backgroundMusicPlayer = new System.Media.SoundPlayer(musicPath);
                backgroundMusicPlayer.Load();
                backgroundMusicPlayer.PlayLooping(); // Phát nhạc lặp lại
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("File nhạc nền không tìm thấy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phát nhạc nền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLevel.Show();
        }

        private void btnCreateQues_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (_startForm != null && !_startForm.IsDisposed)
            {
                _startForm.Show();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (backgroundMusicPlayer != null)
            {
                backgroundMusicPlayer.Stop();
                backgroundMusicPlayer.Dispose();
            }
            if (FormLevel != null && !FormLevel.IsDisposed) { FormLevel.Close(); }
            if (_startForm != null && !_startForm.IsDisposed) { _startForm.Close(); }
            Application.Exit();
        }
    }
}
