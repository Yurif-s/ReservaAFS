﻿
using AutoMapper;
using ReservaAFS.Communication.Requests;
using ReservaAFS.Domain.Repositories;
using ReservaAFS.Domain.Repositories.Reserves;
using ReservaAFS.Exception;
using ReservaAFS.Exception.ExceptionsBase;

namespace ReservaAFS.Application.UseCases.Reserves.Update;
public class UpdateReserveUseCase : IUpdateReserveUseCase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReserveUpdateOnlyRepository _repository;
    private readonly IMapper _mapper;
    public UpdateReserveUseCase(IUnitOfWork unitOfWork, IReserveUpdateOnlyRepository repository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
        _mapper = mapper;
    }
    public async Task Execute(long id, RequestReserveJson request)
    {
        Validate(request);

        var reserve = await _repository.GetById(id);

        if (reserve is null)
            throw new NotFoundException(ResourceErrorMessages.RESERVE_NOT_FOUND);

        _mapper.Map(request, reserve);

        _repository.Update(reserve);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestReserveJson request)
    {
        var validator = new ReserveValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
