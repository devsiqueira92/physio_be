

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetById;
public record GetSchedulingQuery(string id) : IRequest<Result<SchedulingResponse>>;
