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
        CreateMap<RequestEquipmentJson, Equipment>();
        CreateMap<RequestCreateUserJson, User>();
        CreateMap<RequestUpdateUserJson, User>();
    }
    private void EntityToResponse()
    {
        CreateMap<Equipment, ResponseCreatedEquipmentJson>();
        CreateMap<Equipment, ResponseEquipmentJson>();
        CreateMap<Reserve, ResponseCreatedReserveJson>();
        CreateMap<Reserve, ResponseShortReserveJson>();
        CreateMap<Reserve, ResponseReserveJson>();
        CreateMap<User, ResponseCreatedUserJson>();
        CreateMap<User, ResponseShortUserJson>();
        CreateMap<User, ResponseUserJson>();
    }
}
