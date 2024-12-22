namespace quizGame
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.BtnStart = new System.Windows.Forms.Button();
            this.btnCreateQues = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnStart
            // 
            this.BtnStart.BackColor = System.Drawing.Color.Transparent;
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(204, 194);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(375, 182);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.Text = "Bắt Đầu";
            this.BtnStart.UseVisualStyleBackColor = false;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnCreateQues
            // 
            this.btnCreateQues.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateQues.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateQues.Location = new System.Drawing.Point(609, 194);
            this.btnCreateQues.Name = "btnCreateQues";
            this.btnCreateQues.Size = new System.Drawing.Size(349, 182);
            this.btnCreateQues.TabIndex = 1;
            this.btnCreateQues.Text = "Tạo đề";
            this.btnCreateQues.UseVisualStyleBackColor = false;
            this.btnCreateQues.Click += new System.EventHandler(this.btnCreateQues_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::quizGame.Properties.Resources.Background_copy;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1138, 624);
            this.Controls.Add(this.btnCreateQues);
            this.Controls.Add(this.BtnStart);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Trang chủ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button btnCreateQues;
    }
}