namespace APP2EFCore.Categories
{
    public partial class FormShowProducts : Form
    {
        readonly Category category;
        public FormShowProducts(Category category)
        {
            this.category = category;
            InitializeComponent();
        }

        private void FormShowProducts_Load(object sender, EventArgs e)
        {
            var products = category.Products.Select(p => new
            {
                p.Name,
                p.Price,
                p.Count,
                CategoryName=p.Category.Name,
            }).ToList();
            dataGridView1.DataSource = products;
            dataGridView1.Columns[0].HeaderText = "اسم المنتج";
            dataGridView1.Columns[1].HeaderText = "اسعر المنتج";
            dataGridView1.Columns[2].HeaderText = "الكمية";
            dataGridView1.Columns[3].HeaderText = "الصنف";
        }
    }
}
