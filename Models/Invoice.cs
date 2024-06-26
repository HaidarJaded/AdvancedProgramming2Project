using APP2EFCore.Enums;

namespace APP2EFCore;

public class Invoice
{
    public int Id { get; set; }
    public required InvoiceType Type { get; set; }
    public decimal? Total { get; set; }
    public System.DateTime Date { get; set; }

    public virtual List<Purchase> Purchases { get; set; }
    public virtual List<Sale> Sales { get; set; }
}