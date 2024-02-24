
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;

namespace Physio.Application.Clinic.Commands.Update;

public sealed record UpdateClinicCommand(ClinicUpdateRequest clinic, Guid userId) : IRequest<Result>;
