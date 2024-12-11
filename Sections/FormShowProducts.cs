using APP2EFCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP2EFCore.Sections
{
    public partial class FormShowProducts : Form
    {
        readonly Section section;
        public FormShowProducts(Section section)
        {
            this.section = section;
            InitializeComponent();
        }

        private void FormShowProducts_Load(object sender, EventArgs e)
        {
            var products = section.Products.Select(p => new
            {
                p.Name,
                p.Price,
                p.Count,
                CategoryName = p.Category.Name,
            }).ToList();
            dataGridView1.DataSource = products;
            dataGridView1.Columns[0].HeaderText = "اسم المنتج";
            dataGridView1.Columns[1].HeaderText = "اسعر المنتج";
            dataGridView1.Columns[2].HeaderText = "الكمية";
            dataGridView1.Columns[3].HeaderText = "الصنف";
        }
    }
}
