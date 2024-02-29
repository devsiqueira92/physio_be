

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetByMonthYear;
public record GetByMonthYearQuery(SchedulingMonthYearRequest by, string userId) : IRequest<Result<List<SchedulingResponse>>>;
