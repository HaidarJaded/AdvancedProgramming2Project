
using APP2EFCore.Properties;

namespace APP2EFCore.Forms;

public partial class FormLogin : Form
{
    private bool Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("يرجى تعبئة كل الحقول");
            return false;
        }

        using (AppDBContext db = new AppDBContext())
        {
            User user = db.Users.FirstOrDefault(x => x.Email == email
                                                && x.Password == PasswordEncrypter.EncryptPassword(password));

            if (user == null)
            {
                MessageBox.Show("المستخدم غير موجود أو المعلومات خاطئة!");
                return false;
            }

            MessageBox.Show("تم تسجيل الدخول بنجاح!");

            Settings.Default.CurrentUserName = user.Name;
            Settings.Default.CurrentUserEmail = user.Email;
            Settings.Default.CurrentUserId = user.Id;
            Settings.Default.CurrentUserType = user.Type.ToString();

            Forms.FormMain formMain = new Forms.FormMain();
            this.Visible = false;
            formMain.ShowDialog();
            this.Visible = true;

            return true;
        }
    }
    public FormLogin()
    {
        InitializeComponent();
    }

    private void FormLogin_Load(object sender, EventArgs e)
    {
        AppDBContext db = new AppDBContext();
        if (db.Users.Count() != 0)
        {
            linkLabelCreateAccount.Visible = false;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (Login(textBoxEmail.Text, textBoxPassword.Text))
        {
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
        }
    }

    private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            if (Login(textBoxEmail.Text, textBoxPassword.Text))
            {
                textBoxEmail.Text = "";
                textBoxPassword.Text = "";
            }
        }
    }

    private void linkLabelCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        Forms.FormAddAdmin formAddAdmin = new Forms.FormAddAdmin();
        formAddAdmin.ShowDialog();
        AppDBContext db = new AppDBContext();
        if (db.Users.Count() != 0)
        {
            linkLabelCreateAccount.Visible = false;
        }
    }
}
