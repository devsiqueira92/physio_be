

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetAll;
public record GetByMonthYearQuery(SchedulingMonthYearRequest by) : IRequest<Result<List<SchedulingResponse>>>;
