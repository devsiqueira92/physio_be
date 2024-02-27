

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Address.Queries.GetProfessionalAddresses;
public record GetProfessionalAddressesQuery(string userId) : IRequest<Result<List<AddressResponse>>>;
