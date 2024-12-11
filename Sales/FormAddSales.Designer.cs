namespace APP2EFCore.Sales
{
    partial class FormAddSales
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
            numericProductCount = new NumericUpDown();
            numericProductPrice = new NumericUpDown();
            button2 = new Button();
            button4 = new Button();
            button3 = new Button();
            button1 = new Button();
            textBoxAvailableProductCount = new TextBox();
            textBoxInvoiceTotalPrice = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            DGVSales = new DataGridView();
            ProducId = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            ProductCategory = new DataGridViewTextBoxColumn();
            ProductCount = new DataGridViewTextBoxColumn();
            ProductPrice = new DataGridViewTextBoxColumn();
            ProductTotalPrice = new DataGridViewTextBoxColumn();
            DGVProducts = new DataGridView();
            ProductId = new DataGridViewTextBoxColumn();
            ProductNameRight = new DataGridViewTextBoxColumn();
            ProductCategoryRight = new DataGridViewTextBoxColumn();
            ProductCountRight = new DataGridViewTextBoxColumn();
            ProductPriceRight = new DataGridViewTextBoxColumn();
            ProductSectionRight = new DataGridViewTextBoxColumn();
            panelContainerRight = new Panel();
            labelLanguage = new LinkLabel();
            label5 = new Label();
            textBoxSearchProducts = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericProductCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVSales).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGVProducts).BeginInit();
            panelContainerRight.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(numericProductCount);
            panel1.Controls.Add(numericProductPrice);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBoxAvailableProductCount);
            panel1.Controls.Add(textBoxInvoiceTotalPrice);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1038, 93);
            panel1.TabIndex = 0;
            // 
            // numericProductCount
            // 
            numericProductCount.Location = new Point(417, 51);
            numericProductCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericProductCount.Name = "numericProductCount";
            numericProductCount.Size = new Size(120, 23);
            numericProductCount.TabIndex = 3;
            numericProductCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericProductPrice
            // 
            numericProductPrice.Location = new Point(417, 22);
            numericProductPrice.Maximum = new decimal(new int[] { 1874919423, 2328306, 0, 0 });
            numericProductPrice.Name = "numericProductPrice";
            numericProductPrice.Size = new Size(120, 23);
            numericProductPrice.TabIndex = 3;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(306, 47);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "حفظ واغلاق";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Enabled = false;
            button4.Location = new Point(645, 51);
            button4.Name = "button4";
            button4.Size = new Size(90, 23);
            button4.TabIndex = 2;
            button4.Text = "اضافة للجدول";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(645, 22);
            button3.Name = "button3";
            button3.Size = new Size(90, 23);
            button3.TabIndex = 2;
            button3.Text = "ازالة من الجدول";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(306, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "حفظ";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxAvailableProductCount
            // 
            textBoxAvailableProductCount.Location = new Point(164, 48);
            textBoxAvailableProductCount.Name = "textBoxAvailableProductCount";
            textBoxAvailableProductCount.ReadOnly = true;
            textBoxAvailableProductCount.Size = new Size(100, 23);
            textBoxAvailableProductCount.TabIndex = 1;
            textBoxAvailableProductCount.Text = "0";
            textBoxAvailableProductCount.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxInvoiceTotalPrice
            // 
            textBoxInvoiceTotalPrice.Location = new Point(22, 48);
            textBoxInvoiceTotalPrice.Name = "textBoxInvoiceTotalPrice";
            textBoxInvoiceTotalPrice.ReadOnly = true;
            textBoxInvoiceTotalPrice.Size = new Size(100, 23);
            textBoxInvoiceTotalPrice.TabIndex = 1;
            textBoxInvoiceTotalPrice.Text = "0";
            textBoxInvoiceTotalPrice.TextAlign = HorizontalAlignment.Center;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Tahoma", 15F);
            label4.Location = new Point(541, 20);
            label4.Name = "label4";
            label4.Size = new Size(98, 24);
            label4.TabIndex = 0;
            label4.Text = "سعر البيع:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 15F);
            label3.Location = new Point(541, 50);
            label3.Name = "label3";
            label3.Size = new Size(69, 24);
            label3.TabIndex = 0;
            label3.Text = "الكمية:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 15F);
            label2.Location = new Point(154, 9);
            label2.Name = "label2";
            label2.Size = new Size(132, 24);
            label2.TabIndex = 0;
            label2.Text = "الكمية المتوفرة";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 15F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(136, 24);
            label1.TabIndex = 0;
            label1.Text = "اجمالي الفاتورة";
            // 
            // DGVSales
            // 
            DGVSales.AllowUserToAddRows = false;
            DGVSales.AllowUserToDeleteRows = false;
            DGVSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVSales.BackgroundColor = Color.White;
            DGVSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVSales.Columns.AddRange(new DataGridViewColumn[] { ProducId, ProductName, ProductCategory, ProductCount, ProductPrice, ProductTotalPrice });
            DGVSales.Dock = DockStyle.Left;
            DGVSales.Location = new Point(0, 93);
            DGVSales.MultiSelect = false;
            DGVSales.Name = "DGVSales";
            DGVSales.ReadOnly = true;
            DGVSales.Size = new Size(611, 411);
            DGVSales.TabIndex = 1;
            // 
            // ProducId
            // 
            ProducId.HeaderText = "ProductId";
            ProducId.Name = "ProducId";
            ProducId.ReadOnly = true;
            ProducId.Visible = false;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "اسم المنتج";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // ProductCategory
            // 
            ProductCategory.HeaderText = "الصنف";
            ProductCategory.Name = "ProductCategory";
            ProductCategory.ReadOnly = true;
            // 
            // ProductCount
            // 
            ProductCount.HeaderText = "الكمية";
            ProductCount.Name = "ProductCount";
            ProductCount.ReadOnly = true;
            // 
            // ProductPrice
            // 
            ProductPrice.HeaderText = "السعر";
            ProductPrice.Name = "ProductPrice";
            ProductPrice.ReadOnly = true;
            // 
            // ProductTotalPrice
            // 
            ProductTotalPrice.HeaderText = "السعر الاجمالي";
            ProductTotalPrice.Name = "ProductTotalPrice";
            ProductTotalPrice.ReadOnly = true;
            // 
            // DGVProducts
            // 
            DGVProducts.AllowUserToAddRows = false;
            DGVProducts.AllowUserToDeleteRows = false;
            DGVProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVProducts.BackgroundColor = Color.White;
            DGVProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVProducts.Columns.AddRange(new DataGridViewColumn[] { ProductId, ProductNameRight, ProductCategoryRight, ProductCountRight, ProductPriceRight, ProductSectionRight });
            DGVProducts.Dock = DockStyle.Bottom;
            DGVProducts.Location = new Point(0, 86);
            DGVProducts.MultiSelect = false;
            DGVProducts.Name = "DGVProducts";
            DGVProducts.ReadOnly = true;
            DGVProducts.Size = new Size(421, 325);
            DGVProducts.TabIndex = 2;
            DGVProducts.CellDoubleClick += DGVProducts_CellDoubleClick;
            DGVProducts.SelectionChanged += DGVProducts_SelectionChanged;
            // 
            // ProductId
            // 
            ProductId.HeaderText = "Column1";
            ProductId.Name = "ProductId";
            ProductId.ReadOnly = true;
            ProductId.Visible = false;
            // 
            // ProductNameRight
            // 
            ProductNameRight.FillWeight = 152.284271F;
            ProductNameRight.HeaderText = "اسم المنتج";
            ProductNameRight.Name = "ProductNameRight";
            ProductNameRight.ReadOnly = true;
            // 
            // ProductCategoryRight
            // 
            ProductCategoryRight.HeaderText = "Column1";
            ProductCategoryRight.Name = "ProductCategoryRight";
            ProductCategoryRight.ReadOnly = true;
            ProductCategoryRight.Visible = false;
            // 
            // ProductCountRight
            // 
            ProductCountRight.HeaderText = "Column1";
            ProductCountRight.Name = "ProductCountRight";
            ProductCountRight.ReadOnly = true;
            ProductCountRight.Visible = false;
            // 
            // ProductPriceRight
            // 
            ProductPriceRight.HeaderText = "Column1";
            ProductPriceRight.Name = "ProductPriceRight";
            ProductPriceRight.ReadOnly = true;
            ProductPriceRight.Visible = false;
            // 
            // ProductSectionRight
            // 
            ProductSectionRight.FillWeight = 47.71573F;
            ProductSectionRight.HeaderText = "القسم";
            ProductSectionRight.Name = "ProductSectionRight";
            ProductSectionRight.ReadOnly = true;
            // 
            // panelContainerRight
            // 
            panelContainerRight.Controls.Add(labelLanguage);
            panelContainerRight.Controls.Add(label5);
            panelContainerRight.Controls.Add(textBoxSearchProducts);
            panelContainerRight.Controls.Add(DGVProducts);
            panelContainerRight.Dock = DockStyle.Right;
            panelContainerRight.Location = new Point(617, 93);
            panelContainerRight.Name = "panelContainerRight";
            panelContainerRight.Size = new Size(421, 411);
            panelContainerRight.TabIndex = 3;
            // 
            // labelLanguage
            // 
            labelLanguage.AutoSize = true;
            labelLanguage.Location = new Point(3, 29);
            labelLanguage.Name = "labelLanguage";
            labelLanguage.Size = new Size(22, 15);
            labelLanguage.TabIndex = 5;
            labelLanguage.TabStop = true;
            labelLanguage.Text = "EN";
            labelLanguage.LinkClicked += labelLanguage_LinkClicked;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(150, 6);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 4;
            label5.Text = "البحث";
            // 
            // textBoxSearchProducts
            // 
            textBoxSearchProducts.Location = new Point(3, 3);
            textBoxSearchProducts.Name = "textBoxSearchProducts";
            textBoxSearchProducts.Size = new Size(129, 23);
            textBoxSearchProducts.TabIndex = 3;
            textBoxSearchProducts.TextChanged += textBoxSearchProducts_TextChanged;
            // 
            // FormAddSales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1038, 504);
            Controls.Add(panelContainerRight);
            Controls.Add(DGVSales);
            Controls.Add(panel1);
            MaximizeBox = false;
            Name = "FormAddSales";
            RightToLeft = RightToLeft.Yes;
            Text = "عملية بيع";
            Load += FormAddSales_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericProductCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericProductPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVSales).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGVProducts).EndInit();
            panelContainerRight.ResumeLayout(false);
            panelContainerRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView DGVSales;
        private DataGridView DGVProducts;
        private TextBox textBoxAvailableProductCount;
        private TextBox textBoxInvoiceTotalPrice;
        private Label label2;
        private Label label1;
        private NumericUpDown numericProductCount;
        private NumericUpDown numericProductPrice;
        private Button button2;
        private Button button4;
        private Button button3;
        private Button button1;
        private Label label4;
        private Label label3;
        private Panel panelContainerRight;
        private Label label5;
        private TextBox textBoxSearchProducts;
        private DataGridViewTextBoxColumn ProducId;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductCategory;
        private DataGridViewTextBoxColumn ProductCount;
        private DataGridViewTextBoxColumn ProductPrice;
        private DataGridViewTextBoxColumn ProductTotalPrice;
        private DataGridViewTextBoxColumn ProductId;
        private DataGridViewTextBoxColumn ProductNameRight;
        private DataGridViewTextBoxColumn ProductCategoryRight;
        private DataGridViewTextBoxColumn ProductCountRight;
        private DataGridViewTextBoxColumn ProductPriceRight;
        private DataGridViewTextBoxColumn ProductSectionRight;
        private LinkLabel labelLanguage;
    }
}