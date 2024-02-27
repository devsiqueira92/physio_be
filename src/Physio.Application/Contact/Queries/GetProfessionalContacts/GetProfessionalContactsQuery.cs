

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Queries.GetProfessionalContacts;
public record GetProfessionalContactsQuery(string userId) : IRequest<Result<List<ContactResponse>>>;
