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

namespace APP2EFCore.Sections
{
    public partial class FormAddSection : Form
    {
        public FormAddSection()
        {
            InitializeComponent();
        }
        async Task<bool> AddSection(string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName))
            {
                MessageBox.Show("الرجاء ادخال اسم القسم");
                return false;
            }
            if (await SectionExists(sectionName))
            {
                MessageBox.Show("القسم موجود مسبقا");
                return false;
            }
            using AppDBContext db = new();
            Section section = new()
            {
                Name = sectionName
            };
            await db.Sections.AddAsync(section);
            await db.SaveChangesAsync();
            MessageBox.Show("تم اضافة القسم بنجاح");
            return true;
        }

        public async Task<bool> SectionExists(string sectionName)
        {
            using AppDBContext db = new();
            return await db.Sections.AnyAsync(x => x.Name == sectionName);
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            if (await AddSection(textBoxSectionName.Text))
                textBoxSectionName.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            if (await AddSection(textBoxSectionName.Text))
                this.Close();
        }
    }
}
