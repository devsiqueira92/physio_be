
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Authenticate.Commands.Register;

public sealed record RegisterCommand(RegisterRequest credentials) : IRequest<Result<AuthenticationResponse>>;
