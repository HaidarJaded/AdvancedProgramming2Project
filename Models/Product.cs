using APP2EFCore.Models;

namespace APP2EFCore;
public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public  decimal Price { get; set; }
    public  decimal PurchasePrice { get; set; }
    public int Count { get; set; }
    public Section? Section { get; set; }
    public  Category Category { get; set; }
    public List<Purchase> Purchases { get; set; }
    public List<Sale> Sales { get; set; }
}