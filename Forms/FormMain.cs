using APP2EFCore.Enums;
using APP2EFCore.Properties;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace APP2EFCore.Forms
{
    public partial class FormMain : Form
    {
        PageState pageState;
        AppDBContext db;
        Thread ShowReportsThread;
        Thread GetUsersThread;
        Thread ShowCategoriesThread;
        Thread ShowPurchasesThread;
        Thread ShowProductsThread;
        Thread ShowinvoicesThread;
        Thread ShowUsersThread;
        Thread ShowSalesThread;
        Thread ShowHomeThread;
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

        private void ShowUsersPage()
        {
            using (db = new AppDBContext())
            {
                var users = db.Users.Where(u => u.Type == UserTypes.casher).Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.Email
                }).ToList();
                DGVUsers.Invoke((MethodInvoker)delegate
              {
                  DGVUsers.DataSource = users;
                  DGVUsers.Columns[0].Visible = false;
                  DGVUsers.Columns[1].HeaderText = "اسم البائع";
                  DGVUsers.Columns[2].HeaderText = "البريد الالكتروني";
              });
            }
        }

        private void ShowProductsPage()
        {
            using (db = new AppDBContext())
            {
                var products = db.Products.Select(p => new
                {
                    p.Id,
                    p.Name,
                    CategoryName = p.Category.Name,
                    p.Price,
                    p.Count,
                }).ToList();
                DGVProducts.Invoke((MethodInvoker)delegate
                {
                    DGVProducts.DataSource = products;
                    DGVProducts.Columns[0].Visible = false;
                    DGVProducts.Columns[1].HeaderText = "اسم المنتج";
                    DGVProducts.Columns[2].HeaderText = "الصنف";
                    DGVProducts.Columns[3].HeaderText = "السعر";
                    DGVProducts.Columns[4].HeaderText = "الكمية";
                });
            }
        }

        private void GetUsersName()
        {
            using (db = new AppDBContext())
            {
                var users = db.Users.Where(u => u.Type == UserTypes.casher).Select(u => new
                {
                    u.Id,
                    u.Name,
                }).ToList();
                comboBoxUserName.Invoke((MethodInvoker)delegate
                {
                    comboBoxUserName.DataSource = users;
                    comboBoxUserName.DisplayMember = "Name";
                    comboBoxUserName.ValueMember = "Id";
                });
            }
        }

        private void ShowReportPage()
        {
            DateTime startDate = dateTimePickerFrom.Value.Date;
            DateTime endDate = dateTimePickerTo.Value.Date;

            try
            {
                using (AppDBContext db = new AppDBContext())
                {
                    var salesBetweenDates = db.Sales
                        .Where(s => s.Date.Date >= startDate && s.Date.Date <= endDate);

                    if (!checkBoxAllUsers.Checked)
                    {
                        int userId = 0;
                        comboBoxUserName.Invoke((MethodInvoker)delegate
                        {
                            userId = Convert.ToInt32(comboBoxUserName.SelectedValue);
                        });

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

                    DGVReports.Invoke((MethodInvoker)delegate
                    {
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
                    });
                }
            }
            catch (Exception ex)
            {
                // Handle and log any exceptions that occur
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowInvoicesPage()
        {
            using (db = new AppDBContext())
            {
                var invoices = db.Invoices.Select(i => new
                {
                    i.Id,
                    i.Type,
                    i.Total,
                    i.Date
                }).ToList();
                DGVInvoices.Invoke((MethodInvoker)delegate
                {
                    DGVInvoices.DataSource = invoices;
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

                //Sales page
                panelSalesButtom.Visible = false;

                //Settings page
                //panel_settings_profitRatio.Visible = false;

            }
            else
            {
                //Home page
                buttonHomeSale.Visible = false;

            }

            ShowHomePage();
            string userName = Settings.Default.CurrentUserName;
            labelUserName.Text = string.IsNullOrWhiteSpace(userName) ? "UserName" : userName;
            dateTimePickerTo.MaxDate = DateTime.Now;
            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (DGVCategories.CurrentRow != null)
            {
                using (db = new AppDBContext())
                {
                    int categoryId = Convert.ToInt32(DGVCategories.CurrentRow.Cells[0].Value);
                    Category category = db.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == categoryId);
                    Categories.FormShowProducts formShowProducts = new Categories.FormShowProducts(category);
                    formShowProducts.ShowDialog();
                }
            }

        }

        private void buttonSideProducts_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.products)
            {
                panelProducts.BringToFront();
                pageState = PageState.products;
                this.Text = "المنتجات";
                if (ShowProductsThread == null || ShowProductsThread.ThreadState == ThreadState.Stopped)
                {
                    ShowProductsThread = new Thread(ShowProductsPage);
                    ShowProductsThread.Start();
                };
            }
        }

        private void buttonSideUsers_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.user)
            {
                panelUsers.BringToFront();
                pageState = PageState.user;
                this.Text = "البائعين";
                if (ShowUsersThread == null || ShowUsersThread.ThreadState == ThreadState.Stopped)
                {
                    ShowUsersThread = new Thread(ShowUsersPage);
                    ShowUsersThread.Start();
                };
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Users.FormAddUser formAddUser = new Users.FormAddUser();
            formAddUser.ShowDialog();
            if (ShowUsersThread == null || ShowUsersThread.ThreadState == ThreadState.Stopped)
            {
                ShowUsersThread = new Thread(ShowUsersPage);
                ShowUsersThread.Start();
            };
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (DGVUsers.CurrentRow != null)
            {
                int userId = Convert.ToInt32(DGVUsers.CurrentRow.Cells[0].Value);
                using (db = new AppDBContext())
                {
                    User user = db.Users.Find(userId);

                    if (MessageBox.Show("هل حقا تريد حذف البائع " + user.Name + " لا يمكن استرجاع البيانات, ", "اجراء حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        db.Users.Remove(user);
                        db.SaveChanges();
                        if (ShowUsersThread == null || ShowUsersThread.ThreadState == ThreadState.Stopped)
                        {
                            ShowUsersThread = new Thread(ShowUsersPage);
                            ShowUsersThread.Start();
                        };
                    }

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (DGVUsers.CurrentRow != null)
            {
                User user;
                using (db = new AppDBContext())
                {
                    int userId = Convert.ToInt32(DGVUsers.CurrentRow.Cells[0].Value);
                    user = db.Users.Find(userId);
                    Users.FormEditUser formEditUser = new Users.FormEditUser(user, db);
                    formEditUser.ShowDialog();
                }
                if (ShowUsersThread == null || ShowUsersThread.ThreadState == ThreadState.Stopped)
                {
                    ShowUsersThread = new Thread(ShowUsersPage);
                    ShowUsersThread.Start();
                };
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (DGVProducts.CurrentRow != null)
            {
                using (db = new AppDBContext())
                {
                    int productId = Convert.ToInt32(DGVProducts.CurrentRow.Cells[0].Value);
                    Product product = db.Products.Include(p => p.Category).Where(p => p.Id == productId).First();
                    Products.FormEditProduct formEditProduct = new Products.FormEditProduct(product);
                    formEditProduct.ShowDialog();
                }
                if (ShowProductsThread == null || ShowProductsThread.ThreadState == ThreadState.Stopped)
                {
                    ShowProductsThread = new Thread(ShowProductsPage);
                    ShowProductsThread.Start();
                };
            }
        }

        private void buttonSideReports_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.reports)
            {
                pageState = PageState.reports;
                this.Text = "التقارير";
                if (GetUsersThread == null || GetUsersThread.ThreadState == ThreadState.Stopped)
                {
                    GetUsersThread = new Thread(GetUsersName);
                    GetUsersThread.Start();
                }
                panelReports.BringToFront();
            }
        }

        private void comboBoxUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ShowReportsThread == null || ShowReportsThread.ThreadState == ThreadState.Stopped)
            {
                ShowReportsThread = new Thread(ShowReportPage);
                ShowReportsThread.Start();
            }
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            if (ShowReportsThread == null || ShowReportsThread.ThreadState == ThreadState.Stopped)
            {
                ShowReportsThread = new Thread(ShowReportPage);
                ShowReportsThread.Start();
            }
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {
            if (ShowReportsThread == null || ShowReportsThread.ThreadState == ThreadState.Stopped)
            {
                ShowReportsThread = new Thread(ShowReportPage);
                ShowReportsThread.Start();
            }
            dateTimePickerFrom.MaxDate = dateTimePickerTo.Value;
        }

        private void checkBoxAllUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowReportsThread == null || ShowReportsThread.ThreadState == ThreadState.Stopped)
            {
                ShowReportsThread = new Thread(ShowReportPage);
                ShowReportsThread.Start();
            }
        }

        private void buttonSideInvoices_Click(object sender, EventArgs e)
        {
            if (pageState != PageState.invoices)
            {
                panelInvoices.BringToFront();
                pageState = PageState.invoices;
                this.Text = "الفواتير";
                if (ShowinvoicesThread == null || ShowinvoicesThread.ThreadState == ThreadState.Stopped)
                {
                    ShowinvoicesThread = new Thread(ShowInvoicesPage);
                    ShowinvoicesThread.Start();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (DGVInvoices.CurrentRow != null)
            {
                int invoiceId = Convert.ToInt32(DGVInvoices.CurrentRow.Cells[0].Value);
                Invoices.FormInvoiceInfo formInvoiceInfo = new Invoices.FormInvoiceInfo(invoiceId);
                formInvoiceInfo.ShowDialog();
            }
        }

        private void buttonHomeCategory_Click(object sender, EventArgs e)
        {
            Categories.FormAddCategory formAddCategory = new Categories.FormAddCategory();
            formAddCategory.ShowDialog();
            ShowHomePage();
        }

        private void buttonHomeUser_Click(object sender, EventArgs e)
        {
            Users.FormAddUser formAddUser = new Users.FormAddUser();
            formAddUser.ShowDialog();
            ShowHomePage();
        }

        private void buttonHomePurchase_Click(object sender, EventArgs e)
        {
            Purchases.FormAddPurchases formAddPurchases = new Purchases.FormAddPurchases();
            formAddPurchases.ShowDialog();
            ShowHomePage();
        }

        private void buttonHomeSale_Click(object sender, EventArgs e)
        {
            Sales.FormAddSales formAddSales = new Sales.FormAddSales();
            formAddSales.ShowDialog();
            ShowHomePage();
        }
    }
}
