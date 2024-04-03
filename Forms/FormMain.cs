using APP2EFCore.Categories;
using APP2EFCore.Enums;
using APP2EFCore.Invoices;
using APP2EFCore.Products;
using APP2EFCore.Properties;
using APP2EFCore.Purchases;
using APP2EFCore.Sales;
using APP2EFCore.Users;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace APP2EFCore.Forms
{
    public partial class FormMain : Form
    {
        PageState pageState;
        FormLogin formLogin;
        public FormMain(FormLogin formLogin)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            Settings.Default.CurrentUserType = UserTypes.admin.ToString();
        }
        private async Task ShowHomePage()
        {
            progressBarWait.Visible = true;

            pageState = PageState.home;

            await Task.Run(async () =>
            {


                using AppDBContext db = new();
                decimal sumPurchasesPriceMonth = await db.Purchases.Where(x => x.Date.Month == DateTime.Now.Month).SumAsync(x => x.ProductsTotalPrice);

                decimal sumSalesPriceMonth = await db.Sales.Where(x => x.Date.Month == DateTime.Now.Month).SumAsync(x => x.ProductsTotalPrice);

                int usersCount = await db.Users.Where(x => x.Type == UserTypes.casher).CountAsync();

                Invoke(new Action(() =>
                {
                    UpdateLabel(labelHomePurchasesPrice, sumPurchasesPriceMonth, "ل.س");
                    UpdateLabel(labelHomeSalesPrice, sumSalesPriceMonth, "ل.س");
                    UpdateLabel(labelHomeCategoriesCount, db.Categories.Count());
                    UpdateLabel(labelHomeProductsCount, db.Products.Count());
                    UpdateLabel(labelHomeUsersCount, usersCount);

                    progressBarWait.Visible = false;
                }));

            });
        }

        private void UpdateLabel(Label label, decimal value, string unit = "")
        {
            label.Text = value + " " + unit;
        }

        private async Task ShowCategoriesPage()
        {
            progressBarWait.Visible = true;

            var categories = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Categories.Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.ProductsCount
                }).ToList();
            });

            DGVCategories.DataSource = categories;
            DGVCategories.Columns["Id"].Visible = false;
            DGVCategories.Columns["Name"].HeaderText = "اسم الصنف";
            DGVCategories.Columns["ProductsCount"].HeaderText = "عدد المنتجات";

            progressBarWait.Visible = false;
        }

        private async Task ShowSalesPage()
        {
            progressBarWait.Visible = true;

            var sales = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Sales.Select(s => new
                {
                    s.Id,
                    s.Product.Name,
                    CategoryName = s.Product.Category.Name,
                    s.ProductsCount,
                    s.ProductPrice,
                    s.ProductsTotalPrice,
                    InvoiceId = s.Invoice.Id,
                    s.Date,
                    UserName = s.User.Name
                }).ToList();
            });

            DGVSales.DataSource = sales;
            DGVSales.Columns[0].Visible = false;
            DGVSales.Columns[1].HeaderText = "اسم المنتج";
            DGVSales.Columns[2].HeaderText = "الصنف";
            DGVSales.Columns[3].HeaderText = "الكمية";
            DGVSales.Columns[4].HeaderText = "السعر";
            DGVSales.Columns[5].HeaderText = "السعر الاجمالي";
            DGVSales.Columns[6].HeaderText = "رقم الفاتورة";
            DGVSales.Columns[7].HeaderText = "تاريخ البيع";
            DGVSales.Columns[8].HeaderText = "اسم البائع";

            progressBarWait.Visible = false;
        }

        private async Task ShowPurchasesPage()
        {
            progressBarWait.Visible = true;

            List<object> purchases = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Purchases.Select(p => new
                {
                    p.Id,
                    ProductName = p.Product.Name,
                    CategoryName = p.Product.Category.Name,
                    p.ProductsCount,
                    p.ProductPrice,
                    p.ProductsTotalPrice,
                    InvoiceId = p.Invoice.Id,
                    p.Date
                }).ToList<object>();
            });

            DGVPurchases.DataSource = purchases;
            DGVPurchases.Columns[0].Visible = false;
            DGVPurchases.Columns[1].HeaderText = "اسم المنتج";
            DGVPurchases.Columns[2].HeaderText = "الصنف";
            DGVPurchases.Columns[3].HeaderText = "الكمية";
            DGVPurchases.Columns[4].HeaderText = "سعر المنتج";
            DGVPurchases.Columns[5].HeaderText = "السعر الاجمالي";
            DGVPurchases.Columns[6].HeaderText = "رقم الفاتورة";
            DGVPurchases.Columns[7].HeaderText = "تاريخ الشراء";
            progressBarWait.Visible = false;
        }

        private async Task ShowUsersPage()
        {
            progressBarWait.Visible = true;

            var users = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Users.Where(u => u.Type == UserTypes.casher).Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email
                }).ToList();
            });

            DGVUsers.DataSource = users;
            DGVUsers.Columns[0].Visible = false;
            DGVUsers.Columns[1].HeaderText = "اسم البائع";
            DGVUsers.Columns[2].HeaderText = "البريد الالكتروني";

            progressBarWait.Visible = false;

        }

        private async Task ShowProductsPage()
        {
            progressBarWait.Visible = true;

            var products = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Products.Select(p => new
                {
                    p.Id,
                    p.Name,
                    CategoryName = p.Category.Name,
                    p.Price,
                    p.Count,
                }).ToList();
            });

            DGVProducts.DataSource = products;
            DGVProducts.Columns[0].Visible = false;
            DGVProducts.Columns[1].HeaderText = "اسم المنتج";
            DGVProducts.Columns[2].HeaderText = "الصنف";
            DGVProducts.Columns[3].HeaderText = "السعر";
            DGVProducts.Columns[4].HeaderText = "الكمية";

            progressBarWait.Visible = false;

        }

        private async Task GetUsersName()
        {
            progressBarWait.Visible = true;

            var users = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Users.Where(u => u.Type == UserTypes.casher).Select(u => new
                {
                    u.Id,
                    u.Name,
                }).ToList();
            });

            comboBoxUserName.DataSource = users;
            comboBoxUserName.DisplayMember = "Name";
            comboBoxUserName.ValueMember = "Id";

            progressBarWait.Visible = false;

        }

        private async Task ShowReportPage()
        {
            progressBarWait.Visible = true;

            DateTime startDate = dateTimePickerFrom.Value.Date;
            DateTime endDate = dateTimePickerTo.Value.Date;

            try
            {
                var salesBetweenDates = await Task.Run(() =>
                {
                    using AppDBContext db = new();
                    return db.Sales
                    .Where(s => s.Date.Date >= startDate && s.Date.Date <= endDate);
                });

                if (!checkBoxAllUsers.Checked)
                {
                    int userId = Convert.ToInt32(comboBoxUserName.SelectedValue);
                    salesBetweenDates = salesBetweenDates.Where(s => s.User.Id == userId);
                }

                var reportData = salesBetweenDates.Select(s => new
                {
                    s.Id,
                    ProductName = s.Product.Name,
                    CategoryName = s.Product.Category.Name,
                    s.ProductsCount,
                    s.ProductPrice,
                    s.ProductsTotalPrice,
                    InvoiceId = s.Invoice.Id,
                    s.Date,
                    UserName = s.User.Name
                }).ToList();

                DGVReports.DataSource = reportData;
                DGVReports.Columns[0].Visible = false;
                DGVReports.Columns[1].HeaderText = "اسم المنتج";
                DGVReports.Columns[2].HeaderText = "الصنف";
                DGVReports.Columns[3].HeaderText = "الكمية";
                DGVReports.Columns[4].HeaderText = "السعر";
                DGVReports.Columns[5].HeaderText = "السعر الاجمالي";
                DGVReports.Columns[6].HeaderText = "رقم الفاتورة";
                DGVReports.Columns[7].HeaderText = "تاريخ البيع";
                DGVReports.Columns[8].HeaderText = "اسم البائع";

                textBoxTotalSalesPrice.Text = reportData.Sum(s => s.ProductsTotalPrice).ToString();
                progressBarWait.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async Task ShowInvoicesPage()
        {
            progressBarWait.Visible = true;

            var invoices = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Invoices.Select(i => new
                {
                    i.Id,
                    i.Type,
                    i.Total,
                    i.Date
                }).ToList();
            });

            DGVInvoices.DataSource = invoices;

            progressBarWait.Visible = false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            labelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            if (DGVCategories.CurrentRow is null) return;

            int id = Convert.ToInt32(DGVCategories.CurrentRow.Cells[0].Value);
            using AppDBContext db = new();
            Category? category = await db.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) { return; }
            if (MessageBox.Show("هل حقا تريد حذف صنف " + category.Name + " ?\n لا يمكن استرجاع البيانات , سيتم حذف جميع البيانات المرتبطة", "اجراء حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                Task task = ShowCategoriesPage();
                await task;
            }
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            if (Settings.Default.CurrentUserType != UserTypes.admin.ToString())
            {
                //Side bar
                buttonSideSales.Visible = false;
                buttonSidePurchases.Visible = false;
                buttonSideUsers.Visible = false;
                buttonSideReports.Visible = false;
                buttonSideInvoices.Visible = false;

                //Home page
                panelHomeUsersCount.Visible = false;
                panelHomePurchasesPrice.Visible = false;
                panelHomeSalesPrice.Visible = false;
                buttonHomeCategory.Visible = false;
                buttonHomeUser.Visible = false;
                buttonHomePurchase.Visible = false;

                //Category page
                panelCategoriesButtom.Visible = false;

                //Sales page
                panelSalesButtom.Visible = false;

                //Settings page
                panelSettingsProfitRatio.Visible = false;

            }
            else
            {
                //Home page
                buttonHomeSale.Visible = false;

            }
            string userName = Settings.Default.CurrentUserName;
            labelUserName.Text = string.IsNullOrWhiteSpace(userName) ? "UserName" : userName;

            Task task = ShowHomePage();
            await task;

            dateTimePickerTo.MaxDate = DateTime.Now;
            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;
        }

        private async void buttonSideCategories_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.categories) return;

            pageState = PageState.categories;
            this.Text = "الاصناف";
            panelCategories.BringToFront();
            Task task = ShowCategoriesPage();
            await task;
        }

        private async void buttonSideHome_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.home) return;

            panelHome.BringToFront();

            progressBarWait.Visible = true;
            Task homePageTask = ShowHomePage();
            await homePageTask;
            progressBarWait.Visible = false;
            this.Text = "الصفحة الرئيسية";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FormAddCategory formAddCategory = new();
            formAddCategory.ShowDialog();
        }

        private async void buttonSideSales_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.sales) return;

            pageState = PageState.sales;
            this.Text = "المبيعات";
            panelSales.BringToFront();
            Task salesPageTask = ShowSalesPage();
            await salesPageTask;
        }

        private async void buttonSidePurchases_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.purchases) return;

            panelPurchases.BringToFront();
            pageState = PageState.purchases;
            this.Text = "المشتريات";
            Task purchasesPageTask = ShowPurchasesPage();
            await purchasesPageTask;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            FormAddPurchases formAddPurchases = new();
            formAddPurchases.ShowDialog();

            Task purchasesPageTask = ShowPurchasesPage();
            await purchasesPageTask;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (DGVCategories.CurrentRow is null) return;

            using AppDBContext db = new();
            int categoryId = Convert.ToInt32(DGVCategories.CurrentRow.Cells[0].Value);
            Category? category = await db.Categories.Include(c => c.Products)
                                .FirstOrDefaultAsync(c => c.Id == categoryId);
            if (category == null) { return; }
            FormShowProducts formShowProducts = new(category);
            formShowProducts.ShowDialog();
        }

        private async void buttonSideProducts_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.products) return;

            panelProducts.BringToFront();
            pageState = PageState.products;
            this.Text = "المنتجات";
            Task task = ShowProductsPage();
            await task;
        }

        private async void buttonSideUsers_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.user) return;

            panelUsers.BringToFront();
            pageState = PageState.user;
            this.Text = "البائعين";
            Task task = ShowUsersPage();
            await task;
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new();
            formAddUser.ShowDialog();

            Task task = ShowUsersPage();
            await task;
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (DGVUsers.CurrentRow is null)
                return;

            int userId = Convert.ToInt32(DGVUsers.CurrentRow.Cells[0].Value);
            using AppDBContext db = new();
            User? user = await db.Users.FindAsync(userId);
            if (user is null) return;
            if (MessageBox.Show("هل حقا تريد حذف البائع " + user.Name + " لا يمكن استرجاع البيانات, ", "اجراء حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                Task task = ShowUsersPage();
                await task;
            }

        }

        private async void button8_Click(object sender, EventArgs e)
        {
            if (DGVUsers.CurrentRow is null) return;

            using AppDBContext db = new();
            int userId = Convert.ToInt32(DGVUsers.CurrentRow.Cells[0].Value);
            User? user = await db.Users.FindAsync(userId);
            if (user is null) return;
            FormEditUser formEditUser = new(user, db);
            formEditUser.ShowDialog();

            Task task = ShowUsersPage();
            await task;
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (DGVUsers.CurrentRow is null) return;

            using AppDBContext db = new();

            int productId = Convert.ToInt32(DGVProducts.CurrentRow.Cells[0].Value);
            Product? product = await db.Products.Include(p => p.Category)
                            .FirstOrDefaultAsync(p => p.Id == productId);
            if (product is null) return;
            FormEditProduct formEditProduct = new(product);
            formEditProduct.ShowDialog();

            Task task = ShowProductsPage();
            await task;
        }

        private async void buttonSideReports_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.reports) return;

            pageState = PageState.reports;
            this.Text = "التقارير";
            panelReports.BringToFront();

            Task task = GetUsersName();
            await task;
        }

        private async void comboBoxUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pageState != PageState.reports) return;

            Task task = ShowReportPage();
            await task;
        }

        private async void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (pageState != PageState.reports) return;

            Task task = ShowReportPage();
            await task;
        }

        private async void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (pageState != PageState.reports) return;

            Task task = ShowReportPage();
            await task;

            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;
        }

        private async void checkBoxAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (pageState != PageState.reports) return;

            Task task = ShowReportPage();
            await task;
        }

        private async void buttonSideInvoices_Click(object sender, EventArgs e)
        {
            if (pageState == PageState.invoices) return;

            panelInvoices.BringToFront();
            pageState = PageState.invoices;
            this.Text = "الفواتير";

            Task task = ShowInvoicesPage();
            await task;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (DGVInvoices.CurrentRow is null) return;

            int invoiceId = Convert.ToInt32(DGVInvoices.CurrentRow.Cells[0].Value);
            FormInvoiceInfo formInvoiceInfo = new(invoiceId);
            formInvoiceInfo.ShowDialog();
        }

        private async void buttonHomeCategory_Click(object sender, EventArgs e)
        {
            FormAddCategory formAddCategory = new();
            formAddCategory.ShowDialog();

            Task task = ShowHomePage();
            await task;
        }

        private async void buttonHomeUser_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new();
            formAddUser.ShowDialog();

            Task task = ShowHomePage();
            await task;
        }

        private async void buttonHomePurchase_Click(object sender, EventArgs e)
        {
            FormAddPurchases formAddPurchases = new();
            formAddPurchases.ShowDialog();

            Task task = ShowHomePage();
            await task;
        }

        private async void buttonHomeSale_Click(object sender, EventArgs e)
        {
            FormAddSales formAddSales = new();
            formAddSales.ShowDialog();

            Task task = ShowHomePage();
            await task;
        }

        private void buttonSideSettings_Click(object sender, EventArgs e)
        {
            if (pageState is PageState.settings) return;

            pageState = PageState.settings;
            panelSettings.BringToFront();
            this.Text = "الاعدادات";
            textBoxSettingsUserName.Text = Settings.Default.CurrentUserName;
            textBoxSettingsEmail.Text = Settings.Default.CurrentUserEmail;
            textBoxSettingsProfitRatio.Text = Settings.Default.ProfitRatio.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FormChangePassword formChangePassword = new FormChangePassword();
            formChangePassword.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FormChangeProfitRatio formChangeProfitRatio = new FormChangeProfitRatio();
            formChangeProfitRatio.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            formLogin.LogoutState = true;
            this.Close();
        }
    }
}
