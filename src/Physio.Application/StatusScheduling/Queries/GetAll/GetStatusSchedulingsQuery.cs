

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.StatusScheduling.Queries.GetAll;
public record GetStatusSchedulingsQuery() : IRequest<Result<List<StatusSchedulingResponse>>>;
