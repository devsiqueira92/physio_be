

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.GetProfessionalAppointments.Queries.GetAll;
public record GetProfessionalAppointmentsQuery(string userId, int pageSize = 10, int page = 1) : IRequest<Result<List<MedicalAppointmentResponse>>>;
