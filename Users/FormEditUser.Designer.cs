namespace APP2EFCore.Users
{
    partial class FormEditUser
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
            label1 = new Label();
            textBoxEmail = new TextBox();
            textBoxName = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(109, 237);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 14;
            button1.Text = "حفظ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(145, 139);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 9;
            label2.Text = "البريد الالكتروني";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(174, 41);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 10;
            label1.Text = "اسم البائع";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(78, 184);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(153, 23);
            textBoxEmail.TabIndex = 11;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(77, 86);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(153, 23);
            textBoxName.TabIndex = 6;
            // 
            // FormEditUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 302);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEditUser";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            Text = "تعديل بيانات بائع";
            Load += FormEditUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label2;
        private Label label1;
        private TextBox textBoxEmail;
        private TextBox textBoxName;
    }
}