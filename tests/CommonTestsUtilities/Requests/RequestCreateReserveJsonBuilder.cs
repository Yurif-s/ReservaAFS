using Bogus;
using ReservaAFS.Communication.Enums;
using ReservaAFS.Communication.Requests;

namespace CommonTestsUtilities.Requests;
public class RequestCreateReserveJsonBuilder
{
    public static RequestCreateReserveJson Build()
    {
        return new Faker<RequestCreateReserveJson>()
            .RuleFor(request => request.ReservationTime, faker => faker.Date.Future())
            .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
            .RuleFor(r => r.ReserveType, f => f.PickRandom<ReserveType>());
    }
}
