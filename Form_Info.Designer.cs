
namespace Prog_Kursovaya_sem3
{
    partial class Form_Info
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
            this.button_InfoNo = new System.Windows.Forms.Button();
            this.button_InfoYes = new System.Windows.Forms.Button();
            this.label_InfoQuestion = new System.Windows.Forms.Label();
            this.richTextBox_Info = new System.Windows.Forms.RichTextBox();
            this.button_InfoExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_InfoNo
            // 
            this.button_InfoNo.Location = new System.Drawing.Point(24, 261);
            this.button_InfoNo.Name = "button_InfoNo";
            this.button_InfoNo.Size = new System.Drawing.Size(72, 26);
            this.button_InfoNo.TabIndex = 0;
            this.button_InfoNo.Text = "Нет";
            this.button_InfoNo.UseVisualStyleBackColor = true;
            this.button_InfoNo.Click += new System.EventHandler(this.button_InfoNo_Click);
            // 
            // button_InfoYes
            // 
            this.button_InfoYes.Location = new System.Drawing.Point(227, 261);
            this.button_InfoYes.Name = "button_InfoYes";
            this.button_InfoYes.Size = new System.Drawing.Size(72, 26);
            this.button_InfoYes.TabIndex = 1;
            this.button_InfoYes.Text = "Да";
            this.button_InfoYes.UseVisualStyleBackColor = true;
            this.button_InfoYes.Click += new System.EventHandler(this.button_InfoYes_Click);
            // 
            // label_InfoQuestion
            // 
            this.label_InfoQuestion.AutoSize = true;
            this.label_InfoQuestion.Location = new System.Drawing.Point(108, 268);
            this.label_InfoQuestion.Name = "label_InfoQuestion";
            this.label_InfoQuestion.Size = new System.Drawing.Size(111, 13);
            this.label_InfoQuestion.TabIndex = 2;
            this.label_InfoQuestion.Text = "Добавить к сборке?";
            // 
            // richTextBox_Info
            // 
            this.richTextBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox_Info.Location = new System.Drawing.Point(23, 21);
            this.richTextBox_Info.Name = "richTextBox_Info";
            this.richTextBox_Info.ReadOnly = true;
            this.richTextBox_Info.Size = new System.Drawing.Size(275, 231);
            this.richTextBox_Info.TabIndex = 3;
            this.richTextBox_Info.Text = "";
            // 
            // button_InfoExit
            // 
            this.button_InfoExit.Location = new System.Drawing.Point(94, 262);
            this.button_InfoExit.Name = "button_InfoExit";
            this.button_InfoExit.Size = new System.Drawing.Size(136, 24);
            this.button_InfoExit.TabIndex = 4;
            this.button_InfoExit.Text = "Вернуться назад";
            this.button_InfoExit.UseVisualStyleBackColor = true;
            this.button_InfoExit.Click += new System.EventHandler(this.button_InfoExit_Click);
            // 
            // Form_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 307);
            this.Controls.Add(this.button_InfoExit);
            this.Controls.Add(this.richTextBox_Info);
            this.Controls.Add(this.label_InfoQuestion);
            this.Controls.Add(this.button_InfoYes);
            this.Controls.Add(this.button_InfoNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Info";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация об элементе";
            this.Load += new System.EventHandler(this.Form_Info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_InfoNo;
        private System.Windows.Forms.Button button_InfoYes;
        private System.Windows.Forms.Label label_InfoQuestion;
        private System.Windows.Forms.RichTextBox richTextBox_Info;
        private System.Windows.Forms.Button button_InfoExit;
    }
}