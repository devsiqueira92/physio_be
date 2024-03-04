
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.MedicalAppointment.Commands.Create;

public sealed record CreateMedicalAppointmentCommand(MedicalAppointmentCreateRequest medicalAppointment, Guid userId) : IRequest<Result<MedicalAppointmentResponse>>;
