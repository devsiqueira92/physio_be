
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Commands.Create;

public sealed record CreateClinicCommand(ClinicCreateRequest clinic, Guid userId) : IRequest<Result<AuthenticationResponse>>;
