
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.Contact.Commands.Update;

public sealed record UpdateContactCommand(ContactUpdateRequest contact, Guid userId) : IRequest<Result>;
