using APP2EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP2EFCore.MissingProducts
{
    public partial class FormAddMissingProduct : Form
    {
        public FormAddMissingProduct()
        {
            InitializeComponent();
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            if (await AddMissingProduct(textBoxName.Text))
                this.Close();
            button1.Enabled = true;
            button2.Enabled = true;
        }
        async Task<bool> AddMissingProduct(string missingProductName)
        {
            if (string.IsNullOrEmpty(missingProductName))
            {
                MessageBox.Show("الرجاء ادخال اسم المنتج");
                return false;
            }
            if (await MissingProductExists(missingProductName))
            {
                MessageBox.Show("موجود مسبقا");
                return false;
            }
            using AppDBContext TccDb = new();
            MissingProduct missingProduct = new()
            {
                Name = missingProductName
            };
            await TccDb.MissingProducts.AddAsync(missingProduct);
            await TccDb.SaveChangesAsync();
            MessageBox.Show("تم الاضافة بنجاح");
            return true;
        }

        public async Task<bool> MissingProductExists(string missingProductName)
        {
            using AppDBContext db = new();
            return await db.MissingProducts.AnyAsync(x => x.Name == missingProductName);
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            if (await AddMissingProduct(textBoxName.Text))
                textBoxName.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}
