

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Queries.GetAll;
public record GetClinicSchedulingsQuery(int pageSize = 10, int page = 1) : IRequest<Result<List<SchedulingResponse>>>;
