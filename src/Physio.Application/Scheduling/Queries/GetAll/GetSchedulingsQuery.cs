

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetAll;
public record GetSchedulingsQuery(int pageSize = 10, int page = 1) : IRequest<Result<List<SchedulingResponse>>>;
