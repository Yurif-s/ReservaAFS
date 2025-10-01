namespace ReservaAFS.Domain.Entities;
public class Reserve
{
    public long Id { get; set; }
    public DateTime ReservationTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Class { get; set; }
    public long EquipmentId { get; set; }
    public Equipment Equipment { get; set; } = default!;
    public long UserId { get; set; }
    public User User { get; set; } = default!;

}
