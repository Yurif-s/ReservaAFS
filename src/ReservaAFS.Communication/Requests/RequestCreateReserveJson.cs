using ReservaAFS.Communication.Enums;

namespace ReservaAFS.Communication.Requests;
public class RequestCreateReserveJson
{
    public DateTime ReservationTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public ReserveType ReserveType { get; set; }
}
