using Microsoft.EntityFrameworkCore;

namespace APP2EFCore.Categories
{
    public partial class FormAddCategory : Form
    {
        public FormAddCategory()
        {
            InitializeComponent();
        }
        async Task<bool> AddCategory(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("الرجاء ادخال اسم الصنف");
                return false;
            }
            if (await CategoryExists(categoryName))
            {
                MessageBox.Show("الصنف موجود مسبقا");
                return false;
            }
            using AppDBContext TccDb = new();
            Category category = new()
            {
                Name = categoryName
            };
            await TccDb.Categories.AddAsync(category);
            await TccDb.SaveChangesAsync();
            MessageBox.Show("تم اضافة الصنف بنجاح");
            return true;
        }

        public async Task<bool> CategoryExists(string CategoeyName)
        {
            using AppDBContext db = new();
            return await db.Categories.AnyAsync(x => x.Name == CategoeyName);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            if (await AddCategory(textBoxName.Text))
                textBoxName.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            if (await AddCategory(textBoxName.Text))
                this.Close();
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}
