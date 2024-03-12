namespace APP2EFCore.Purchases
{
    partial class FormAddPurchases
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
            panel1 = new Panel();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            comboBoxProductCategory = new ComboBox();
            numericProductPrice = new NumericUpDown();
            numericProductCount = new NumericUpDown();
            label3 = new Label();
            label5 = new Label();
            labelTotalInvoice = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxProductName = new TextBox();
            DGVProducts = new DataGridView();
            ProductName = new DataGridViewTextBoxColumn();
            Category = new DataGridViewTextBoxColumn();
            ProductCount = new DataGridViewTextBoxColumn();
            ProductPrice = new DataGridViewTextBoxColumn();
            ProductsTotalPrice = new DataGridViewTextBoxColumn();
            CategoryId = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericProductCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVProducts).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(linkLabel1);
            panel1.Controls.Add(comboBoxProductCategory);
            panel1.Controls.Add(numericProductPrice);
            panel1.Controls.Add(numericProductCount);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(labelTotalInvoice);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxProductName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 104);
            panel1.TabIndex = 0;
            // 
            // button4
            // 
            button4.Location = new Point(232, 63);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 5;
            button4.Text = "حفظ واغلاق";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(313, 63);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 5;
            button3.Text = "حفظ";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(394, 63);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "حذف";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(473, 63);
            button1.Name = "button1";
            button1.Size = new Size(95, 23);
            button1.TabIndex = 4;
            button1.Text = "اضافة للجدول";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(388, 1);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(68, 15);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "اضافة صنف";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // comboBoxProductCategory
            // 
            comboBoxProductCategory.FormattingEnabled = true;
            comboBoxProductCategory.Location = new Point(360, 18);
            comboBoxProductCategory.Name = "comboBoxProductCategory";
            comboBoxProductCategory.Size = new Size(121, 23);
            comboBoxProductCategory.TabIndex = 1;
            // 
            // numericProductPrice
            // 
            numericProductPrice.Location = new Point(145, 15);
            numericProductPrice.Maximum = new decimal(new int[] { -559939585, 902409669, 54, 0 });
            numericProductPrice.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericProductPrice.Name = "numericProductPrice";
            numericProductPrice.Size = new Size(120, 23);
            numericProductPrice.TabIndex = 2;
            numericProductPrice.TextAlign = HorizontalAlignment.Center;
            numericProductPrice.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericProductCount
            // 
            numericProductCount.Location = new Point(580, 56);
            numericProductCount.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericProductCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericProductCount.Name = "numericProductCount";
            numericProductCount.Size = new Size(120, 23);
            numericProductCount.TabIndex = 3;
            numericProductCount.TextAlign = HorizontalAlignment.Center;
            numericProductCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS Reference Sans Serif", 15F);
            label3.Location = new Point(487, 15);
            label3.Name = "label3";
            label3.Size = new Size(67, 26);
            label3.TabIndex = 1;
            label3.Text = "الصنف:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("MS Reference Sans Serif", 15F);
            label5.Location = new Point(12, 8);
            label5.Name = "label5";
            label5.Size = new Size(129, 26);
            label5.TabIndex = 1;
            label5.Text = "الفاتورة الاجمالية:";
            // 
            // labelTotalInvoice
            // 
            labelTotalInvoice.AutoSize = true;
            labelTotalInvoice.Font = new Font("MS Reference Sans Serif", 15F);
            labelTotalInvoice.Location = new Point(54, 56);
            labelTotalInvoice.Name = "labelTotalInvoice";
            labelTotalInvoice.Size = new Size(25, 26);
            labelTotalInvoice.TabIndex = 1;
            labelTotalInvoice.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MS Reference Sans Serif", 15F);
            label4.Location = new Point(277, 12);
            label4.Name = "label4";
            label4.Size = new Size(58, 26);
            label4.TabIndex = 1;
            label4.Text = "السعر:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS Reference Sans Serif", 15F);
            label2.Location = new Point(712, 53);
            label2.Name = "label2";
            label2.Size = new Size(58, 26);
            label2.TabIndex = 1;
            label2.Text = "الكمية:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS Reference Sans Serif", 15F);
            label1.Location = new Point(712, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 26);
            label1.TabIndex = 1;
            label1.Text = "اسم المنتج:";
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(580, 15);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(120, 23);
            textBoxProductName.TabIndex = 0;
            // 
            // DGVProducts
            // 
            DGVProducts.AllowUserToAddRows = false;
            DGVProducts.AllowUserToDeleteRows = false;
            DGVProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVProducts.BackgroundColor = Color.White;
            DGVProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVProducts.Columns.AddRange(new DataGridViewColumn[] { ProductName, Category, ProductCount, ProductPrice, ProductsTotalPrice, CategoryId });
            DGVProducts.Dock = DockStyle.Fill;
            DGVProducts.Location = new Point(0, 104);
            DGVProducts.Name = "DGVProducts";
            DGVProducts.ReadOnly = true;
            DGVProducts.Size = new Size(800, 346);
            DGVProducts.TabIndex = 1;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "اسم المنتج";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // Category
            // 
            Category.HeaderText = "الصنف";
            Category.Name = "Category";
            Category.ReadOnly = true;
            // 
            // ProductCount
            // 
            ProductCount.HeaderText = "الكمية";
            ProductCount.Name = "ProductCount";
            ProductCount.ReadOnly = true;
            // 
            // ProductPrice
            // 
            ProductPrice.HeaderText = "السعر الفردي";
            ProductPrice.Name = "ProductPrice";
            ProductPrice.ReadOnly = true;
            // 
            // ProductsTotalPrice
            // 
            ProductsTotalPrice.HeaderText = "السعر الاجمالي";
            ProductsTotalPrice.Name = "ProductsTotalPrice";
            ProductsTotalPrice.ReadOnly = true;
            // 
            // CategoryId
            // 
            CategoryId.HeaderText = "CategoryId";
            CategoryId.Name = "CategoryId";
            CategoryId.ReadOnly = true;
            CategoryId.Visible = false;
            // 
            // FormAddPurchases
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(DGVProducts);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormAddPurchases";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "اضافة عملية شراء";
            Activated += FormAddPurchases_Activated;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericProductCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView DGVProducts;
        private ComboBox comboBoxProductCategory;
        private NumericUpDown numericProductPrice;
        private NumericUpDown numericProductCount;
        private Label label3;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private TextBox textBoxProductName;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        private LinkLabel linkLabel1;
        private Label labelTotalInvoice;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn ProductCount;
        private DataGridViewTextBoxColumn ProductPrice;
        private DataGridViewTextBoxColumn ProductsTotalPrice;
        private DataGridViewTextBoxColumn CategoryId;
    }
}