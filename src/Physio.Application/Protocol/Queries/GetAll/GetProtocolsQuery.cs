

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Protocol.Queries.GetAll;
public record GetProtocolsQuery(int pageSize = 10, int page = 1) : IRequest<Result<List<ProtocolResponse>>>;
