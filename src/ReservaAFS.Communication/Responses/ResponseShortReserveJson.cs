using ReservaAFS.Communication.Enums;

namespace ReservaAFS.Communication.Responses;
public class ResponseShortReserveJson
{
    public long Id { get; set; }
    public DateTime ReservationTime { get; set; }
    public ReserveType ReserveType { get; set; }
}
