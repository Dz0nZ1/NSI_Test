namespace Test.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public Company Company { get; private set; }

    
    private Product(){}
    
    public Product(Guid id, string name, string description, Company company)
    {
        Id = id;
        Name = name;
        Description = description;
        Company = company;
    }
}