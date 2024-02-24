
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.Patient.Commands.Delete;

public sealed record DeletePatientCommand(string patient, Guid userId) : IRequest<Result>;
