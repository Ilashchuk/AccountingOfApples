namespace DAL.Models;

public class ClientDTO
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; } = null;

    public ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
}
