using quizGame.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quizGame
{
    public partial class FormLevel : Form
    {
        private Form1 form1;
        private FormIntroLevel formIntroLevel;

        public FormLevel() 
        {
            InitializeComponent();
            formIntroLevel = new FormIntroLevel();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void btnlevel_Click(object sender, EventArgs e)
        {
            StartQuiz(0,"khoidong.mp4");

        }

        private void btnlevel2_Click(object sender, EventArgs e)
        {
            StartQuiz(1, "tangtoc.mp4");

        }

        private void btnlevel3_Click(object sender, EventArgs e)
        {
            StartQuiz(2, "vcnv.mp4");
  
        }

        private void btnlevel4_Click(object sender, EventArgs e)
        {
            StartQuiz(3, "vedich.mp4");
            
        }

        private void StartQuiz(int level,string videoPath)
        {
            bool shuffle = radioButton1.Checked;
            formIntroLevel.SetVideoPath(videoPath); // Thiết lập đường dẫn video
            formIntroLevel.Show(); // Hiển thị FormIntroLevel
            this.Hide();

            // Chờ video kết thúc trước khi chuyển đến Form1
            formIntroLevel.axWindowsMediaPlayer1.PlayStateChange += async (sender, e) =>
            {
                if (e.newState == (int)WMPLib.WMPPlayState.wmppsMediaEnded)
                {
                    
                    form1 = new Form1(this, formIntroLevel); // Truyền cả formIntroLevel vào Form1
                    form1.StartQuiz(level, shuffle);
                    formIntroLevel.Hide();
                    form1.Show();
                }
            };
        }


        private void FormLevel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
    }
}
