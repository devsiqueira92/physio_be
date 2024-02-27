
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Address.Commands.Create;

public sealed record CreateAddressCommand(AddressCreateRequest address, string userId) : IRequest<Result<AddressResponse>>;
