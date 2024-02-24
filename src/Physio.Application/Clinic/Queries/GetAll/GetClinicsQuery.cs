

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Queries.GetAll;
public record GetClinicsQuery(int pageSize = 10, int page = 1) : IRequest<Result<List<ClinicResponse>>>;
