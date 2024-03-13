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

        private void FormEditProduct_Load(object sender, EventArgs e)
        {
            using (AppDBContext db = new AppDBContext())
            {
                var categories = db.Categories.Select(c => new
                {
                    c.Id,
                    c.Name
                }).ToArray();
                comboBoxProductCategory.DataSource = categories;
                comboBoxProductCategory.DisplayMember = "Name";
                comboBoxProductCategory.ValueMember = "Id";
            }
            textBoxName.Text = product.Name;
            comboBoxProductCategory.SelectedText = product.Category.Name;
            numericProductPrice.Value = product.Price;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("يرجى تعبئة كل الحقول");
                return;
            }
            using (AppDBContext db = new AppDBContext())
            {
                int categoryId = Convert.ToInt32(comboBoxProductCategory.SelectedValue);
                Category oldCategory = db.Categories.Find(product.Category.Id);
                product = db.Products.Find(product.Id);
                product.Name = textBoxName.Text;
                product.Category = db.Categories.Find(categoryId);
                product.Price = numericProductPrice.Value;
                if (categoryId != oldCategory.Id)
                {
                    oldCategory.ProductsCount--;
                    product.Category.ProductsCount++;
                }
                db.SaveChanges();
            }
            MessageBox.Show("تم التعديل بنجاح");
            this.Close();
        }
    }
}
