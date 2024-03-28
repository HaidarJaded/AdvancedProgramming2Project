using APP2EFCore.Enums;
using APP2EFCore.Properties;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;

namespace APP2EFCore.Sales
{
    public partial class FormAddSales : Form
    {
        AppDBContext db;
        Thread ShowProductsThread;
        Thread AddSellThread;
        bool stateClose;

        public FormAddSales()
        {
            db = new AppDBContext();
            InitializeComponent();
        }
        private void ShowProducts()
        {
            using (db = new AppDBContext())
            {
                var products = db.Products.Where(x => x.Count > 0).Select(x => new
                {
                    x.Id,
                    x.Name,
                    CategoryName = x.Category.Name,
                    x.Count,
                    x.Price,
                }).ToList();

                DGVProducts.Invoke((MethodInvoker)delegate
                {
                    foreach (var product in products)
                    {
                        DGVProducts.Rows.Add(product.Id, product.Name, product.CategoryName
                            , product.Count, product.Price);
                    }
                });
            }
        }

        void UpdateProductCount(int productCount)
        {
            DGVProducts.CurrentRow.Cells[3].Value = productCount;
            textBoxAvailableProductCount.Text = DGVProducts.CurrentRow.Cells[3].Value.ToString();
        }

        void AddSale(int productId, int productCount, decimal productPrice, Invoice invoice, User user, ref AppDBContext db)
        {
            Product? product = db.Products.Find(productId);
            if (product == null) { return; }
            Sale sales = new Sale()
            {
                Product = product,
                ProductsCount = productCount,
                ProductPrice = productPrice,
                Invoice = invoice,
                User = user,
                profitRatio = Settings.Default.ProfitRatio
            };
            db.Sales.Add(sales);
            product.Count -= productCount;
        }

        void AddSaleProccess()
        {
            if (DGVSales.CurrentRow == null)
            {
                MessageBox.Show("!الجدول فارغ");
                return;
            }

            using (db = new AppDBContext())
            {
                Invoice invoice = new Invoice()
                {
                    Type = InvoiceType.sale
                };
                db.Invoices.Add(invoice);
                User? user = db.Users.Find(Settings.Default.CurrentUserId);
                if (user == null) { return; }
                foreach (DataGridViewRow productRow in DGVSales.Rows)
                {
                    int productId = Convert.ToInt32(productRow.Cells[0].Value);
                    int productCount = Convert.ToInt32(productRow.Cells[3].Value);
                    decimal productPrice = Convert.ToDecimal(productRow.Cells[4].Value);
                    AddSale(productId, productCount, productPrice, invoice, user, ref db);
                }
                invoice.Total = Convert.ToDecimal(textBoxInvoiceTotalPrice.Text);
                db.SaveChanges();
                if (stateClose)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                }
                cleanPage();
                ShowProducts();
            }
        }

        private void cleanPage()
        {
            DGVSales.Invoke((MethodInvoker)delegate
            {
                DGVSales.Rows.Clear();
                textBoxInvoiceTotalPrice.Text = "0";
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int availableProductCount = Convert.ToInt32(DGVProducts.CurrentRow.Cells[3].Value);
            if (availableProductCount <= 0)
            {
                MessageBox.Show("لا يوجد المزيد!");
                return;
            }
            string? productName = DGVProducts.CurrentRow.Cells[1].Value.ToString();
            int productId = Convert.ToInt32(DGVProducts.CurrentRow.Cells[0].Value);
            string? productCategoryName = DGVProducts.CurrentRow.Cells[2].Value.ToString();

            int saledProductCount = Convert.ToInt32(numericProductCount.Value);
            if (saledProductCount > availableProductCount) { saledProductCount = availableProductCount; }
            int saledProductPrice = Convert.ToInt32(numericProductPrice.Value);
            int totalPrice = saledProductCount * saledProductPrice;

            //If product already exists in table 
            foreach (DataGridViewRow row in DGVSales.Rows)
            {
                if (row.Cells[1].Value.ToString() == productName)
                {
                    int currentProductCount = Convert.ToInt32(row.Cells[3].Value);
                    int currentTotalPrice = Convert.ToInt32(row.Cells[5].Value);

                    currentProductCount += saledProductCount;
                    row.Cells[3].Value = currentProductCount;
                    row.Cells[4].Value = saledProductPrice;
                    row.Cells[5].Value = currentTotalPrice + totalPrice;

                    textBoxInvoiceTotalPrice.Text = (int.Parse(textBoxInvoiceTotalPrice.Text) + totalPrice).ToString();

                    UpdateProductCount(availableProductCount - saledProductCount);
                    numericProductCount.Value = numericProductCount.Minimum;
                    numericProductCount.Maximum = Math.Max(1, numericProductCount.Maximum - saledProductCount);
                    numericProductCount.Value = numericProductCount.Minimum;
                    return;
                }
            }

            //If product does not exists in table 

            DGVSales.Rows.Add(new object[] { productId, productName, productCategoryName, saledProductCount, saledProductPrice, totalPrice });
            textBoxInvoiceTotalPrice.Text = (int.Parse(textBoxInvoiceTotalPrice.Text) + totalPrice).ToString();

            UpdateProductCount(availableProductCount - saledProductCount);
        }


        private void FormAddSales_Load(object sender, EventArgs e)
        {
            ShowProductsThread = new Thread(ShowProducts);
            ShowProductsThread.Start();
        }

        private void DGVProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVProducts.CurrentRow != null)
            {
                int availableProductCount = Convert.ToInt32(DGVProducts.CurrentRow.Cells[3].Value);
                textBoxAvailableProductCount.Text = availableProductCount.ToString();
                if (availableProductCount != 0)
                    numericProductCount.Maximum = availableProductCount;
                else
                    numericProductCount.Maximum = 1;

                decimal productPrice = Convert.ToDecimal(DGVProducts.CurrentRow.Cells[4].Value);
                numericProductPrice.Value = productPrice + (productPrice / 100 * Settings.Default.ProfitRatio);
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DGVSales.CurrentRow != null)
            {
                int productsTotalPrice = Convert.ToInt32(DGVSales.CurrentRow.Cells[5].Value);
                textBoxInvoiceTotalPrice.Text = (int.Parse(textBoxInvoiceTotalPrice.Text) - productsTotalPrice).ToString();
                foreach (DataGridViewRow product in DGVProducts.Rows)
                {
                    if (product.Cells[1].Value.ToString() == DGVSales.CurrentRow.Cells[1].Value.ToString())
                    {
                        product.Cells[3].Value = Convert.ToInt32(product.Cells[3].Value) + Convert.ToInt32(DGVSales.CurrentRow.Cells[3].Value);
                    }
                }
                DGVSales.Rows.Remove(DGVSales.CurrentRow);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AddSellThread == null || AddSellThread.ThreadState == ThreadState.Stopped)
            {
                AddSellThread = new Thread(AddSaleProccess);
                AddSellThread.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AddSellThread == null || AddSellThread.ThreadState == ThreadState.Stopped)
            {
                stateClose = true;
                AddSellThread = new Thread(AddSaleProccess);
                AddSellThread.IsBackground = true;
                AddSellThread.Start();
            }
        }
    }
}
