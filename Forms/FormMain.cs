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
        //Thread ShowPurchasesThread;
        //Thread ShowproducersThread;
        //Thread ShowinvoicesThread;
        //Thread ShowVendorsThread;
        //Thread ShowSalesThread;
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
            using (AppDBContext db = new AppDBContext())
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


        private void timer1_Tick(object sender, EventArgs e)
        {
            labelClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void button5_Click(object sender, EventArgs e)
        {

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
                if (ShowCategoriesThread == null || ShowCategoriesThread.ThreadState == ThreadState.Unstarted)
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
    }
}
