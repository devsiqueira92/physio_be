

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Address.Queries.GetClinicAddresses;
public record GetClinicAddressesQuery(string userId) : IRequest<Result<List<AddressResponse>>>;
