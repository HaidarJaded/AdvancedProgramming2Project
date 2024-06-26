using System.ComponentModel.DataAnnotations.Schema;

namespace APP2EFCore;

public class Sale
{
    public int Id { get; set; }
    public int ProductsCount { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal ProductsTotalPrice { get; set; }
    public System.DateTime Date { get; set; }
    public decimal profitRatio { get; set; }
    public  Invoice Invoice { get; set; }
    public  Product Product { get; set; }
    public  User User { get; set; }
}