using Microsoft.EntityFrameworkCore;
using System.Data;

namespace APP2EFCore.Products
{
    public partial class FormEditProduct : Form
    {
        Product product;
        public FormEditProduct(Product product)
        {
            this.product = product;
            InitializeComponent();
        }

        async Task<bool> ProductExsists(string productName)
        {
            using AppDBContext db = new();
            return await db.Products.AnyAsync(p=>p.Name == productName);
        }

        private async void FormEditProduct_Load(object sender, EventArgs e)
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

            textBoxName.Text = product.Name;
            comboBoxProductCategory.SelectedText = product.Category.Name;
            numericProductPrice.Value = product.Price;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("يرجى تعبئة كل الحقول");
                return;
            }
            string productName = textBoxName.Text;
            if (await ProductExsists(productName)&&productName!=product.Name)
            {
                MessageBox.Show("عذرا هذا المنتج موجود مسبقا");
                return;
            }
            using AppDBContext db = new();
            int categoryId = Convert.ToInt32(comboBoxProductCategory.SelectedValue);
            Category oldCategory = await db.Categories.FindAsync(product.Category.Id);
            product = db.Products.Find(product.Id);
            product.Name = textBoxName.Text;
            product.Category = await db.Categories.FindAsync(categoryId);
            product.Price = numericProductPrice.Value;
            if (categoryId != oldCategory.Id)
            {
                oldCategory.ProductsCount--;
                product.Category.ProductsCount++;
            }
            await db.SaveChangesAsync();
            MessageBox.Show("تم التعديل بنجاح");
            this.Close();
        }
    }
}
