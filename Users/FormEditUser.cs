namespace APP2EFCore.Users
{
    public partial class FormEditUser : Form
    {
        User user;
        AppDBContext db;
        public FormEditUser(User user,AppDBContext db)
        {
            this.user = user;
            this.db = db;
            InitializeComponent();
        }
        bool IsEmail(string email)
        {
            return email.Contains("@");
        }
        bool AreNull()
        {
            return string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                   string.IsNullOrWhiteSpace(textBoxName.Text);
        }


        private void FormEditUser_Load(object sender, EventArgs e)
        {
            textBoxName.Text = user.Name;
            textBoxEmail.Text = user.Email;
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
            using (db)
            {
                user.Email = textBoxEmail.Text;
                user.Name = textBoxName.Text;
                db.SaveChanges();
                MessageBox.Show("تم تعديل البيانات");
                this.Close();
            }
        }
    }
}
