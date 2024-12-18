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
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(81, 12);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(260, 100);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Chơi Game";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.Location = new System.Drawing.Point(690, 12);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(260, 100);
            this.btnAddQuestion.TabIndex = 1;
            this.btnAddQuestion.Text = "Thêm Câu Hỏi";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Location = new System.Drawing.Point(12, 257);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.RowHeadersWidth = 51;
            this.dgvQuestions.RowTemplate.Height = 24;
            this.dgvQuestions.Size = new System.Drawing.Size(1568, 619);
            this.dgvQuestions.TabIndex = 2;
            this.dgvQuestions.SelectionChanged += new System.EventHandler(this.DgvQuestions_SelectionChanged); //Thêm sự kiện SelectionChanged
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(387, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(192, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(1641, 383);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(165, 66);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1641, 510);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(165, 65);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Xóa Hết";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1641, 634);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 65);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtQues
            // 
            this.txtQues.Location = new System.Drawing.Point(1102, 28);
            this.txtQues.Name = "txtQues";
            this.txtQues.Size = new System.Drawing.Size(601, 22);
            this.txtQues.TabIndex = 7;
            // 
            // txtAnsw
            // 
            this.txtAnsw.Location = new System.Drawing.Point(1102, 69);
            this.txtAnsw.Name = "txtAnsw";
            this.txtAnsw.Size = new System.Drawing.Size(601, 96);
            this.txtAnsw.TabIndex = 8;
            this.txtAnsw.Text = "";
            // 
            // txtCorrectAns
            // 
            this.txtCorrectAns.Location = new System.Drawing.Point(1102, 172);
            this.txtCorrectAns.Name = "txtCorrectAns";
            this.txtCorrectAns.Size = new System.Drawing.Size(100, 22);
            this.txtCorrectAns.TabIndex = 9;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1033);
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
            this.Name = "StartForm";
            this.Text = "Màn Hình Bắt Đầu";
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
    }
}
