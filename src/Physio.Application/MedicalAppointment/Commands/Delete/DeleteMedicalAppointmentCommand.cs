
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.MedicalAppointment.Commands.Delete;

public sealed record DeleteMedicalAppointmentCommand(string medicalAppointment, Guid userId) : IRequest<Result>;
