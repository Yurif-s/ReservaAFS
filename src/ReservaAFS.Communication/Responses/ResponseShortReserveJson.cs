using ReservaAFS.Communication.Enums;

namespace ReservaAFS.Communication.Responses;
public class ResponseShortReserveJson
{
    public DateTime ReservationTime { get; set; }
    public ReserveType ReserveType { get; set; }
}
