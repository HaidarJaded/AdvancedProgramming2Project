using APP2EFCore.Enums;

namespace APP2EFCore.Forms
{
    public partial class FormAddAdmin : Form
    {
        public FormAddAdmin()
        {
            InitializeComponent();
        }

        bool AreNull()
        {
            return string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                   string.IsNullOrWhiteSpace(textBoxName.Text) ||
                   string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                   string.IsNullOrWhiteSpace(textBoxPasswordConfirm.Text);
        }
        bool IsPasswordValid(string password)
        {
            return password.Length >= 8;
        }
        bool IsEmail(string email)
        {
            return email.Contains("@");
        }
        bool IsPasswordConfirmed(string password, string passwordConfirm)
        {
            return password == passwordConfirm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AreNull())
            {
                MessageBox.Show("يرجى تعبئة كل الحقول");
                return;
            }

            if (!IsEmail(textBoxEmail.Text))
            {
                MessageBox.Show("يرجى كتابة بريد الكتروني صالح");
                return;
            }

            if (!IsPasswordConfirmed(textBoxPassword.Text, textBoxPasswordConfirm.Text))
            {
                MessageBox.Show("يرجى تأكيد كلمة المرور بشكل صحيح");
                return;
            }

            if (!IsPasswordValid(textBoxPassword.Text))
            {
                MessageBox.Show("كلمة المرور يجب ان تكون 8 محارف على الأقل!");
                return;
            }

            using (AppDBContext db = new AppDBContext())
            {
                if (db.Users.Any(x => x.Email == textBoxEmail.Text))
                {
                    MessageBox.Show("هذا البريد موجود بالفعل!");
                    return;
                }

                User user = new User()
                {
                    Email = textBoxEmail.Text,
                    Name = textBoxName.Text,
                    Password = PasswordEncrypter.EncryptPassword(textBoxPassword.Text),
                    Type = UserTypes.admin
                };
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("تمت الإضافة بنجاح");
                this.Close();
            }
        }
    }
}
