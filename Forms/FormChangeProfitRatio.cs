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

        private async void button1_Click(object sender, EventArgs e)
        {
            using AppDBContext db = new();

             Center? center = await db.Centers.FindAsync(1);
            if (center is null) { return; }
            center.ProfitRatio = numericProfitRatio.Value;
            await db.SaveChangesAsync();
            Settings.Default.ProfitRatio = numericProfitRatio.Value;
            this.Close();
        }
    }
}
