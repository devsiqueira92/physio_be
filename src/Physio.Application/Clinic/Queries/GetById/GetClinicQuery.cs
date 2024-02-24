

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Queries.GetById;
public record GetClinicQuery(string id) : IRequest<Result<ClinicResponse>>;
