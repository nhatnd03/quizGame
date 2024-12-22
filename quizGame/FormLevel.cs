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

        public FormLevel() 
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnlevel_Click(object sender, EventArgs e)
        {
            StartQuiz(0);

        }

        private void btnlevel2_Click(object sender, EventArgs e)
        {
            StartQuiz(1);

        }

        private void btnlevel3_Click(object sender, EventArgs e)
        {
            StartQuiz(2);
  
        }

        private void btnlevel4_Click(object sender, EventArgs e)
        {
            StartQuiz(3);
            
        }

        private void StartQuiz(int level)
        {
            bool shuffle = radioButton1.Checked; 
            form1 = new Form1(this);
            form1.StartQuiz(level, shuffle); 
            this.Hide();
            form1.Show();
        }


        private void FormLevel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }
    }
}
