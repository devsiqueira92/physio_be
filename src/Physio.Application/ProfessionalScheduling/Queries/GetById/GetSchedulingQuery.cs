

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetById;
public record GetProfessionalSchedulingQuery(string id) : IRequest<Result<SchedulingResponse>>;
