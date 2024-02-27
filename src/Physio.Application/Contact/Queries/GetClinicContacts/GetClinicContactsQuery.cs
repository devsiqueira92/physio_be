

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Contact.Queries.GetClinicContacts;
public record GetClinicContactsQuery(string userId) : IRequest<Result<List<ContactResponse>>>;
