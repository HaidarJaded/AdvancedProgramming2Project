namespace APP2EFCore.Forms
{
    partial class FormChangePassword
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
            textBoxCurrentPassword = new TextBox();
            label1 = new Label();
            textBoxPassword = new TextBox();
            label2 = new Label();
            textBoxPasswordConfirmation = new TextBox();
            label3 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBoxCurrentPassword
            // 
            textBoxCurrentPassword.Location = new Point(60, 70);
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            textBoxCurrentPassword.Size = new Size(187, 23);
            textBoxCurrentPassword.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 15F);
            label1.Location = new Point(116, 28);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(130, 25);
            label1.TabIndex = 1;
            label1.Text = "كلمة المرور الحالية:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(60, 172);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(187, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Tai Le", 15F);
            label2.Location = new Point(116, 130);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(133, 25);
            label2.TabIndex = 1;
            label2.Text = "كلمة المرور الجديدة:";
            // 
            // textBoxPasswordConfirmation
            // 
            textBoxPasswordConfirmation.Location = new Point(60, 273);
            textBoxPasswordConfirmation.Name = "textBoxPasswordConfirmation";
            textBoxPasswordConfirmation.Size = new Size(187, 23);
            textBoxPasswordConfirmation.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Tai Le", 15F);
            label3.Location = new Point(83, 232);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(163, 25);
            label3.TabIndex = 1;
            label3.Text = "تأكيد كلمة المرور الجديدة:";
            // 
            // button1
            // 
            button1.Location = new Point(106, 316);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 3;
            button1.Text = "حفظ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(306, 367);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPasswordConfirmation);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxCurrentPassword);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormChangePassword";
            StartPosition = FormStartPosition.CenterParent;
            Text = "تغيير كلمة المرور";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxCurrentPassword;
        private Label label1;
        private TextBox textBoxPassword;
        private Label label2;
        private TextBox textBoxPasswordConfirmation;
        private Label label3;
        private Button button1;
    }
}