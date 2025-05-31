using ReservaAFS.Communication.Enums;

namespace ReservaAFS.Communication.Responses;
public class ResponseCreateReserveJson
{
    public long ReserveId { get; set; }
    public ReserveType ReserveType { get; set; }
    public DateTime ReservationTime { get; set; }
}
