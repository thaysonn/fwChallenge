namespace fw.Domain.Leads;

public class Category : BaseEntity
{
    private Category() { }
    public Category(string? description) => Description = description;  
    public string? Description { get; private set; }
}
