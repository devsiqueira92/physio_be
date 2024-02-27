

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Queries.GetAccount;
public record GetAccountQuery(string userId) : IRequest<Result<AccountResponse>>;
