

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Queries.GetAll;
public record GetPatientsQuery(int pageSize = 10, int page = 1) : IRequest<Result<List<PatientResponse>>>;
