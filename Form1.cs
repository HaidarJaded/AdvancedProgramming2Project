using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace APP2EFCore;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        AppDBContext appDB = new AppDBContext();
        try
        {
            User user = new User();
            user.Email = "asd";
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
