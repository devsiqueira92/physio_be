using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Address.Commands.Create;

internal sealed class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, Result<AddressResponse>>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAddressCommandHandler(IAddressRepository addressRepository, IUnitOfWork unitOfWork)
    {
        _addressRepository = addressRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<AddressResponse>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var newAddress = AddressEntity.Create(
            request.address.street,
            request.address.number,
            request.address.city,
            request.address.postalCode,
            request.userId
        );

        if (newAddress.IsSuccess)
        {
            await _addressRepository.CreateAsync(newAddress.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new AddressResponse(newAddress.Value.Id, 
                newAddress.Value.Street,
                newAddress.Value.Number,
                newAddress.Value.City,
                newAddress.Value.PostalCode
            );
        }

        return Result.Failure<AddressResponse>(newAddress.Error);
    }
}
