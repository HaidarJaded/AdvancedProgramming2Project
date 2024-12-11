namespace APP2EFCore.Products
{
    partial class FormEditProduct
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
            comboBoxProductCategory = new ComboBox();
            label2 = new Label();
            numericProductPrice = new NumericUpDown();
            label3 = new Label();
            button1 = new Button();
            label4 = new Label();
            comboBoxProductSection = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).BeginInit();
            SuspendLayout();
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(91, 62);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(170, 23);
            textBoxName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(202, 25);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 1;
            label1.Text = "اسم المنتج";
            // 
            // comboBoxProductCategory
            // 
            comboBoxProductCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductCategory.FormattingEnabled = true;
            comboBoxProductCategory.Location = new Point(91, 144);
            comboBoxProductCategory.Name = "comboBoxProductCategory";
            comboBoxProductCategory.Size = new Size(170, 23);
            comboBoxProductCategory.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 107);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 1;
            label2.Text = "الصنف";
            // 
            // numericProductPrice
            // 
            numericProductPrice.Location = new Point(91, 278);
            numericProductPrice.Maximum = new decimal(new int[] { -1486618625, 232830643, 0, 0 });
            numericProductPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericProductPrice.Name = "numericProductPrice";
            numericProductPrice.Size = new Size(170, 23);
            numericProductPrice.TabIndex = 3;
            numericProductPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(219, 241);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 1;
            label3.Text = "السعر";
            // 
            // button1
            // 
            button1.Location = new Point(112, 323);
            button1.Name = "button1";
            button1.Size = new Size(130, 23);
            button1.TabIndex = 4;
            button1.Text = "حفظ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(219, 178);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 1;
            label4.Text = "القسم";
            // 
            // comboBoxProductSection
            // 
            comboBoxProductSection.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductSection.FormattingEnabled = true;
            comboBoxProductSection.Location = new Point(91, 215);
            comboBoxProductSection.Name = "comboBoxProductSection";
            comboBoxProductSection.Size = new Size(170, 23);
            comboBoxProductSection.TabIndex = 2;
            // 
            // FormEditProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(353, 423);
            Controls.Add(button1);
            Controls.Add(numericProductPrice);
            Controls.Add(comboBoxProductSection);
            Controls.Add(comboBoxProductCategory);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxName);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEditProduct";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "تعديل بيانات منتج";
            Load += FormEditProduct_Load;
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxName;
        private Label label1;
        private ComboBox comboBoxProductCategory;
        private Label label2;
        private NumericUpDown numericProductPrice;
        private Label label3;
        private Button button1;
        private Label label4;
        private ComboBox comboBoxProductSection;
    }
}