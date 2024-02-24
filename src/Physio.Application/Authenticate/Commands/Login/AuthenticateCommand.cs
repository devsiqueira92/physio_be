
using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Requests;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Authenticate.Commands.Login;

public sealed record AuthenticateCommand(LoginRequest credentials) : IRequest<Result<AuthenticationResponse>>;
