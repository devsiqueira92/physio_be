using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;
using static Physio.Domain.Errors.DomainErrors;

namespace Physio.Application.Clinic.Queries.GetAccount;

internal sealed class GetAccountHandler : IRequestHandler<GetAccountQuery, Result<AccountResponse>>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IContactRepository _contactRepository;
    private readonly IAddressRepository _addressRepository;

    public GetAccountHandler(IClinicRepository clinicRepository, IContactRepository contactRepository, IAddressRepository addressRepository)
    {
        _clinicRepository = clinicRepository;
        _contactRepository = contactRepository;
        _addressRepository = addressRepository;
    }

    public async Task<Result<AccountResponse>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetByUserIdAsync(request.userId, cancellationToken);

        if (clinic is null)
            return Result.Failure<AccountResponse>(DomainErrors.Clinic.ClinicNotFound);

        var addressList = await _addressRepository.GetAddressListAsync(clinic.UserId);
        var contactList = await _contactRepository.GetContactListAsync(clinic.UserId);

        var addresses = addressList.Select(address =>
            new AddressResponse(address.Id, address.Street, address.Number, address.City, address.PostalCode))
                .ToList();

        var contacts = contactList.Select(address =>
            new ContactResponse(address.Id, address.Contact, address.Type))
                .ToList();

        return new AccountResponse(clinic.Name, clinic.IdentificationNumber, addresses, contacts, "", clinic.CreatedOn, clinic.UserEntity.LoginType.ToString());
    }
}
