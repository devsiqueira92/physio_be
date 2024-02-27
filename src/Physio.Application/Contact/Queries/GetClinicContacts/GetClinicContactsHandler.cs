using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Queries.GetClinicContacts;

internal sealed class GetClinicContactsHandler : IRequestHandler<GetClinicContactsQuery, Result<List<ContactResponse>>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IClinicRepository _clinicRepository;

    public GetClinicContactsHandler(IContactRepository contactRepository, IClinicRepository clinicRepository)
    {
        _contactRepository = contactRepository;
        _clinicRepository = clinicRepository;
    }

    public async Task<Result<List<ContactResponse>>> Handle(GetClinicContactsQuery request, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetByUserIdAsync(request.userId, cancellationToken);
        if (clinic is null)
                return Result.Failure<List<ContactResponse>>(DomainErrors.Clinic.ClinicNotFound);

        var contactList = await _contactRepository.GetContactListAsync(clinic.UserId);

            var list = contactList.Select(
                    contact => new ContactResponse(
                        contact.Id,
                        contact.Contact,
                        contact.Type
                    )
                ).ToList();

            return new List<ContactResponse>(list);
    }
}
