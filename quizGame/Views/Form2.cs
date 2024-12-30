using quizGame.Views;
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
        private FormIntro FormLevel = new FormIntro();
        private StartForm _startForm;

        public Form2()
        {
            ;

            InitializeComponent();
            _startForm = new StartForm(this);
            this.WindowState = FormWindowState.Maximized;

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
            if (FormLevel != null && !FormLevel.IsDisposed) { FormLevel.Close(); }
            if (_startForm != null && !_startForm.IsDisposed) { _startForm.Close(); }
            Application.Exit();
        }
    }
}
