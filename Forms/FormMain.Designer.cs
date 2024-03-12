namespace APP2EFCore.Forms
{
    partial class FormMain
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelContainer = new Panel();
            panelPurchases = new Panel();
            DGVPurchases = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button2 = new Button();
            panelSales = new Panel();
            DGVSales = new DataGridView();
            panelCategories = new Panel();
            DGVCategories = new DataGridView();
            panelCategoriesButtom = new FlowLayoutPanel();
            button5 = new Button();
            button1 = new Button();
            panelHome = new Panel();
            labelClock = new Label();
            panelHomeUsersCount = new Panel();
            labelHomeUsersCount = new Label();
            label12 = new Label();
            panelHomeCategoriesCount = new Panel();
            labelHomeCategoriesCount = new Label();
            label6 = new Label();
            panelHomeSalesPrice = new Panel();
            labelHomeSalesPrice = new Label();
            label4 = new Label();
            panelHomePurchasesPrice = new Panel();
            labelHomePurchasesPrice = new Label();
            label8 = new Label();
            panelHomeProductsCount = new Panel();
            labelHomeProductsCount = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            buttonHomeSale = new Button();
            buttonHomeCategory = new Button();
            buttonHomeUser = new Button();
            buttonHomePurchase = new Button();
            panelSideBar = new FlowLayoutPanel();
            panel5 = new Panel();
            labelUserName = new Label();
            pictureBox1 = new PictureBox();
            buttonSideHome = new Button();
            buttonSideSales = new Button();
            buttonSidePurchases = new Button();
            buttonSideUsers = new Button();
            buttonSideProducts = new Button();
            buttonSideCategories = new Button();
            buttonSideReports = new Button();
            buttonSideInvoices = new Button();
            buttonSideSettings = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            panelContainer.SuspendLayout();
            panelPurchases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPurchases).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            panelSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVSales).BeginInit();
            panelCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVCategories).BeginInit();
            panelCategoriesButtom.SuspendLayout();
            panelHome.SuspendLayout();
            panelHomeUsersCount.SuspendLayout();
            panelHomeCategoriesCount.SuspendLayout();
            panelHomeSalesPrice.SuspendLayout();
            panelHomePurchasesPrice.SuspendLayout();
            panelHomeProductsCount.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelSideBar.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.Controls.Add(panelPurchases);
            panelContainer.Controls.Add(panelSales);
            panelContainer.Controls.Add(panelCategories);
            panelContainer.Controls.Add(panelHome);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(745, 520);
            panelContainer.TabIndex = 1;
            // 
            // panelPurchases
            // 
            panelPurchases.Controls.Add(DGVPurchases);
            panelPurchases.Controls.Add(flowLayoutPanel2);
            panelPurchases.Dock = DockStyle.Fill;
            panelPurchases.Location = new Point(0, 0);
            panelPurchases.Name = "panelPurchases";
            panelPurchases.Size = new Size(745, 520);
            panelPurchases.TabIndex = 3;
            // 
            // DGVPurchases
            // 
            DGVPurchases.AllowUserToAddRows = false;
            DGVPurchases.AllowUserToDeleteRows = false;
            DGVPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVPurchases.BackgroundColor = Color.White;
            DGVPurchases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPurchases.Dock = DockStyle.Fill;
            DGVPurchases.Location = new Point(0, 0);
            DGVPurchases.Name = "DGVPurchases";
            DGVPurchases.ReadOnly = true;
            DGVPurchases.Size = new Size(745, 477);
            DGVPurchases.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(button2);
            flowLayoutPanel2.Dock = DockStyle.Bottom;
            flowLayoutPanel2.Location = new Point(0, 477);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(745, 43);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // button2
            // 
            button2.AutoEllipsis = true;
            button2.BackColor = Color.Transparent;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft Sans Serif", 10F);
            button2.ForeColor = Color.Black;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(610, 3);
            button2.Name = "button2";
            button2.Size = new Size(132, 35);
            button2.TabIndex = 0;
            button2.Text = "عملية شراء";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panelSales
            // 
            panelSales.Controls.Add(DGVSales);
            panelSales.Dock = DockStyle.Fill;
            panelSales.Location = new Point(0, 0);
            panelSales.Name = "panelSales";
            panelSales.Size = new Size(745, 520);
            panelSales.TabIndex = 2;
            // 
            // DGVSales
            // 
            DGVSales.AllowUserToAddRows = false;
            DGVSales.AllowUserToDeleteRows = false;
            DGVSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVSales.BackgroundColor = Color.White;
            DGVSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVSales.Dock = DockStyle.Fill;
            DGVSales.Location = new Point(0, 0);
            DGVSales.Name = "DGVSales";
            DGVSales.ReadOnly = true;
            DGVSales.Size = new Size(745, 520);
            DGVSales.TabIndex = 1;
            // 
            // panelCategories
            // 
            panelCategories.Controls.Add(DGVCategories);
            panelCategories.Controls.Add(panelCategoriesButtom);
            panelCategories.Dock = DockStyle.Fill;
            panelCategories.Location = new Point(0, 0);
            panelCategories.Name = "panelCategories";
            panelCategories.Size = new Size(745, 520);
            panelCategories.TabIndex = 1;
            // 
            // DGVCategories
            // 
            DGVCategories.AllowUserToAddRows = false;
            DGVCategories.AllowUserToDeleteRows = false;
            DGVCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVCategories.BackgroundColor = Color.White;
            DGVCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVCategories.Dock = DockStyle.Fill;
            DGVCategories.Location = new Point(0, 0);
            DGVCategories.Name = "DGVCategories";
            DGVCategories.ReadOnly = true;
            DGVCategories.Size = new Size(745, 474);
            DGVCategories.TabIndex = 1;
            // 
            // panelCategoriesButtom
            // 
            panelCategoriesButtom.Controls.Add(button5);
            panelCategoriesButtom.Controls.Add(button1);
            panelCategoriesButtom.Dock = DockStyle.Bottom;
            panelCategoriesButtom.Location = new Point(0, 474);
            panelCategoriesButtom.Name = "panelCategoriesButtom";
            panelCategoriesButtom.Size = new Size(745, 46);
            panelCategoriesButtom.TabIndex = 0;
            // 
            // button5
            // 
            button5.AutoEllipsis = true;
            button5.BackColor = Color.Transparent;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Microsoft Sans Serif", 10F);
            button5.ForeColor = Color.Black;
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.ImageAlign = ContentAlignment.MiddleLeft;
            button5.Location = new Point(591, 3);
            button5.Name = "button5";
            button5.Size = new Size(151, 40);
            button5.TabIndex = 0;
            button5.Text = "اضافة صنف";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click_1;
            // 
            // button1
            // 
            button1.AutoEllipsis = true;
            button1.BackColor = Color.Transparent;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 10F);
            button1.ForeColor = Color.Black;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(434, 3);
            button1.Name = "button1";
            button1.Size = new Size(151, 40);
            button1.TabIndex = 0;
            button1.Text = "حذف صنف";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button5_Click;
            // 
            // panelHome
            // 
            panelHome.Controls.Add(labelClock);
            panelHome.Controls.Add(panelHomeUsersCount);
            panelHome.Controls.Add(panelHomeCategoriesCount);
            panelHome.Controls.Add(panelHomeSalesPrice);
            panelHome.Controls.Add(panelHomePurchasesPrice);
            panelHome.Controls.Add(panelHomeProductsCount);
            panelHome.Controls.Add(flowLayoutPanel1);
            panelHome.Dock = DockStyle.Fill;
            panelHome.Location = new Point(0, 0);
            panelHome.Name = "panelHome";
            panelHome.Size = new Size(745, 520);
            panelHome.TabIndex = 0;
            // 
            // labelClock
            // 
            labelClock.AutoSize = true;
            labelClock.Font = new Font("MV Boli", 12F);
            labelClock.ForeColor = Color.Blue;
            labelClock.Location = new Point(610, 9);
            labelClock.Name = "labelClock";
            labelClock.RightToLeft = RightToLeft.Yes;
            labelClock.Size = new Size(117, 21);
            labelClock.TabIndex = 0;
            labelClock.Text = "12:00:00 AM";
            // 
            // panelHomeUsersCount
            // 
            panelHomeUsersCount.Anchor = AnchorStyles.None;
            panelHomeUsersCount.BackColor = Color.CornflowerBlue;
            panelHomeUsersCount.Controls.Add(labelHomeUsersCount);
            panelHomeUsersCount.Controls.Add(label12);
            panelHomeUsersCount.Location = new Point(161, 247);
            panelHomeUsersCount.Name = "panelHomeUsersCount";
            panelHomeUsersCount.Size = new Size(189, 153);
            panelHomeUsersCount.TabIndex = 1;
            // 
            // labelHomeUsersCount
            // 
            labelHomeUsersCount.AutoSize = true;
            labelHomeUsersCount.Font = new Font("Myanmar Text", 17F);
            labelHomeUsersCount.ForeColor = Color.White;
            labelHomeUsersCount.Location = new Point(80, 86);
            labelHomeUsersCount.Name = "labelHomeUsersCount";
            labelHomeUsersCount.Size = new Size(30, 41);
            labelHomeUsersCount.TabIndex = 0;
            labelHomeUsersCount.Text = "0";
            labelHomeUsersCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("MV Boli", 17F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(-1, 14);
            label12.Name = "label12";
            label12.Size = new Size(193, 29);
            label12.TabIndex = 0;
            label12.Text = "عدد الموظفين في المتجر";
            // 
            // panelHomeCategoriesCount
            // 
            panelHomeCategoriesCount.Anchor = AnchorStyles.None;
            panelHomeCategoriesCount.BackColor = Color.CornflowerBlue;
            panelHomeCategoriesCount.Controls.Add(labelHomeCategoriesCount);
            panelHomeCategoriesCount.Controls.Add(label6);
            panelHomeCategoriesCount.Location = new Point(43, 53);
            panelHomeCategoriesCount.Name = "panelHomeCategoriesCount";
            panelHomeCategoriesCount.Size = new Size(189, 153);
            panelHomeCategoriesCount.TabIndex = 1;
            // 
            // labelHomeCategoriesCount
            // 
            labelHomeCategoriesCount.AutoSize = true;
            labelHomeCategoriesCount.Font = new Font("Myanmar Text", 17F);
            labelHomeCategoriesCount.ForeColor = Color.White;
            labelHomeCategoriesCount.Location = new Point(80, 86);
            labelHomeCategoriesCount.Name = "labelHomeCategoriesCount";
            labelHomeCategoriesCount.Size = new Size(30, 41);
            labelHomeCategoriesCount.TabIndex = 0;
            labelHomeCategoriesCount.Text = "0";
            labelHomeCategoriesCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("MV Boli", 17F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(-1, 14);
            label6.Name = "label6";
            label6.Size = new Size(193, 29);
            label6.TabIndex = 0;
            label6.Text = "عدد الاصناف في المتجر";
            // 
            // panelHomeSalesPrice
            // 
            panelHomeSalesPrice.Anchor = AnchorStyles.None;
            panelHomeSalesPrice.BackColor = Color.CornflowerBlue;
            panelHomeSalesPrice.Controls.Add(labelHomeSalesPrice);
            panelHomeSalesPrice.Controls.Add(label4);
            panelHomeSalesPrice.Location = new Point(277, 53);
            panelHomeSalesPrice.Name = "panelHomeSalesPrice";
            panelHomeSalesPrice.Size = new Size(189, 153);
            panelHomeSalesPrice.TabIndex = 1;
            // 
            // labelHomeSalesPrice
            // 
            labelHomeSalesPrice.AutoSize = true;
            labelHomeSalesPrice.Font = new Font("Myanmar Text", 17F);
            labelHomeSalesPrice.ForeColor = Color.White;
            labelHomeSalesPrice.Location = new Point(80, 86);
            labelHomeSalesPrice.Name = "labelHomeSalesPrice";
            labelHomeSalesPrice.Size = new Size(30, 41);
            labelHomeSalesPrice.TabIndex = 0;
            labelHomeSalesPrice.Text = "0";
            labelHomeSalesPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MV Boli", 17F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(-1, 14);
            label4.Name = "label4";
            label4.Size = new Size(189, 29);
            label4.TabIndex = 0;
            label4.Text = "سعر المبيعات هذا الشهر";
            // 
            // panelHomePurchasesPrice
            // 
            panelHomePurchasesPrice.Anchor = AnchorStyles.None;
            panelHomePurchasesPrice.BackColor = Color.CornflowerBlue;
            panelHomePurchasesPrice.Controls.Add(labelHomePurchasesPrice);
            panelHomePurchasesPrice.Controls.Add(label8);
            panelHomePurchasesPrice.Location = new Point(394, 247);
            panelHomePurchasesPrice.Name = "panelHomePurchasesPrice";
            panelHomePurchasesPrice.Size = new Size(189, 153);
            panelHomePurchasesPrice.TabIndex = 1;
            // 
            // labelHomePurchasesPrice
            // 
            labelHomePurchasesPrice.AutoSize = true;
            labelHomePurchasesPrice.Font = new Font("Myanmar Text", 17F);
            labelHomePurchasesPrice.ForeColor = Color.White;
            labelHomePurchasesPrice.Location = new Point(80, 86);
            labelHomePurchasesPrice.Name = "labelHomePurchasesPrice";
            labelHomePurchasesPrice.Size = new Size(30, 41);
            labelHomePurchasesPrice.TabIndex = 0;
            labelHomePurchasesPrice.Text = "0";
            labelHomePurchasesPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("MV Boli", 17F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(-7, 14);
            label8.Name = "label8";
            label8.Size = new Size(203, 29);
            label8.TabIndex = 0;
            label8.Text = "سعر المشتريات هذا الشهر";
            // 
            // panelHomeProductsCount
            // 
            panelHomeProductsCount.Anchor = AnchorStyles.None;
            panelHomeProductsCount.BackColor = Color.CornflowerBlue;
            panelHomeProductsCount.Controls.Add(labelHomeProductsCount);
            panelHomeProductsCount.Controls.Add(label1);
            panelHomeProductsCount.Location = new Point(511, 53);
            panelHomeProductsCount.Name = "panelHomeProductsCount";
            panelHomeProductsCount.Size = new Size(189, 153);
            panelHomeProductsCount.TabIndex = 1;
            // 
            // labelHomeProductsCount
            // 
            labelHomeProductsCount.AutoSize = true;
            labelHomeProductsCount.Font = new Font("Myanmar Text", 17F);
            labelHomeProductsCount.ForeColor = Color.White;
            labelHomeProductsCount.Location = new Point(79, 86);
            labelHomeProductsCount.Name = "labelHomeProductsCount";
            labelHomeProductsCount.Size = new Size(30, 41);
            labelHomeProductsCount.TabIndex = 0;
            labelHomeProductsCount.Text = "0";
            labelHomeProductsCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MV Boli", 17F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(-1, 14);
            label1.Name = "label1";
            label1.Size = new Size(191, 29);
            label1.TabIndex = 0;
            label1.Text = "عدد المنتجات في المتجر";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(buttonHomeSale);
            flowLayoutPanel1.Controls.Add(buttonHomeCategory);
            flowLayoutPanel1.Controls.Add(buttonHomeUser);
            flowLayoutPanel1.Controls.Add(buttonHomePurchase);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 454);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(745, 66);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonHomeSale
            // 
            buttonHomeSale.AutoEllipsis = true;
            buttonHomeSale.BackColor = Color.Transparent;
            buttonHomeSale.FlatAppearance.BorderSize = 0;
            buttonHomeSale.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            buttonHomeSale.FlatStyle = FlatStyle.Flat;
            buttonHomeSale.Font = new Font("Microsoft Sans Serif", 10F);
            buttonHomeSale.Image = (Image)resources.GetObject("buttonHomeSale.Image");
            buttonHomeSale.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHomeSale.Location = new Point(593, 3);
            buttonHomeSale.Name = "buttonHomeSale";
            buttonHomeSale.Size = new Size(149, 60);
            buttonHomeSale.TabIndex = 0;
            buttonHomeSale.Text = "عملية بيع";
            buttonHomeSale.UseVisualStyleBackColor = false;
            // 
            // buttonHomeCategory
            // 
            buttonHomeCategory.AutoEllipsis = true;
            buttonHomeCategory.BackColor = Color.Transparent;
            buttonHomeCategory.FlatAppearance.BorderSize = 0;
            buttonHomeCategory.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            buttonHomeCategory.FlatStyle = FlatStyle.Flat;
            buttonHomeCategory.Font = new Font("Microsoft Sans Serif", 10F);
            buttonHomeCategory.Image = (Image)resources.GetObject("buttonHomeCategory.Image");
            buttonHomeCategory.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHomeCategory.Location = new Point(438, 3);
            buttonHomeCategory.Name = "buttonHomeCategory";
            buttonHomeCategory.Size = new Size(149, 60);
            buttonHomeCategory.TabIndex = 0;
            buttonHomeCategory.Text = "اضافة صنف";
            buttonHomeCategory.UseVisualStyleBackColor = false;
            // 
            // buttonHomeUser
            // 
            buttonHomeUser.AutoEllipsis = true;
            buttonHomeUser.BackColor = Color.Transparent;
            buttonHomeUser.FlatAppearance.BorderSize = 0;
            buttonHomeUser.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            buttonHomeUser.FlatStyle = FlatStyle.Flat;
            buttonHomeUser.Font = new Font("Microsoft Sans Serif", 10F);
            buttonHomeUser.Image = (Image)resources.GetObject("buttonHomeUser.Image");
            buttonHomeUser.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHomeUser.Location = new Point(283, 3);
            buttonHomeUser.Name = "buttonHomeUser";
            buttonHomeUser.Size = new Size(149, 60);
            buttonHomeUser.TabIndex = 0;
            buttonHomeUser.Text = "اضافة بائع";
            buttonHomeUser.UseVisualStyleBackColor = false;
            // 
            // buttonHomePurchase
            // 
            buttonHomePurchase.AutoEllipsis = true;
            buttonHomePurchase.BackColor = Color.Transparent;
            buttonHomePurchase.FlatAppearance.BorderSize = 0;
            buttonHomePurchase.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 128, 255);
            buttonHomePurchase.FlatStyle = FlatStyle.Flat;
            buttonHomePurchase.Font = new Font("Microsoft Sans Serif", 10F);
            buttonHomePurchase.Image = (Image)resources.GetObject("buttonHomePurchase.Image");
            buttonHomePurchase.ImageAlign = ContentAlignment.MiddleLeft;
            buttonHomePurchase.Location = new Point(128, 3);
            buttonHomePurchase.Name = "buttonHomePurchase";
            buttonHomePurchase.Size = new Size(149, 60);
            buttonHomePurchase.TabIndex = 0;
            buttonHomePurchase.Text = "عملية شراء";
            buttonHomePurchase.UseVisualStyleBackColor = false;
            // 
            // panelSideBar
            // 
            panelSideBar.BackColor = Color.FromArgb(45, 45, 45);
            panelSideBar.Controls.Add(panel5);
            panelSideBar.Controls.Add(buttonSideHome);
            panelSideBar.Controls.Add(buttonSideSales);
            panelSideBar.Controls.Add(buttonSidePurchases);
            panelSideBar.Controls.Add(buttonSideUsers);
            panelSideBar.Controls.Add(buttonSideProducts);
            panelSideBar.Controls.Add(buttonSideCategories);
            panelSideBar.Controls.Add(buttonSideReports);
            panelSideBar.Controls.Add(buttonSideInvoices);
            panelSideBar.Controls.Add(buttonSideSettings);
            panelSideBar.Dock = DockStyle.Right;
            panelSideBar.Location = new Point(745, 0);
            panelSideBar.Name = "panelSideBar";
            panelSideBar.Size = new Size(141, 520);
            panelSideBar.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(labelUserName);
            panel5.Controls.Add(pictureBox1);
            panel5.Location = new Point(6, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(132, 137);
            panel5.TabIndex = 1;
            // 
            // labelUserName
            // 
            labelUserName.AutoSize = true;
            labelUserName.Font = new Font("MV Boli", 12F);
            labelUserName.ForeColor = Color.Cyan;
            labelUserName.Location = new Point(0, 113);
            labelUserName.Name = "labelUserName";
            labelUserName.RightToLeft = RightToLeft.Yes;
            labelUserName.Size = new Size(75, 21);
            labelUserName.TabIndex = 0;
            labelUserName.Text = "اسم المستخدم";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(123, 107);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonSideHome
            // 
            buttonSideHome.AutoEllipsis = true;
            buttonSideHome.BackColor = Color.Transparent;
            buttonSideHome.FlatAppearance.BorderSize = 0;
            buttonSideHome.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideHome.FlatStyle = FlatStyle.Flat;
            buttonSideHome.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideHome.ForeColor = Color.Cyan;
            buttonSideHome.Image = (Image)resources.GetObject("buttonSideHome.Image");
            buttonSideHome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideHome.Location = new Point(-13, 146);
            buttonSideHome.Name = "buttonSideHome";
            buttonSideHome.Size = new Size(151, 35);
            buttonSideHome.TabIndex = 0;
            buttonSideHome.Text = "الصفحة الرئيسية";
            buttonSideHome.UseVisualStyleBackColor = false;
            buttonSideHome.Click += buttonSideHome_Click;
            // 
            // buttonSideSales
            // 
            buttonSideSales.AutoEllipsis = true;
            buttonSideSales.BackColor = Color.Transparent;
            buttonSideSales.FlatAppearance.BorderSize = 0;
            buttonSideSales.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideSales.FlatStyle = FlatStyle.Flat;
            buttonSideSales.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideSales.ForeColor = Color.Cyan;
            buttonSideSales.Image = (Image)resources.GetObject("buttonSideSales.Image");
            buttonSideSales.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideSales.Location = new Point(-13, 187);
            buttonSideSales.Name = "buttonSideSales";
            buttonSideSales.Size = new Size(151, 35);
            buttonSideSales.TabIndex = 0;
            buttonSideSales.Text = "المبيعات";
            buttonSideSales.UseVisualStyleBackColor = false;
            buttonSideSales.Click += buttonSideSales_Click;
            // 
            // buttonSidePurchases
            // 
            buttonSidePurchases.AutoEllipsis = true;
            buttonSidePurchases.BackColor = Color.Transparent;
            buttonSidePurchases.FlatAppearance.BorderSize = 0;
            buttonSidePurchases.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSidePurchases.FlatStyle = FlatStyle.Flat;
            buttonSidePurchases.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSidePurchases.ForeColor = Color.Cyan;
            buttonSidePurchases.Image = (Image)resources.GetObject("buttonSidePurchases.Image");
            buttonSidePurchases.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSidePurchases.Location = new Point(-13, 228);
            buttonSidePurchases.Name = "buttonSidePurchases";
            buttonSidePurchases.Size = new Size(151, 35);
            buttonSidePurchases.TabIndex = 0;
            buttonSidePurchases.Text = "المشتريات";
            buttonSidePurchases.UseVisualStyleBackColor = false;
            buttonSidePurchases.Click += buttonSidePurchases_Click;
            // 
            // buttonSideUsers
            // 
            buttonSideUsers.AutoEllipsis = true;
            buttonSideUsers.BackColor = Color.Transparent;
            buttonSideUsers.FlatAppearance.BorderSize = 0;
            buttonSideUsers.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideUsers.FlatStyle = FlatStyle.Flat;
            buttonSideUsers.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideUsers.ForeColor = Color.Cyan;
            buttonSideUsers.Image = (Image)resources.GetObject("buttonSideUsers.Image");
            buttonSideUsers.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideUsers.Location = new Point(-13, 269);
            buttonSideUsers.Name = "buttonSideUsers";
            buttonSideUsers.Size = new Size(151, 35);
            buttonSideUsers.TabIndex = 0;
            buttonSideUsers.Text = "البائعين";
            buttonSideUsers.UseVisualStyleBackColor = false;
            // 
            // buttonSideProducts
            // 
            buttonSideProducts.AutoEllipsis = true;
            buttonSideProducts.BackColor = Color.Transparent;
            buttonSideProducts.FlatAppearance.BorderSize = 0;
            buttonSideProducts.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideProducts.FlatStyle = FlatStyle.Flat;
            buttonSideProducts.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideProducts.ForeColor = Color.Cyan;
            buttonSideProducts.Image = (Image)resources.GetObject("buttonSideProducts.Image");
            buttonSideProducts.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideProducts.Location = new Point(-13, 310);
            buttonSideProducts.Name = "buttonSideProducts";
            buttonSideProducts.Size = new Size(151, 35);
            buttonSideProducts.TabIndex = 0;
            buttonSideProducts.Text = "المنتجات";
            buttonSideProducts.UseVisualStyleBackColor = false;
            // 
            // buttonSideCategories
            // 
            buttonSideCategories.AutoEllipsis = true;
            buttonSideCategories.BackColor = Color.Transparent;
            buttonSideCategories.FlatAppearance.BorderSize = 0;
            buttonSideCategories.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideCategories.FlatStyle = FlatStyle.Flat;
            buttonSideCategories.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideCategories.ForeColor = Color.Cyan;
            buttonSideCategories.Image = (Image)resources.GetObject("buttonSideCategories.Image");
            buttonSideCategories.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideCategories.Location = new Point(-13, 351);
            buttonSideCategories.Name = "buttonSideCategories";
            buttonSideCategories.Size = new Size(151, 35);
            buttonSideCategories.TabIndex = 0;
            buttonSideCategories.Text = "الاصناف";
            buttonSideCategories.UseVisualStyleBackColor = false;
            buttonSideCategories.Click += buttonSideCategories_Click;
            // 
            // buttonSideReports
            // 
            buttonSideReports.AutoEllipsis = true;
            buttonSideReports.BackColor = Color.Transparent;
            buttonSideReports.FlatAppearance.BorderSize = 0;
            buttonSideReports.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideReports.FlatStyle = FlatStyle.Flat;
            buttonSideReports.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideReports.ForeColor = Color.Cyan;
            buttonSideReports.Image = (Image)resources.GetObject("buttonSideReports.Image");
            buttonSideReports.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideReports.Location = new Point(-13, 392);
            buttonSideReports.Name = "buttonSideReports";
            buttonSideReports.Size = new Size(151, 35);
            buttonSideReports.TabIndex = 0;
            buttonSideReports.Text = "التقارير";
            buttonSideReports.UseVisualStyleBackColor = false;
            // 
            // buttonSideInvoices
            // 
            buttonSideInvoices.AutoEllipsis = true;
            buttonSideInvoices.BackColor = Color.Transparent;
            buttonSideInvoices.FlatAppearance.BorderSize = 0;
            buttonSideInvoices.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideInvoices.FlatStyle = FlatStyle.Flat;
            buttonSideInvoices.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideInvoices.ForeColor = Color.Cyan;
            buttonSideInvoices.Image = (Image)resources.GetObject("buttonSideInvoices.Image");
            buttonSideInvoices.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideInvoices.Location = new Point(-13, 433);
            buttonSideInvoices.Name = "buttonSideInvoices";
            buttonSideInvoices.Size = new Size(151, 35);
            buttonSideInvoices.TabIndex = 0;
            buttonSideInvoices.Text = "الفواتير";
            buttonSideInvoices.UseVisualStyleBackColor = false;
            // 
            // buttonSideSettings
            // 
            buttonSideSettings.AutoEllipsis = true;
            buttonSideSettings.BackColor = Color.Transparent;
            buttonSideSettings.FlatAppearance.BorderSize = 0;
            buttonSideSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(45, 45, 45);
            buttonSideSettings.FlatStyle = FlatStyle.Flat;
            buttonSideSettings.Font = new Font("Microsoft Sans Serif", 10F);
            buttonSideSettings.ForeColor = Color.Cyan;
            buttonSideSettings.Image = (Image)resources.GetObject("buttonSideSettings.Image");
            buttonSideSettings.ImageAlign = ContentAlignment.MiddleLeft;
            buttonSideSettings.Location = new Point(-13, 474);
            buttonSideSettings.Name = "buttonSideSettings";
            buttonSideSettings.Size = new Size(151, 35);
            buttonSideSettings.TabIndex = 0;
            buttonSideSettings.Text = "الاعدادات";
            buttonSideSettings.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(886, 520);
            Controls.Add(panelContainer);
            Controls.Add(panelSideBar);
            Name = "FormMain";
            RightToLeft = RightToLeft.Yes;
            ShowIcon = false;
            Text = "الصفحة الرئيسية";
            Load += FormMain_Load;
            panelContainer.ResumeLayout(false);
            panelPurchases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVPurchases).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            panelSales.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVSales).EndInit();
            panelCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVCategories).EndInit();
            panelCategoriesButtom.ResumeLayout(false);
            panelHome.ResumeLayout(false);
            panelHome.PerformLayout();
            panelHomeUsersCount.ResumeLayout(false);
            panelHomeUsersCount.PerformLayout();
            panelHomeCategoriesCount.ResumeLayout(false);
            panelHomeCategoriesCount.PerformLayout();
            panelHomeSalesPrice.ResumeLayout(false);
            panelHomeSalesPrice.PerformLayout();
            panelHomePurchasesPrice.ResumeLayout(false);
            panelHomePurchasesPrice.PerformLayout();
            panelHomeProductsCount.ResumeLayout(false);
            panelHomeProductsCount.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panelSideBar.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panelContainer;
        private Panel panelHome;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panelHomeUsersCount;
        private Label labelHomeUsersCount;
        private Label label12;
        private Panel panelHomeCategoriesCount;
        private Label labelHomeCategoriesCount;
        private Label label6;
        private Panel panelHomeSalesPrice;
        private Label labelHomeSalesPrice;
        private Label label4;
        private Panel panelHomePurchasesPrice;
        private Label labelHomePurchasesPrice;
        private Label label8;
        private Panel panelHomeProductsCount;
        private Label labelHomeProductsCount;
        private Label label1;
        private FlowLayoutPanel panelSideBar;
        private Button buttonHomeSale;
        private Button buttonHomeCategory;
        private Button buttonHomeUser;
        private Button buttonHomePurchase;
        private PictureBox pictureBox1;
        private Label labelUserName;
        private Button button5;
        private Button buttonSideSales;
        private Button buttonSidePurchases;
        private Button buttonSideUsers;
        private Button buttonSideProducts;
        private Button buttonSideCategories;
        private Button buttonSideReports;
        private Button buttonSideInvoices;
        private Button buttonSideSettings;
        private Panel panel5;
        private Label labelClock;
        private System.Windows.Forms.Timer timer1;
        private Panel panelCategories;
        private DataGridView DGVCategories;
        private FlowLayoutPanel panelCategoriesButtom;
        private Button button1;
        private Button buttonSideHome;
        private Panel panelSales;
        private DataGridView DGVSales;
        private Panel panelPurchases;
        private DataGridView DGVPurchases;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button button2;
    }
}