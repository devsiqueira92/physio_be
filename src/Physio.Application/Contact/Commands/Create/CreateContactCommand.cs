
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Commands.Create;

public sealed record CreateContactCommand(ContactCreateRequest contact, Guid userId) : IRequest<Result<ContactResponse>>;
