
using APP2EFCore.Properties;

namespace APP2EFCore.Forms;

public partial class FormLogin : Form
{
    public bool LogoutState { get; set; }
    bool logoutState;
    public FormLogin()
    {
        InitializeComponent();
    }
    private bool Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("يرجى تعبئة كل الحقول");
            return false;
        }

        using (AppDBContext db = new AppDBContext())
        {
            User? user = db.Users.FirstOrDefault(x => x.Email == email
                                                && x.Password == PasswordEncrypter.EncryptPassword(password));

            if (user is null)
            {
                MessageBox.Show("المستخدم غير موجود أو المعلومات خاطئة!");
                return false;
            }

            MessageBox.Show("تم تسجيل الدخول بنجاح!");

            Settings.Default.CurrentUserName = user.Name;
            Settings.Default.CurrentUserEmail = user.Email;
            Settings.Default.CurrentUserId = user.Id;
            Settings.Default.CurrentUserType = user.Type.ToString();

            FormMain formMain = new FormMain(this);
            this.Visible = false;
            formMain.ShowDialog();
            if (!LogoutState)
            {
                this.Close();
                return true;
            }
            this.Visible = true;

            return true;
        }
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
            textBoxEmail.Focus();
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
                textBoxEmail.Focus();
            }
        }
    }

    private void linkLabelCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      FormAddAdmin formAddAdmin = new FormAddAdmin();
        formAddAdmin.ShowDialog();
        AppDBContext db = new AppDBContext();
        if (db.Users.Count() != 0)
        {
            linkLabelCreateAccount.Visible = false;
        }
    }
}
