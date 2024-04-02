

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.SchedulingType.Queries.GetAll;
public record GetSchedulingTypesQuery() : IRequest<Result<List<SchedulingTypeResponse>>>;
