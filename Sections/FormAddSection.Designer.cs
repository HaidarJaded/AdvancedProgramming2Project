namespace APP2EFCore.Sections
{
    partial class FormAddSection
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
            textBoxSectionName = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBoxSectionName
            // 
            textBoxSectionName.Location = new Point(76, 75);
            textBoxSectionName.Name = "textBoxSectionName";
            textBoxSectionName.Size = new Size(183, 23);
            textBoxSectionName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(138, 57);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 1;
            label1.Text = "اسم القسم:";
            // 
            // button1
            // 
            button1.Location = new Point(126, 119);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "اضافة";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(118, 158);
            button2.Name = "button2";
            button2.Size = new Size(83, 23);
            button2.TabIndex = 2;
            button2.Text = "اضافة وإغلاق";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormAddSection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 228);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBoxSectionName);
            Name = "FormAddSection";
            RightToLeft = RightToLeft.Yes;
            Text = "إضافة قسم جديد";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxSectionName;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}