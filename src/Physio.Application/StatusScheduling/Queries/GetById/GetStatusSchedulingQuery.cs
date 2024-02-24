

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Queries.GetById;
public record GetStatusSchedulingQuery(string id) : IRequest<Result<StatusSchedulingResponse>>;
