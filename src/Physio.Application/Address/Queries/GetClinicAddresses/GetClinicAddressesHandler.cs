using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Address.Queries.GetClinicAddresses;

internal sealed class GetClinicAddressesHandler : IRequestHandler<GetClinicAddressesQuery, Result<List<AddressResponse>>>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IClinicRepository _clinicRepository;

    public GetClinicAddressesHandler(IAddressRepository addressRepository, IClinicRepository clinicRepository)
    {
        _addressRepository = addressRepository;
        _clinicRepository = clinicRepository;
    }

    public async Task<Result<List<AddressResponse>>> Handle(GetClinicAddressesQuery request, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetUserIdAsync(request.userId, cancellationToken);
        if (clinic is null)
            return Result.Failure<List<AddressResponse>>(DomainErrors.Clinic.ClinicNotFound);

        var addressList = await _addressRepository.GetAddressListAsync(clinic.UserId);

        var list = addressList.Select(
                address => new AddressResponse(
                    address.Id,
                    address.Street,
                    address.Number,
                    address.City,
                    address.PostalCode
                )
            ).ToList();

        return new List<AddressResponse>(list);
    }
}
