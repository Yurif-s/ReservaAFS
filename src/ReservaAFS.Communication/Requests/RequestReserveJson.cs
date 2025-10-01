using ReservaAFS.Communication.Enums;

namespace ReservaAFS.Communication.Requests;
public class RequestReserveJson
{
    public DateTime ReservationTime { get; set; }
    public string Description { get; set; } = string.Empty;
    public long IdEquipment { get; set; }
    public long IdUser { get; set; }
    //public long IdClass { get; set; }
    public int Class { get; set; }
}
