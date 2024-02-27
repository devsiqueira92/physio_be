using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Commands.Create;

internal sealed class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Result<ContactResponse>>
{
    private readonly IContactRepository _contactRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ContactResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var newContact = ContactEntity.Create(
            request.contact.contact, 
            request.contact.type,
            request.userId
        );

        if (newContact.IsSuccess)
        {
            await _contactRepository.CreateAsync(newContact.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new ContactResponse(newContact.Value.Id, newContact.Value.Contact, newContact.Value.Type);
        }

        return Result.Failure<ContactResponse>(newContact.Error);
    }
}
