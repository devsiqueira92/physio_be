

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Queries.GetById;
public record GetClinicSchedulingQuery(string id) : IRequest<Result<SchedulingResponse>>;
