using APP2EFCore.Enums;
using Microsoft.EntityFrameworkCore;

namespace APP2EFCore.Invoices
{
    public partial class FormInvoiceInfo : Form
    {
        Invoice? invoice;
        public FormInvoiceInfo(int invoiceID)
        {
            using AppDBContext db = new();

            this.invoice = db.Invoices
                .Include(i => i.Purchases)
                .ThenInclude(pu => pu.Product)
                .ThenInclude(p => p.Category)
                .Include(i => i.Sales)
                .ThenInclude(s => s.Product)
                .ThenInclude(p => p.Category)
                .Include(i => i.Sales)
                .ThenInclude(s => s.User)
                .FirstOrDefault(i => i.Id == invoiceID);

            InitializeComponent();
        }


        private void FormInvoiceInfo_Load(object sender, EventArgs e)
        {
            if (invoice is null) return;
            if (invoice.Type == InvoiceType.sale)
            {
                var sales = invoice.Sales.Select(s => new
                {
                    s.Id,
                    s.Product.Name,
                    CategoryName = s.Product.Category.Name,
                    s.ProductsCount,
                    s.ProductPrice,
                    s.ProductsTotalPrice,
                    InvoiceId = s.Invoice.Id,
                    s.Date,
                    UserName = s.User.Name
                }).ToList();

                DGVInvoiceInfo.DataSource = sales;
                DGVInvoiceInfo.Columns[0].Visible = false;
                DGVInvoiceInfo.Columns[1].HeaderText = "اسم المنتج";
                DGVInvoiceInfo.Columns[2].HeaderText = "الصنف";
                DGVInvoiceInfo.Columns[3].HeaderText = "الكمية";
                DGVInvoiceInfo.Columns[4].HeaderText = "السعر";
                DGVInvoiceInfo.Columns[5].HeaderText = "السعر الاجمالي";
                DGVInvoiceInfo.Columns[6].HeaderText = "رقم الفاتورة";
                DGVInvoiceInfo.Columns[7].HeaderText = "تاريخ البيع";
                DGVInvoiceInfo.Columns[8].HeaderText = "اسم البائع";

            }
            else
            {
                var purchases = invoice.Purchases.Select(p => new
                {
                    p.Id,
                    ProductName = p.Product.Name,
                    CategoryName = p.Product.Category.Name,
                    p.ProductsCount,
                    p.ProductPrice,
                    p.ProductsTotalPrice,
                    InvoiceId = p.Invoice.Id,
                    p.Date
                }).ToList();

                DGVInvoiceInfo.DataSource = purchases;
                DGVInvoiceInfo.Columns[0].Visible = false;
                DGVInvoiceInfo.Columns[1].HeaderText = "اسم المنتج";
                DGVInvoiceInfo.Columns[2].HeaderText = "الصنف";
                DGVInvoiceInfo.Columns[3].HeaderText = "الكمية";
                DGVInvoiceInfo.Columns[4].HeaderText = "سعر المنتج";
                DGVInvoiceInfo.Columns[5].HeaderText = "السعر الاجمالي";
                DGVInvoiceInfo.Columns[6].HeaderText = "رقم الفاتورة";
                DGVInvoiceInfo.Columns[7].HeaderText = "تاريخ الشراء";
            }
        }
    }
}
