using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Queries.GetAccount;

internal sealed class GetAccountHandler : IRequestHandler<GetAccountQuery, Result<AccountResponse>>
{
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IContactRepository _contactRepository;
    private readonly IAddressRepository _addressRepository;

    public GetAccountHandler(IProfessionalRepository professionalRepository, IContactRepository contactRepository, IAddressRepository addressRepository)
    {
        _professionalRepository = professionalRepository;
        _contactRepository = contactRepository;
        _addressRepository = addressRepository;
    }

    public async Task<Result<AccountResponse>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetByUserIdAsync(request.userId, cancellationToken);

        if (professional is null)
            return Result.Failure<AccountResponse>(DomainErrors.Professional.ProfessionalNotFound);

        var addressList = await _addressRepository.GetAddressListAsync(professional.UserId);
        var contactList = await _contactRepository.GetContactListAsync(professional.UserId);

        var addresses = addressList.Select(address => 
            new AddressResponse(address.Id, address.Street, address.Number, address.City, address.PostalCode))
                .ToList();

        var contacts = contactList.Select(address => 
            new ContactResponse(address.Id, address.Contact, address.Type))
                .ToList();

        return new AccountResponse(
            professional.Name, 
            professional.RegisterNumber,
            addresses, 
            contacts, 
            "professional.About", 
            professional.CreatedOn, 
            professional.UserEntity.LoginType.ToString(),
            professional.BirthDate,
            professional.AppointmentValue
        );
    }
}
