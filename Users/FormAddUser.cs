using APP2EFCore.Enums;

namespace APP2EFCore.Users
{
    public partial class FormAddUser : Form
    {
        public FormAddUser()
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
            return email.Contains('@');
        }
        bool IsPasswordConfirmed(string password, string passwordConfirm)
        {
            return password == passwordConfirm;
        }
        bool ValidateInfo()
        {
            if (AreNull())
            {
                MessageBox.Show("يرجى تعبئة كل الحقول");
                return false;
            }

            if (!IsEmail(textBoxEmail.Text))
            {
                MessageBox.Show("يرجى كتابة بريد الكتروني صالح");
                return false;
            }

            if (!IsPasswordConfirmed(textBoxPassword.Text, textBoxPasswordConfirm.Text))
            {
                MessageBox.Show("يرجى تأكيد كلمة المرور بشكل صحيح");
                return false;
            }

            if (!IsPasswordValid(textBoxPassword.Text))
            {
                MessageBox.Show("كلمة المرور يجب ان تكون 8 محارف على الأقل!");
                return false;
            }
            return true;
        }
        void CleanPage()
        {
            textBoxName.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
            textBoxPasswordConfirm.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (ValidateInfo())
            {
                using AppDBContext db = new ();
                
                    if (db.Users.Any(x => x.Email == textBoxEmail.Text))
                    {
                        MessageBox.Show("هذا البريد موجود بالفعل!");
                        return;
                    }

                    User user = new()
                    {
                        Email = textBoxEmail.Text,
                        Name = textBoxName.Text,
                        Password = PasswordEncrypter.EncryptPassword(textBoxPassword.Text),
                        Type = UserTypes.casher
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("تمت الإضافة بنجاح");
                    CleanPage();
                
                textBoxName.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
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
                        Type = UserTypes.casher
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("تمت الإضافة بنجاح");
                    this.Close();
                }
            }
        }
    }
}
