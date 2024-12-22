namespace quizGame
{
    partial class FormLevel
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnlevel = new System.Windows.Forms.Button();
            this.btnlevel2 = new System.Windows.Forms.Button();
            this.btnlevel3 = new System.Windows.Forms.Button();
            this.btnlevel4 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chọn độ khó";
            // 
            // btnlevel
            // 
            this.btnlevel.Location = new System.Drawing.Point(252, 22);
            this.btnlevel.Name = "btnlevel";
            this.btnlevel.Size = new System.Drawing.Size(156, 50);
            this.btnlevel.TabIndex = 6;
            this.btnlevel.Text = "Level 0";
            this.btnlevel.UseVisualStyleBackColor = true;
            this.btnlevel.Click += new System.EventHandler(this.btnlevel_Click);
            // 
            // btnlevel2
            // 
            this.btnlevel2.Location = new System.Drawing.Point(252, 101);
            this.btnlevel2.Name = "btnlevel2";
            this.btnlevel2.Size = new System.Drawing.Size(156, 50);
            this.btnlevel2.TabIndex = 7;
            this.btnlevel2.Text = "Level 1";
            this.btnlevel2.UseVisualStyleBackColor = true;
            this.btnlevel2.Click += new System.EventHandler(this.btnlevel2_Click);
            // 
            // btnlevel3
            // 
            this.btnlevel3.Location = new System.Drawing.Point(252, 171);
            this.btnlevel3.Name = "btnlevel3";
            this.btnlevel3.Size = new System.Drawing.Size(156, 50);
            this.btnlevel3.TabIndex = 8;
            this.btnlevel3.Text = "Level 2";
            this.btnlevel3.UseVisualStyleBackColor = true;
            this.btnlevel3.Click += new System.EventHandler(this.btnlevel3_Click);
            // 
            // btnlevel4
            // 
            this.btnlevel4.Location = new System.Drawing.Point(252, 244);
            this.btnlevel4.Name = "btnlevel4";
            this.btnlevel4.Size = new System.Drawing.Size(156, 50);
            this.btnlevel4.TabIndex = 9;
            this.btnlevel4.Text = "Level 3";
            this.btnlevel4.UseVisualStyleBackColor = true;
            this.btnlevel4.Click += new System.EventHandler(this.btnlevel4_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(485, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Xắp xếp";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(485, 116);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(116, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Không xắp xếp";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // FormLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 342);
            this.Controls.Add(this.btnlevel4);
            this.Controls.Add(this.btnlevel3);
            this.Controls.Add(this.btnlevel2);
            this.Controls.Add(this.btnlevel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "FormLevel";
            this.Text = "FormLevel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLevel_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlevel;
        private System.Windows.Forms.Button btnlevel2;
        private System.Windows.Forms.Button btnlevel3;
        private System.Windows.Forms.Button btnlevel4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}