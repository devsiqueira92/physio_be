
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.MedicalAppointment.Commands.Update;

public sealed record UpdateMedicalAppointmentCommand(MedicalAppointmentUpdateRequest medicalAppointment, Guid userId) : IRequest<Result>;
