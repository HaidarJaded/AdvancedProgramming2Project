using APP2EFCore.Enums;
using APP2EFCore.Properties;
using System.Data;

namespace APP2EFCore.Forms
{
    public partial class FormMain : Form
    {
        PageState pageState;
        AppDBContext db;
        //Thread ShowAllMonthlyReportsThread;
        //Thread ShowMonthlyReportsThread;
        //Thread ShowDailyReportThread;
        Thread ShowCategoriesThread;
        Thread ShowPurchasesThread;
        //Thread ShowproducersThread;
        //Thread ShowinvoicesThread;
        //Thread ShowVendorsThread;
        Thread ShowSalesThread;
        Thread ShowHomeThread;
        //Thread LogOutThread;
        public FormMain()
        {
            InitializeComponent();
            Settings.Default.CurrentUserType = UserTypes.admin.ToString();
            db = new AppDBContext();
        }
        private void ShowHomePage()
        {
            pageState = PageState.home;
            using (db = new AppDBContext())
            {
                int sumPurchasesPriceMonth;
                int sumSalesPriceMonth;
                try
                {
                    sumPurchasesPriceMonth = Convert.ToInt32(db.Purchases.Where(x => x.Date.Month == DateTime.Now.Month).Sum(x => x.ProductsTotalPrice));
                }
                catch
                {
                    sumPurchasesPriceMonth = 0;
                }

                try
                {
                    sumSalesPriceMonth = Convert.ToInt32(db.Sales.Where(x => x.Date.Month == DateTime.Now.Month).Sum(x => x.ProductsTotalPrice));
                }
                catch
                {
                    sumSalesPriceMonth = 0;
                }

                UpdateLabel(labelHomePurchasesPrice, sumPurchasesPriceMonth, "ل.س");
                UpdateLabel(labelHomeSalesPrice, sumSalesPriceMonth, "ل.س");

                UpdateLabel(labelHomeCategoriesCount, db.Categories.Count());
                UpdateLabel(labelHomeProductsCount, db.Products.Count());
                UpdateLabel(labelHomeUsersCount, db.Users.Where(x => x.Type == UserTypes.casher).Count());
            }
        }
        private void UpdateLabel(Label label, int value, string unit = "")
        {
            label.Invoke((MethodInvoker)delegate
            {
                label.Text = value + " " + unit;
            });
        }

        private void ShowCategoriesPage()
        {
            using (db = new AppDBContext())
            {
                var categories = db.Categories.Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.ProductsCount
                }).ToList();

                DGVCategories.Invoke((MethodInvoker)delegate
                {
                    DGVCategories.DataSource = categories;
                    DGVCategories.Columns["Id"].Visible = false;
                    DGVCategories.Columns["Name"].HeaderText = "اسم الصنف";
                    DGVCategories.Columns["ProductsCount"].HeaderText = "عدد المنتجات";
                });
            }
        }

        private void ShowSalesPage()
        {
            using (AppDBContext db = new AppDBContext())
            {
                var sales = db.Sales.Select(s => new
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
                DGVSales.Invoke((MethodInvoker)delegate
                {
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
                });
            }
        }

        private void ShowPurchasesPage()
        {
            using (AppDBContext db = new AppDBContext())
            {
                var purchases = db.Purchases.Select(p => new
                {
                    p.Id,
                    ProductName = p.Product.Name,
                    CategoryName = p.Product.Category.Name,
                    p.ProductsCount,
                    p.ProductPrice,
                    p.ProductsTotalPrice,
                    InvoiceId = p.Invoice.Id,
                    p.Date
                }).ToList();
                DGVPurchases.Invoke((MethodInvoker)delegate
                {
                    DGVPurchases.DataSource = purchases;
                    DGVPurchases.Columns[0].Visible = false;
                    DGVPurchases.Columns[1].HeaderText = "اسم المنتج";
                    DGVPurchases.Columns[2].HeaderText = "الصنف";
                    DGVPurchases.Columns[3].HeaderText = "الكمية";
                    DGVPurchases.Columns[4].HeaderText = "سعر المنتج";
                    DGVPurchases.Columns[5].HeaderText = "السعر الاجمالي";
                    DGVPurchases.Columns[6].HeaderText = "رقم الفاتورة";
                    DGVPurchases.Columns[7].HeaderText = "تاريخ الشراء";
                });
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (DGVCategories.CurrentRow != null)
            {
                int id = Convert.ToInt32(DGVCategories.CurrentRow.Cells[0].Value);
                using (db = new AppDBContext())
                {
                    Category category = db.Categories.FirstOrDefault(c => c.Id == id);
                    if (MessageBox.Show("هل حقا تريد حذف صنف " + category.Name + " ?\n لا يمكن استرجاع البيانات , سيتم حذف جميع البيانات المرتبطة", "اجراء حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        db.Categories.Remove(category);
                        db.SaveChanges();
                        if (ShowCategoriesThread == null || ShowCategoriesThread.ThreadState == ThreadState.Stopped)
                        {
                            ShowCategoriesThread = new Thread(ShowCategoriesPage);
                            ShowCategoriesThread.Start();
                        }
                    }

                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
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

                //Settings page
                //panel_settings_profitRatio.Visible = false;

            }
            else
            {
                //Home page
                buttonHomeSale.Visible = false;

            }
            if (pageState != PageState.home)
            {
                ShowHomePage();
            }
            labelUserName.Text = Settings.Default.CurrentUserName;
        }

        private void buttonSideCategories_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.categories)
            {
                pageState = PageState.categories;
                this.Text = "الاصناف";
                panelCategories.BringToFront();
                if (ShowCategoriesThread == null || ShowCategoriesThread.ThreadState == ThreadState.Stopped)
                {
                    ShowCategoriesThread = new Thread(ShowCategoriesPage);
                    ShowCategoriesThread.Start();
                }
            }
        }

        private void buttonSideHome_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.home)
            {
                panelHome.BringToFront();
                if (ShowHomeThread == null || ShowHomeThread.ThreadState == ThreadState.Stopped)
                {
                    ShowHomeThread = new Thread(ShowHomePage);
                    ShowHomeThread.Start();
                }
                this.Text = "الصفحة الرئيسية";
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Categories.FormAddCategory formAddCategory = new Categories.FormAddCategory();
            formAddCategory.ShowDialog();
            if (ShowCategoriesThread == null || ShowCategoriesThread.ThreadState == ThreadState.Stopped)
            {
                ShowCategoriesThread = new Thread(ShowCategoriesPage);
                ShowCategoriesThread.Start();
            }
        }

        private void buttonSideSales_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.sales)
            {
                pageState = PageState.sales;
                this.Text = "المبيعات";
                if (ShowSalesThread == null || ShowSalesThread.ThreadState == ThreadState.Stopped)
                {
                    ShowSalesThread = new Thread(ShowSalesPage);
                    ShowSalesThread.Start();
                }
                panelSales.BringToFront();
            }
        }

        private void buttonSidePurchases_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.purchases)
            {
                panelPurchases.BringToFront();
                pageState = PageState.purchases;
                this.Text = "المشتريات";
                if (ShowPurchasesThread == null || ShowPurchasesThread.ThreadState == ThreadState.Stopped)
                {
                    ShowPurchasesThread = new Thread(ShowPurchasesPage);
                    ShowPurchasesThread.Start();
                };
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Purchases.FormAddPurchases formAddPurchases = new Purchases.FormAddPurchases();
            formAddPurchases.ShowDialog();
            if (ShowPurchasesThread == null || ShowPurchasesThread.ThreadState == ThreadState.Stopped)
            {
                ShowPurchasesThread = new Thread(ShowPurchasesPage);
                ShowPurchasesThread.Start();
            };
        }
    }
}
