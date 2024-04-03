using APP2EFCore.Categories;
using APP2EFCore.Enums;
using Microsoft.EntityFrameworkCore;

namespace APP2EFCore.Purchases
{
    public partial class FormAddPurchases : Form
    {
        public FormAddPurchases()
        {
            InitializeComponent();
        }

        private async Task GetCategoriesAsync()
        {
            var categories = await Task.Run(() =>
            {
                using AppDBContext db = new();
                return db.Categories.Select(c => new
                {
                    c.Id,
                    c.Name
                }).ToArray();
            });

            comboBoxProductCategory.DataSource = categories;
            comboBoxProductCategory.DisplayMember = "Name";
            comboBoxProductCategory.ValueMember = "Id";
        }

        private async Task AddPurchasesAsync(decimal totalInvoicePrice)
        {
            button3.Enabled = false;
            button4.Enabled = false;

            await Task.Run(async () =>
            {
                      AppDBContext db = new();
                      Invoice invoice = new()
                      {
                          Type = InvoiceType.purchase,
                      };
                      await db.Invoices.AddAsync(invoice);
                      foreach (DataGridViewRow row in DGVProducts.Rows)
                      {
                          string productName = row.Cells[0].Value.ToString();
                          int productCount = Convert.ToInt32(row.Cells[2].Value);
                          decimal productPrice = Convert.ToDecimal(row.Cells[3].Value);
                          int categoryId = Convert.ToInt32(row.Cells[5].Value);
                          Product product = await ProductExistsAsync(productName);
                          Category category = await db.Categories.FindAsync(categoryId);
                          if (product is null)
                          {
                              product = new()
                              {
                                  Name = productName,
                                  Count = productCount,
                                  Price = productPrice,
                                  Category = category
                              };
                              await db.Products.AddAsync(product);
                              category.ProductsCount++;
                          }
                          else
                          {
                              category = product.Category;
                              product.Count += productCount;
                              product.Price = productPrice;
                          }

                          Purchase purchase = new()
                          {
                              ProductPrice = productPrice,
                              ProductsCount = productCount,
                              Invoice = invoice,
                              Product = product,
                          };
                          await db.Purchases.AddAsync(purchase);
                      }
                      invoice.Total = totalInvoicePrice;
                      await db.SaveChangesAsync();
            });

            cleanPage();
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void cleanPage()
        {
            textBoxProductName.Text = "";
            numericProductCount.Value = 1;
            comboBoxProductCategory.SelectedIndex = -1;
            numericProductPrice.Value = 1;
            DGVProducts.Rows.Clear();
            labelTotalInvoice.Text = "0";
        }

        private async Task<Product?> ProductExistsAsync(string productName)
        {
            using AppDBContext db = new();
            return await db.Products.AsNoTracking().Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Name == productName);
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

        private async void FormAddPurchases_Activated(object sender, EventArgs e)
        {
            Task task = GetCategoriesAsync();
            await task;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAddCategory formAddCategory = new();
            formAddCategory.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DGVProducts.CurrentRow is null) return;

            int totalProductsPrice = Convert.ToInt32(DGVProducts.CurrentRow.Cells[4].Value);
            DGVProducts.Rows.Remove(DGVProducts.CurrentRow);
            labelTotalInvoice.Text = (int.Parse(labelTotalInvoice.Text) - totalProductsPrice).ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (DGVProducts.Rows.Count == 0)
            {
                MessageBox.Show("الجدول فارغ");
                return;
            }

            Task task = AddPurchasesAsync(decimal.Parse(labelTotalInvoice.Text));
            await task;
            textBoxProductName.Focus();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            if (DGVProducts.Rows.Count == 0)
            {
                MessageBox.Show("الجدول فارغ");
                return;
            }

            Task task = AddPurchasesAsync(decimal.Parse(labelTotalInvoice.Text));
            await task;
            this.Close();
        }
    }
}
