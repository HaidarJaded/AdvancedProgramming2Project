
using APP2EFCore.Properties;
using Microsoft.EntityFrameworkCore;

namespace APP2EFCore.Forms;

public partial class FormLogin : Form
{
    public bool LogoutState { get; set; }
    public FormLogin()
    {
        InitializeComponent();
    }
    private async Task<bool> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("يرجى تعبئة كل الحقول");
            return false;
        }

        using AppDBContext db = new();
        User? user =await db.Users.FirstOrDefaultAsync(x => x.Email == email
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

        FormMain formMain = new(this);
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

    private void FormLogin_Load(object sender, EventArgs e)
    {
        using AppDBContext db = new();
        if (db.Users.Any())
        {
            linkLabelCreateAccount.Visible = false;
        }
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        if (await Login(textBoxEmail.Text, textBoxPassword.Text))
        {
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
            textBoxEmail.Focus();
        }
    }

    private async void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            if (await Login(textBoxEmail.Text, textBoxPassword.Text))
            {
                textBoxEmail.Text = "";
                textBoxPassword.Text = "";
                textBoxEmail.Focus();
            }
        }
    }

    private void LinkLabelCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        FormAddAdmin formAddAdmin = new();
        formAddAdmin.ShowDialog();
        using AppDBContext db = new();
        if (db.Users.Any())
        {
            linkLabelCreateAccount.Visible = false;
        }
    }
}
