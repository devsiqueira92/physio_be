using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Address.Queries.GetProfessionalAddresses;

internal sealed class GetProfessionalAddressesHandler : IRequestHandler<GetProfessionalAddressesQuery, Result<List<AddressResponse>>>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IProfessionalRepository _professionalRepository;

    public GetProfessionalAddressesHandler(IAddressRepository addressRepository, IProfessionalRepository professionalRepository)
    {
        _addressRepository = addressRepository;
        _professionalRepository = professionalRepository;
    }

    public async Task<Result<List<AddressResponse>>> Handle(GetProfessionalAddressesQuery request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetUserIdAsync(request.userId, cancellationToken);
        if (professional is null)
            return Result.Failure<List<AddressResponse>>(DomainErrors.Professional.ProfessionalNotFound);

        var addressList = await _addressRepository.GetAddressListAsync(professional.UserId);

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
