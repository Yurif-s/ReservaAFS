using ReservaAFS.Domain.Enums;

namespace ReservaAFS.Domain.Entities;
public class Reserve
{
    public long Id { get; set; }
    public DateTime ReservationTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public ReserveType ReserveType { get; set; }
}
