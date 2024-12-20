﻿using APP2EFCore.Enums;
using APP2EFCore.Helpers;
using APP2EFCore.Models;
using APP2EFCore.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Drawing.Printing;

namespace APP2EFCore.Sales
{
    public partial class FormAddSales : Form
    {

        public FormAddSales()
        {
            InitializeComponent();
        }
        private async Task ShowProducts(string? search = null)
        {
            using AppDBContext db = new();
            var products = await db.Products
             .Where(p => (string.IsNullOrEmpty(search) ||
                          p.Name.Contains(search) ||
                          p.Section.Name.Contains(search) ||
                          p.Category.Name.Contains(search)) && p.Count > 0)
             .Select(p => new
             {
                 p.Id,
                 p.Name,
                 CategoryName = p.Category.Name,
                 p.Count,
                 p.Price,
                 SectionName = p.Section.Name,
             })
            .OrderByDescending(p => p.Id)
             .ToListAsync();
            //var products = await Task.Run(async () =>
            //{

            //    return await db.Products.Where(x => x.Count > 0).Select(x => new
            //    {
            //        x.Id,
            //        x.Name,
            //        CategoryName = x.Category.Name,
            //        x.Count,
            //        x.Price,
            //    }).ToListAsync();
            //});

            DGVProducts.Rows.Clear();
            foreach (var product in products)
            {
                DGVProducts.Rows.Add(product.Id, product.Name, product.CategoryName
                    , product.Count, product.Price, product.SectionName);
            }
        }

        void UpdateProductCount(int productCount)
        {
            DGVProducts.CurrentRow.Cells[3].Value = productCount;
            textBoxAvailableProductCount.Text = DGVProducts.CurrentRow.Cells[3].Value.ToString();
        }

        async Task AddSale(int productId, int productCount, decimal productPrice, Invoice invoice, User user, AppDBContext db)
        {
            Product? product = await db.Products.Include(p => p.Category).FirstAsync(p => p.Id == productId);
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
            await db.Sales.AddAsync(sales);
            product.Count -= productCount;
            if (product.Count <= product.Category.LowestNumber)
            {
                await db.MissingProducts.AddAsync(
                    new MissingProduct()
                    { Name = product.Name });
            }
            await db.SaveChangesAsync();
        }

        async Task AddSaleProccess()
        {
            if (DGVSales.CurrentRow == null)
            {
                MessageBox.Show("!الجدول فارغ");
                return;
            }

            using AppDBContext db = new();

            Invoice invoice = new Invoice()
            {
                Type = InvoiceType.sale
            };
            await db.Invoices.AddAsync(invoice);
            User? user = await db.Users.FindAsync(Settings.Default.CurrentUserId);
            if (user == null) { return; }
            foreach (DataGridViewRow productRow in DGVSales.Rows)
            {
                int productId = Convert.ToInt32(productRow.Cells[0].Value);
                int productCount = Convert.ToInt32(productRow.Cells[3].Value);
                decimal productPrice = Convert.ToDecimal(productRow.Cells[4].Value);
                await AddSale(productId, productCount, productPrice, invoice, user, db);
            }
            invoice.Total = Convert.ToDecimal(textBoxInvoiceTotalPrice.Text);
            await db.SaveChangesAsync();

            await ShowProducts();
        }

        private void CleanPage()
        {
            DGVSales.Rows.Clear();
            textBoxInvoiceTotalPrice.Text = "0";
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


        private async void FormAddSales_Load(object sender, EventArgs e)
        {
            string currentLayout = LanguageSwitcher.GetCurrentKeyboardLayout();

            if (currentLayout.Equals("4090409", StringComparison.OrdinalIgnoreCase)) // English US
            {
                labelLanguage.Text = "EN";
            }
            else
            {
                labelLanguage.Text = "AR";
            }
        }

        private void DGVProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (DGVProducts.CurrentRow is null) return;

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (DGVSales.CurrentRow is null) return;

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

        private async void button1_Click(object sender, EventArgs e)
        {
            Task task = AddSaleProccess();
            await task;
            CleanPage();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Task task = AddSaleProccess();
            await task;
            this.Close();
        }

        private async void textBoxSearchProducts_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearchProducts.Text.IsNullOrEmpty())
            {
                return;
            }
            await ShowProducts(textBoxSearchProducts.Text);
        }

        private void DGVProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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

        private void labelLanguage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string currentLayout = LanguageSwitcher.GetCurrentKeyboardLayout();
            string newLayout;

            // Check the current layout and toggle accordingly
            if (currentLayout.Equals("4090409", StringComparison.OrdinalIgnoreCase)) // English US
            {
                labelLanguage.Text = "AR";
                newLayout = "00000401"; // Change it to Arabic (Saudi Arabia)
            }
            else
            {
                labelLanguage.Text = "EN";
                newLayout = "00000409"; // Change it to English (US)
            }

            // Change the keyboard layout
            LanguageSwitcher.ChangeKeyboardLayout(newLayout);
            textBoxSearchProducts.Focus();
        }
    }
}
