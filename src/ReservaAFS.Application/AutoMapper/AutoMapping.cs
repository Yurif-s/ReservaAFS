using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Entities;

namespace ReservaAFS.Application.AutoMapper;
public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestReserveJson, Reserve>();
    }
    private void EntityToResponse()
    {
        CreateMap<Reserve, ResponseCreatedReserveJson>();
        CreateMap<Reserve, ResponseShortReserveJson>();
        CreateMap<Reserve, ResponseReserveJson>();
    }
}
