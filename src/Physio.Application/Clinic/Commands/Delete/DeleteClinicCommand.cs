
using MediatR;
using Physio.Domain.Shared;

namespace Physio.Application.Clinic.Commands.Delete;

public sealed record DeleteClinicCommand(string clinic, Guid userId) : IRequest<Result>;
