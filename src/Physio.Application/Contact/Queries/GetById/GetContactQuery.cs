

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Queries.GetById;
public record GetContactQuery(Guid id) : IRequest<Result<ContactResponse>>;
