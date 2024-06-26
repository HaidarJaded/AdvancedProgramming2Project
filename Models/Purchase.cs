namespace APP2EFCore;

public class Purchase
{
    public int Id { get; set; }
    public int ProductsCount { get; set; }
    public required decimal ProductPrice { get; set; }
    public decimal ProductsTotalPrice { get; set; }
    public System.DateTime Date { get; set; }

    public Invoice Invoice { get; set; }
    public Product Product { get; set; }
}