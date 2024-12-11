 using APP2EFCore.Categories;
using APP2EFCore.Enums;
using Microsoft.EntityFrameworkCore;

namespace APP2EFCore.Purchases
{
    public partial class FormAddPurchases : Form
    {
        private List<string> productsName;
        public FormAddPurchases()
        {
            InitializeComponent();
            productsName = [];
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

            using var db = new AppDBContext();
            using var transaction = await db.Database.BeginTransactionAsync();

            try
            {
                // Create the invoice
                Invoice invoice = new() { Type = InvoiceType.purchase, Total = totalInvoicePrice };
                await db.Invoices.AddAsync(invoice);

                // Retrieve categories once and track them in DbContext
                var categoryIds = DGVProducts.Rows.Cast<DataGridViewRow>()
                                     .Select(r => Convert.ToInt32(r.Cells[6].Value))
                                     .Distinct()
                                     .ToList();
                var categories = await db.Categories.Where(c => categoryIds.Contains(c.Id)).ToDictionaryAsync(c => c.Id);

                // Process each product row
                foreach (DataGridViewRow row in DGVProducts.Rows)
                {
                    var (productName, productCount, productPurchasePrice, productPrice, categoryId) = GetRowData(row);

                    // Get or create the product directly within this method
                    Product product = await GetOrAddProductAsync(db, productName, productCount, productPrice, productPurchasePrice, categories[categoryId]);

                    // Create a purchase record for this product
                    Purchase purchase = new()
                    {
                        ProductPrice = productPurchasePrice,
                        ProductsCount = productCount,
                        Invoice = invoice,
                        Product = product
                    };
                    await db.Purchases.AddAsync(purchase);
                }

                await db.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                cleanPage();
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        // Helper method to retrieve or add a product within the same DbContext to avoid re-attaching issues
        private async Task<Product> GetOrAddProductAsync(AppDBContext db, string productName, int productCount, decimal productPrice, decimal productPurchasePrice, Category category)
        {
            // Try to retrieve an existing product within this context
            Product product = await db.Products.FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                // If product doesn't exist, create it and attach the category directly
                product = new Product
                {
                    Name = productName,
                    Count = productCount,
                    Price = productPrice,
                    PurchasePrice = productPurchasePrice,
                    Category = category
                };
                await db.Products.AddAsync(product);
                category.ProductsCount++;
            }
            else
            {
                // Update existing product details and link to the correct category
                if (product.Category.Id != category.Id)
                {
                    category.ProductsCount++;
                    product.Category.ProductsCount--;
                    product.Category = category;
                }
                product.Count += productCount;
                product.Price = productPrice;
                product.PurchasePrice = productPurchasePrice;
            }

            return product;
        }

        // Helper method to extract data from DataGridViewRow
        private (string productName, int productCount, decimal productPurchasePrice, decimal productPrice, int categoryId) GetRowData(DataGridViewRow row)
        {
            string productName = row.Cells[0].Value?.ToString() ?? string.Empty;
            int productCount = Convert.ToInt32(row.Cells[2].Value);
            decimal productPurchasePrice = Convert.ToDecimal(row.Cells[3].Value);
            decimal productPrice = Convert.ToDecimal(row.Cells[4].Value);
            int categoryId = Convert.ToInt32(row.Cells[6].Value);

            return (productName, productCount, productPurchasePrice, productPrice, categoryId);
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
            decimal productPurchasePrice = numericProductPurchasePrice.Value;
            decimal totalPrice = productCount * productPrice;

            foreach (DataGridViewRow row in DGVProducts.Rows)
            {
                if (row.Cells[0].Value.ToString() == productName)
                {
                    decimal lastTotal = Convert.ToDecimal(row.Cells[ProductsTotalPrice.Index].Value);
                    int existingCount = Convert.ToInt32(row.Cells[2].Value);
                    totalPrice = (productCount + existingCount) * productPurchasePrice;
                    existingCount += productCount;
                    row.Cells[2].Value = existingCount;
                    row.Cells[3].Value = productPurchasePrice;
                    row.Cells[4].Value = productPrice;
                    row.Cells[5].Value = existingCount * productPurchasePrice;
                    labelTotalInvoice.Text = (decimal.Parse(labelTotalInvoice.Text) - lastTotal + totalPrice).ToString();
                    productExists = true;
                    break;
                }
            }
            if (!productExists)
            {
                totalPrice = numericProductCount.Value * numericProductPurchasePrice.Value;
                DGVProducts.Rows.Add(productName, productCategory, productCount, productPurchasePrice, productPrice, totalPrice, CategoryId);
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

            int totalProductsPrice = Convert.ToInt32(DGVProducts.CurrentRow.Cells[3].Value);
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

        private void FormAddPurchases_Load(object sender, EventArgs e)
        {
            using (AppDBContext db = new AppDBContext())
            {
                // Retrieve product names as a list
                var productsName = db.Products.Select(p => p.Name).ToList();

                // Set the AutoCompleteSource and AutoCompleteMode for the text box 
                textBoxProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxProductName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                // Create and populate the AutoCompleteStringCollection
                var autoCompleteCollection = new AutoCompleteStringCollection();
                autoCompleteCollection.AddRange(productsName.ToArray());

                // Assign the AutoCompleteCustomSource
                textBoxProductName.AutoCompleteCustomSource = autoCompleteCollection;
            }
        }

        private void textBoxProductName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
