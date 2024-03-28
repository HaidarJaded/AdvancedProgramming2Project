using APP2EFCore.Properties;

namespace APP2EFCore.Forms
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AppDBContext db = new AppDBContext())
            {
                User? user = db.Users.Find(Settings.Default.CurrentUserId);
                if (user == null) { return; }
                string currentPassword = PasswordEncrypter.EncryptPassword(textBoxCurrentPassword.Text);
                string newPassword = textBoxPassword.Text;
                string passwordConfirmation = textBoxPasswordConfirmation.Text;
                if (currentPassword != user.Password)
                {
                    MessageBox.Show("!كلمة المرور الحالية خاطئة");
                    return;
                }
                if (newPassword.Length < 8)
                {
                    MessageBox.Show("كلمة المرور يجب ان تكون 8 محارف على الاقل!");
                    return;
                }
                if (newPassword != passwordConfirmation)
                {
                    MessageBox.Show("!كلمة المرور واعادتها غير متطابقتين");
                    return;
                }
                user.Password = PasswordEncrypter.EncryptPassword(newPassword);
                db.SaveChanges();
                MessageBox.Show("تم تغيير كلمة المرور بنجاح");
                this.Close();
            }

        }
    }
}
