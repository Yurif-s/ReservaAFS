using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Communication.Responses;
using ReservaAFS.Domain.Entities;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Users.Create;
public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IMapper _mapper;
    public CreateUserUseCase(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task<ResponseCreatedUserJson> Execute(RequestUserJson request)
    {
        Validate(request);

        var user = _mapper.Map<User>(request);

        return _mapper.Map<ResponseCreatedUserJson>(user);
    }

    private void Validate(RequestUserJson request)
    {
        var validator = new UserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
