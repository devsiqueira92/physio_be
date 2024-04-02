

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Queries.GetById;
public record GetSchedulingTypeQuery(string id) : IRequest<Result<SchedulingTypeResponse>>;
