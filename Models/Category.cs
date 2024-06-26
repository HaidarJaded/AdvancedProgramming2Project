
namespace APP2EFCore;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int ProductsCount { get; set; }

    public List<Product> Products { get; set; }
}