using APP2EFCore.Enums;
using APP2EFCore.Helpers;
using Microsoft.EntityFrameworkCore;

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
            return email.Contains('@');
        }
        bool IsPasswordConfirmed(string password, string passwordConfirm)
        {
            return password == passwordConfirm;
        }

        private async void button1_Click(object sender, EventArgs e)
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
                MessageBox.Show("كلمة المرور يجب ان تكون 8 محارف على الأقل");
                return;
            }

            using AppDBContext db = new();
            if (await db.Users.AnyAsync(x => x.Email == textBoxEmail.Text))
            {
                MessageBox.Show("هذا البريد موجود بالفعل!");
                return;
            }

            User user = new()
            {
                Email = textBoxEmail.Text,
                Name = textBoxName.Text,
                Password = PasswordEncrypter.EncryptPassword(textBoxPassword.Text),
                Type = UserTypes.admin
            };
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
            MessageBox.Show("تمت الإضافة بنجاح");
            this.Close();
        }
    }
}
