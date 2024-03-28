using APP2EFCore.Models;
using APP2EFCore.Properties;

namespace APP2EFCore.Forms
{
    public partial class FormChangeProfitRatio : Form
    {
        public FormChangeProfitRatio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AppDBContext db = new AppDBContext())
            {
                Center? center = db.Centers.Find(1);
                if (center == null) { return; }
                center.ProfitRatio = numericProfitRatio.Value;
                db.SaveChanges();
                Settings.Default.ProfitRatio = numericProfitRatio.Value;
            }
            this.Close();
        }
    }
}
