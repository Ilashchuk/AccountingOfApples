namespace AccountingOfApples.ViewModels;

public class OrderViewModel
{
    public Guid? Id { get; set; }

    public DateOnly? Date { get; set; }

    public Guid? ClientId { get; set; }

    public ClientViewModel? Client { get; set; } 

    public List<OrderAppleVarietyViewModel>? orderAppleVarietyList { get; set; }
}
