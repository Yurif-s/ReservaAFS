using ReservaAFS.Communication.Enums;

namespace ReservaAFS.Communication.Responses;
public class ResponseReserveJson
{
    public long Id { get; set; }
    public DateTime ReservationTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public ReserveType ReserveType { get; set; }
}
