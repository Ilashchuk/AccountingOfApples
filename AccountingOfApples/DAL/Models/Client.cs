namespace DAL.Models;

public class Client
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; } = null;

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
