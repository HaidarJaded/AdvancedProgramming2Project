using APP2EFCore.Properties;

namespace APP2EFCore.Forms
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }
        bool IsPasswordValid(string password)
        {
            return password.Length >= 8;
        }
        bool IsPasswordConfirmed(string password, string passwordConfirm)
        {
            return password == passwordConfirm;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            using AppDBContext db = new ();
            User? user =await db.Users.FindAsync(Settings.Default.CurrentUserId);
            if (user is null) { return; }

            string currentPassword = PasswordEncrypter.EncryptPassword(textBoxCurrentPassword.Text);
            string newPassword = textBoxPassword.Text;
            string passwordConfirmation = textBoxPasswordConfirmation.Text;
            if (currentPassword != user.Password)
            {
                MessageBox.Show("!كلمة المرور الحالية خاطئة");
                return;
            }
            if (!IsPasswordValid(textBoxPassword.Text))
            {
                MessageBox.Show("كلمة المرور يجب ان تكون 8 محارف على الاقل!");
                return;
            }
            if (!IsPasswordConfirmed(textBoxPassword.Text, textBoxPasswordConfirmation.Text))
            {
                MessageBox.Show("يرجى تأكيد كلمة المرور بشكل صحيح");
                return;
            }
            user.Password = PasswordEncrypter.EncryptPassword(newPassword);
            await db.SaveChangesAsync();
            MessageBox.Show("تم تغيير كلمة المرور بنجاح");
            this.Close();

        }
    }
}
