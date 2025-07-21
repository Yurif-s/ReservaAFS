using Bogus;
using ReservaAFS.Communication.Enums;
using ReservaAFS.Communication.Requests;

namespace CommonTestsUtilities.Requests;
public class RequestReserveJsonBuilder
{
    public static RequestReserveJson Build()
    {
        return new Faker<RequestReserveJson>()
            .RuleFor(request => request.ReservationTime, faker => faker.Date.Future())
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.ReserveType, f => f.PickRandom<ReserveType>());
    }
}
