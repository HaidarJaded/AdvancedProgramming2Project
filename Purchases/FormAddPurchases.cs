using APP2EFCore.Enums;
using Microsoft.EntityFrameworkCore;

namespace APP2EFCore.Purchases
{
    public partial class FormAddPurchases : Form
    {
        Thread GetCategoriesThread;
        Thread AddPurchaseThread;
        string state = "";
        public FormAddPurchases()
        {
            InitializeComponent();
        }

        private void GetCategories()
        {
            using (AppDBContext db = new AppDBContext())
            {
                var categories = db.Categories.Select(c => new
                {
                    c.Id,
                    c.Name
                }).ToArray();
                comboBoxProductCategory.Invoke((MethodInvoker)delegate
                {
                    comboBoxProductCategory.DataSource = categories;
                    comboBoxProductCategory.DisplayMember = "Name";
                    comboBoxProductCategory.ValueMember = "Id";
                });
            }
        }

        private void AddPurchases()
        {
            button3.Invoke((MethodInvoker)delegate
            {
                button3.Enabled = false;
                button4.Enabled = false;
            });
            using (AppDBContext db = new AppDBContext())
            {
                Invoice invoice = new Invoice()
                {
                    Type = InvoiceType.purchase,
                };
                db.Invoices.Add(invoice);
                foreach (DataGridViewRow row in DGVProducts.Rows)
                {
                    string productName = row.Cells[0].Value.ToString();
                    int productCount = Convert.ToInt32(row.Cells[2].Value);
                    decimal productPrice = Convert.ToDecimal(row.Cells[3].Value);
                    int categoryId = Convert.ToInt32(row.Cells[5].Value);
                    Category category = db.Categories.Find(categoryId);
                    Product product = IsProductExist(productName);
                    if (product == null)
                    {
                        product = new Product()
                        {
                            Name = productName,
                            Count = productCount,
                            Price = productPrice,
                            Category = category
                        };
                        db.Products.Add(product);
                        category.ProductsCount += 1;
                    }
                    else
                    {
                        product = db.Products.Find(product.Id);
                        category = product.Category;
                        product.Count += productCount;
                        product.Price = productPrice;
                    }
                    Purchase purchase = new Purchase()
                    {
                        ProductPrice = productPrice,
                        ProductsCount = productCount,
                        Invoice = invoice,
                        Product = product,
                    };
                    db.Purchases.Add(purchase);
                    invoice.Total = productCount * productPrice;
                }
                db.SaveChanges();
            }
            if (state == "close")
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }
            else
            {
                cleanPage();
                button3.Invoke((MethodInvoker)delegate
                {
                    button3.Enabled = true;
                    button4.Enabled = true;
                });
            }
        }

        private void cleanPage()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(cleanPage));
                return;
            }

            textBoxProductName.Text = "";
            numericProductCount.Value = 1;
            comboBoxProductCategory.SelectedIndex = -1;
            numericProductPrice.Value = 1;
            DGVProducts.Rows.Clear();
            labelTotalInvoice.Text = "0";
        }

        private Product? IsProductExist(string productName)
        {
            using (AppDBContext db = new AppDBContext())
            {
                return db.Products.Include(p => p.Category).Where(p => p.Name == productName).FirstOrDefault();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxProductName.Text) || comboBoxProductCategory.SelectedIndex == -1)
            {
                MessageBox.Show("يرجى تعبئة البيانات المطلوبة");
                return;
            }

            bool productExists = false;
            string productName = textBoxProductName.Text;
            string productCategory = comboBoxProductCategory.Text;
            int CategoryId = Convert.ToInt32(comboBoxProductCategory.SelectedValue);
            int productCount = Convert.ToInt32(numericProductCount.Value);
            decimal productPrice = numericProductPrice.Value;
            decimal totalPrice = productCount * productPrice;
            foreach (DataGridViewRow row in DGVProducts.Rows)
            {
                if (row.Cells[0].Value.ToString() == productName)
                {
                    decimal lastTotal = Convert.ToDecimal(row.Cells[ProductsTotalPrice.Index].Value);
                    int existingCount = Convert.ToInt32(row.Cells[2].Value);
                    decimal existingPrice = Convert.ToDecimal(row.Cells[3].Value);
                    totalPrice = (productCount + existingCount) * productPrice;
                    existingCount += productCount;
                    row.Cells[2].Value = existingCount;
                    row.Cells[3].Value = productPrice;
                    row.Cells[4].Value = existingCount * productPrice;
                    labelTotalInvoice.Text = (decimal.Parse(labelTotalInvoice.Text) - lastTotal + totalPrice).ToString();
                    productExists = true;
                    break;
                }
            }
            if (!productExists)
            {
                totalPrice = numericProductCount.Value * numericProductPrice.Value;
                DGVProducts.Rows.Add(productName, productCategory, productCount, productPrice, totalPrice, CategoryId);
                labelTotalInvoice.Text = (decimal.Parse(labelTotalInvoice.Text) + totalPrice).ToString();
            }
            textBoxProductName.Focus();
        }

        private void FormAddPurchases_Activated(object sender, EventArgs e)
        {
            if (GetCategoriesThread == null || GetCategoriesThread.ThreadState == ThreadState.Stopped)
            {
                GetCategoriesThread = new Thread(GetCategories);
                GetCategoriesThread.Start();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Categories.FormAddCategory formAddCategory = new Categories.FormAddCategory();
            formAddCategory.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DGVProducts.CurrentRow != null)
            {
                int totalProductsPrice = Convert.ToInt32(DGVProducts.CurrentRow.Cells[4].Value);
                DGVProducts.Rows.Remove(DGVProducts.CurrentRow);
                labelTotalInvoice.Text = (int.Parse(labelTotalInvoice.Text) - totalProductsPrice).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DGVProducts.Rows.Count == 0)
            {
                MessageBox.Show("الجدول فارغ");
                return;
            }
            if (AddPurchaseThread == null || AddPurchaseThread.ThreadState == ThreadState.Stopped)
            {
                AddPurchaseThread = new Thread(AddPurchases);
                AddPurchaseThread.Start();
                textBoxProductName.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DGVProducts.Rows.Count == 0)
            {
                MessageBox.Show("الجدول فارغ");
                return;
            }
            if (AddPurchaseThread == null || AddPurchaseThread.ThreadState == ThreadState.Stopped)
            {
                state = "close";
                AddPurchaseThread = new Thread(AddPurchases);
                AddPurchaseThread.Start();
                textBoxProductName.Focus();
            }

        }
    }
}
