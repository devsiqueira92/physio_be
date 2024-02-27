using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Queries.GetProfessionalContacts;

internal sealed class GetProfessionalContactsHandler : IRequestHandler<GetProfessionalContactsQuery, Result<List<ContactResponse>>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IProfessionalRepository _professionalRepository;

    public GetProfessionalContactsHandler(IContactRepository contactRepository, IProfessionalRepository professionalRepository)
    {
        _contactRepository = contactRepository;
        _professionalRepository = professionalRepository;
    }

    public async Task<Result<List<ContactResponse>>> Handle(GetProfessionalContactsQuery request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetUserIdAsync(request.userId, cancellationToken);
        if (professional is null)
                return Result.Failure<List<ContactResponse>>(DomainErrors.Professional.ProfessionalNotFound);

        var contactList = await _contactRepository.GetContactListAsync(professional.UserId);

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
