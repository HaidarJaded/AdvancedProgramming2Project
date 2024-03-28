namespace APP2EFCore.Forms
{
    partial class FormChangeProfitRatio
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
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            numericProfitRatio = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numericProfitRatio).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 15F);
            label1.Location = new Point(117, 53);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(79, 25);
            label1.TabIndex = 1;
            label1.Text = "نسبة الربح:";
            // 
            // button1
            // 
            button1.Location = new Point(100, 145);
            button1.Name = "button1";
            button1.Size = new Size(100, 23);
            button1.TabIndex = 2;
            button1.Text = "تغيير";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Tai Le", 15F);
            label2.Location = new Point(66, 91);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(28, 25);
            label2.TabIndex = 1;
            label2.Text = "%";
            // 
            // numericProfitRatio
            // 
            numericProfitRatio.Location = new Point(100, 91);
            numericProfitRatio.Name = "numericProfitRatio";
            numericProfitRatio.Size = new Size(120, 23);
            numericProfitRatio.TabIndex = 3;
            numericProfitRatio.TextAlign = HorizontalAlignment.Center;
            // 
            // FormChangeProfitRatio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(308, 233);
            Controls.Add(numericProfitRatio);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FormChangeProfitRatio";
            StartPosition = FormStartPosition.CenterParent;
            Text = "تغيير النسبة";
            ((System.ComponentModel.ISupportInitialize)numericProfitRatio).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Button button1;
        private Label label2;
        private NumericUpDown numericProfitRatio;
    }
}