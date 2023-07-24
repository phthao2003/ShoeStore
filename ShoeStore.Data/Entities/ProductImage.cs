namespace ShoeStore.Data.Entities;

public class ProductImage
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public Guid ProductId { get; set; }

    public Product Product { get; set; }
}