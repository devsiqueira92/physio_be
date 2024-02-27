using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Queries.GetById;

internal sealed class GetContactHandler : IRequestHandler<GetContactQuery, Result<ContactResponse>>
{
    private readonly IContactRepository _contactRepository;

    public GetContactHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<Result<ContactResponse>> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
            var contact = await _contactRepository.GetAsync(request.id, cancellationToken);

            if (contact is null)
                return Result.Failure<ContactResponse>(DomainErrors.Generic.NotFound);

            return new ContactResponse(
                    contact.Id,
                    contact.Contact,
                    contact.Type
                );
    }
}
