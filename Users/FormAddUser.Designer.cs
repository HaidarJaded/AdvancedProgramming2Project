namespace APP2EFCore.Users
{
    partial class FormAddUser
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
            textBoxName = new TextBox();
            label1 = new Label();
            textBoxEmail = new TextBox();
            label2 = new Label();
            textBoxPassword = new TextBox();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBoxPasswordConfirm = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(69, 58);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(153, 23);
            textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(166, 24);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 1;
            label1.Text = "اسم البائع";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(70, 134);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(153, 23);
            textBoxEmail.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(137, 100);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 1;
            label2.Text = "البريد الالكتروني";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(69, 210);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(153, 23);
            textBoxPassword.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(168, 176);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 1;
            label3.Text = "كلمة السر";
            // 
            // button1
            // 
            button1.Location = new Point(101, 328);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "حفظ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(101, 370);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "حفظ واغلاق";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBoxPasswordConfirm
            // 
            textBoxPasswordConfirm.Location = new Point(69, 286);
            textBoxPasswordConfirm.Name = "textBoxPasswordConfirm";
            textBoxPasswordConfirm.PasswordChar = '*';
            textBoxPasswordConfirm.Size = new Size(153, 23);
            textBoxPasswordConfirm.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(142, 252);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 1;
            label4.Text = "تأكيد كلمة السر";
            // 
            // FormAddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 418);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxPasswordConfirm);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAddUser";
            RightToLeft = RightToLeft.Yes;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة بائع";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Label label1;
        private TextBox textBoxEmail;
        private Label label2;
        private TextBox textBoxPassword;
        private Label label3;
        private Button button1;
        private Button button2;
        private TextBox textBoxPasswordConfirm;
        private Label label4;
    }
}