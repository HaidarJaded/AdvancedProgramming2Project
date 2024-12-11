namespace APP2EFCore.MissingProducts
{
    partial class FormAddMissingProduct
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
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            textBoxName = new TextBox();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(96, 182);
            button2.Name = "button2";
            button2.Size = new Size(139, 23);
            button2.TabIndex = 6;
            button2.Text = "حفظ واغلاق";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(96, 153);
            button1.Name = "button1";
            button1.Size = new Size(139, 23);
            button1.TabIndex = 4;
            button1.Text = "حفظ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 85);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 5;
            label1.Text = "اسم المنتج";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(70, 103);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(176, 23);
            textBoxName.TabIndex = 3;
            // 
            // FormAddMissingProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 342);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MinimizeBox = false;
            Name = "FormAddMissingProduct";
            Text = "FormAddMissingProducts";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private Label label1;
        private TextBox textBoxName;
    }
}