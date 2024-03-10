namespace APP2EFCore.Forms
{
    partial class FormLogin
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
            button1 = new Button();
            label2 = new Label();
            textBoxPassword = new TextBox();
            label1 = new Label();
            textBoxEmail = new TextBox();
            linkLabelCreateAccount = new LinkLabel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(95, 251);
            button1.Name = "button1";
            button1.Size = new Size(163, 23);
            button1.TabIndex = 2;
            button1.Text = "تسجيل الدخول";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 20F);
            label2.ForeColor = Color.CornflowerBlue;
            label2.Location = new Point(198, 137);
            label2.Name = "label2";
            label2.Size = new Size(100, 31);
            label2.TabIndex = 0;
            label2.Text = "كلمة السر";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(64, 183);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(234, 23);
            textBoxPassword.TabIndex = 1;
            textBoxPassword.KeyPress += textBoxPassword_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 20F);
            label1.ForeColor = Color.CornflowerBlue;
            label1.Location = new Point(137, 33);
            label1.Name = "label1";
            label1.Size = new Size(161, 31);
            label1.TabIndex = 0;
            label1.Text = "البريد الالكتروني";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(64, 84);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(234, 23);
            textBoxEmail.TabIndex = 0;
            // 
            // linkLabelCreateAccount
            // 
            linkLabelCreateAccount.AutoSize = true;
            linkLabelCreateAccount.Font = new Font("Segoe UI", 12F);
            linkLabelCreateAccount.Location = new Point(137, 304);
            linkLabelCreateAccount.Name = "linkLabelCreateAccount";
            linkLabelCreateAccount.Size = new Size(88, 21);
            linkLabelCreateAccount.TabIndex = 3;
            linkLabelCreateAccount.TabStop = true;
            linkLabelCreateAccount.Text = "انشاء حساب";
            linkLabelCreateAccount.LinkClicked += linkLabelCreateAccount_LinkClicked;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(363, 378);
            Controls.Add(linkLabelCreateAccount);
            Controls.Add(button1);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxPassword);
            Controls.Add(label1);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLogin";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "تسجيل الدخول";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label2;
        private TextBox textBoxPassword;
        private Label label1;
        private TextBox textBoxEmail;
        private LinkLabel linkLabelCreateAccount;
    }
}