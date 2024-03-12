namespace APP2EFCore.Categories
{
    public partial class FormAddCategory : Form
    {
        public FormAddCategory()
        {
            InitializeComponent();
        }
        bool AddCategory(string categoryName)
        {
            if (categoryName == "")
            {
                MessageBox.Show("الرجاء ادخال اسم الصنف");
                return false;
            }
            if (IsExists(categoryName))
            {
                MessageBox.Show("الصنف موجود مسبقا");
                return false;
            }
            using (AppDBContext TccDb = new AppDBContext())
            {
                Category category = new Category()
                {
                    Name = categoryName
                };
                TccDb.Categories.Add(category);
                TccDb.SaveChanges();
                MessageBox.Show("تم اضافة الصنف بنجاح");
                return true;
            }
        }

        public bool IsExists(string CaName)
        {
            using (AppDBContext db = new AppDBContext())
            {
                return db.Categories.Any(x => x.Name == CaName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AddCategory(textBoxName.Text))
                textBoxName.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AddCategory(textBoxName.Text))
                this.Close();
        }
    }
}
