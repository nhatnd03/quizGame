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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(55, 28);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(193, 40);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Chơi Game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.FlatStyle = FlatStyle.Flat; // Thiết kế nút phẳng
            this.btnPlay.FlatAppearance.BorderSize = 2; //Thêm viền cho nút
            this.btnPlay.FlatAppearance.BorderColor = System.Drawing.Color.Black; //Màu viền
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(516, 28);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(116, 40);
            this.btnAddQuestion.TabIndex = 1;
            this.btnAddQuestion.Text = "Thêm Câu Hỏi";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            this.btnAddQuestion.FlatStyle = FlatStyle.Flat;
            this.btnAddQuestion.FlatAppearance.BorderSize = 2;
            this.btnAddQuestion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
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
            this.btnSua.Location = new System.Drawing.Point(1094, 421);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(165, 46);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            this.btnSua.FlatStyle = FlatStyle.Flat;
            this.btnSua.FlatAppearance.BorderSize = 2;
            this.btnSua.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1094, 485);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(165, 45);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Xóa Hết";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 2;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1094, 551);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 45);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
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

            this.btnThem.Location = new System.Drawing.Point(1094, 347);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(165, 46);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm 1";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            this.btnThem.FlatStyle = FlatStyle.Flat;
            this.btnThem.FlatAppearance.BorderSize = 2;
            this.btnThem.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            // 
            // checkSort
            // 
            this.checkSort.AutoSize = true;
            this.checkSort.Location = new System.Drawing.Point(411, 32);
            this.checkSort.Name = "checkSort";
            this.checkSort.Size = new System.Drawing.Size(78, 20);
            this.checkSort.TabIndex = 11;
            this.checkSort.Text = "Xắp xếp";
            this.checkSort.UseVisualStyleBackColor = true;
            this.checkSort.CheckedChanged += new System.EventHandler(this.checkSort_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(690, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Question :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(690, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Answers :";
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(668, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Correct Answer :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(351, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(344, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "Bảng Danh sách câu hỏi";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::quizGame.Properties.Resources.csgo1;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
