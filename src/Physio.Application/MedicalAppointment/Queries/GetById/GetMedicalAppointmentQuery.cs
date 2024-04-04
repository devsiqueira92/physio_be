using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.MedicalAppointment.Queries.GetById;

public record GetMedicalAppointmentQuery(string id) : IRequest<Result<MedicalAppointmentResponse>>;
