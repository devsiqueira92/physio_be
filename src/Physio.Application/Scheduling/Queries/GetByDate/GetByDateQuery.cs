
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetByDate;

public record GetByDateQuery(DateOnly date, string userId) : IRequest<Result<List<SchedulingWithDetailListResponse>>>;
