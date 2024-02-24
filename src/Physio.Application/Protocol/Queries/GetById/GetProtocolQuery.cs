

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Queries.GetById;
public record GetProtocolQuery(string id) : IRequest<Result<ProtocolResponse>>;
