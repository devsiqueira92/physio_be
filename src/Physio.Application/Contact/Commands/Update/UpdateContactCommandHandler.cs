using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Commands.Update;

internal sealed class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Result>
{
    private readonly IContactRepository _contactRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IContactRepository contactRepository, IUnitOfWork unitOfWork)
    {
        _contactRepository = contactRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _contactRepository.GetAsync(request.contact.id);
        if (contact is not null)
        {
            contact.Update(request.contact.contact, request.contact.type, request.userId);

            _contactRepository.Update(contact);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<ContactResponse>(DomainErrors.Generic.UpdateError);

    }
}
