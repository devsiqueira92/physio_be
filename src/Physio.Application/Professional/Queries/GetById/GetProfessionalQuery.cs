

using MediatR;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Queries.GetById;
public record GetProfessionalQuery(string id) : IRequest<Result<ProfessionalResponse>>;
