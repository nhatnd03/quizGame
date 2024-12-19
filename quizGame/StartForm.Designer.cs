using quizGame.Resources.Custom;
using System.Drawing;
using System.Windows.Forms;

namespace quizGame
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtQues = new System.Windows.Forms.TextBox();
            this.txtAnsw = new System.Windows.Forms.RichTextBox();
            this.txtCorrectAns = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.checkSort = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.btnPlay.FlatAppearance.BorderSize = 0;
            this.btnPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Image = global::quizGame.Properties.Resources.start_button;
            this.btnPlay.Location = new System.Drawing.Point(86, 17);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(163, 65);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.UseVisualStyleBackColor = false;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.BackColor = System.Drawing.Color.Transparent;
            this.btnAddQuestion.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddQuestion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnAddQuestion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnAddQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddQuestion.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.btnAddQuestion.Image = global::quizGame.Properties.Resources.import;
            this.btnAddQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddQuestion.Location = new System.Drawing.Point(516, 24);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(148, 50);
            this.btnAddQuestion.TabIndex = 1;
            this.btnAddQuestion.Text = "Nhập câu hỏi";
            this.btnAddQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddQuestion.UseVisualStyleBackColor = false;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Location = new System.Drawing.Point(66, 298);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.RowHeadersWidth = 51;
            this.dgvQuestions.RowTemplate.Height = 24;
            this.dgvQuestions.Size = new System.Drawing.Size(961, 466);
            this.dgvQuestions.TabIndex = 2;
            this.dgvQuestions.SelectionChanged += new System.EventHandler(this.DgvQuestions_SelectionChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(267, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(138, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.Transparent;
            this.btnSua.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSua.Image = global::quizGame.Properties.Resources.maintenance;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.Location = new System.Drawing.Point(1094, 524);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(91, 46);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Image = global::quizGame.Properties.Resources.delete;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.Location = new System.Drawing.Point(1094, 399);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(115, 45);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Xóa Hết";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Image = global::quizGame.Properties.Resources.delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(1094, 463);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 45);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtQues
            // 
            this.txtQues.Location = new System.Drawing.Point(848, 28);
            this.txtQues.Name = "txtQues";
            this.txtQues.Size = new System.Drawing.Size(547, 22);
            this.txtQues.TabIndex = 7;
            // 
            // txtAnsw
            // 
            this.txtAnsw.Location = new System.Drawing.Point(848, 71);
            this.txtAnsw.Name = "txtAnsw";
            this.txtAnsw.Size = new System.Drawing.Size(547, 76);
            this.txtAnsw.TabIndex = 8;
            this.txtAnsw.Text = "";
            // 
            // txtCorrectAns
            // 
            this.txtCorrectAns.Location = new System.Drawing.Point(848, 163);
            this.txtCorrectAns.Name = "txtCorrectAns";
            this.txtCorrectAns.Size = new System.Drawing.Size(547, 22);
            this.txtCorrectAns.TabIndex = 9;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.Transparent;
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnThem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnThem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnThem.Image = global::quizGame.Properties.Resources.plus;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.Location = new System.Drawing.Point(1094, 335);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(91, 46);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // checkSort
            // 
            this.checkSort.AutoSize = true;
            this.checkSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.checkSort.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkSort.Location = new System.Drawing.Point(411, 32);
            this.checkSort.Name = "checkSort";
            this.checkSort.Size = new System.Drawing.Size(78, 20);
            this.checkSort.TabIndex = 11;
            this.checkSort.Text = "Xắp xếp";
            this.checkSort.UseVisualStyleBackColor = true;
            this.checkSort.CheckedChanged += new System.EventHandler(this.checkSort_CheckedChanged);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.checkSort);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtCorrectAns);
            this.Controls.Add(this.txtAnsw);
            this.Controls.Add(this.txtQues);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgvQuestions);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.btnPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "QuizGame";
            this.Load += new System.EventHandler(this.StartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtQues;
        private System.Windows.Forms.RichTextBox txtAnsw;
        private System.Windows.Forms.TextBox txtCorrectAns;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.CheckBox checkSort;
    }
}
