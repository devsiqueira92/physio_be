using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Queries.GetById;

internal sealed class GetProfessionalHandler : IRequestHandler<GetProfessionalQuery, Result<ProfessionalResponse>>
{
    private readonly IProfessionalRepository _professionalRepository;

    public GetProfessionalHandler(IProfessionalRepository professionalRepository)
    {
        _professionalRepository = professionalRepository;
    }

    public async Task<Result<ProfessionalResponse>> Handle(GetProfessionalQuery request, CancellationToken cancellationToken)
    {
            var professional = await _professionalRepository.GetAsync(Guid.Parse(request.id), cancellationToken);

            if (professional is null)
                return Result.Failure<ProfessionalResponse>(DomainErrors.Generic.NotFound);

            return new ProfessionalResponse(
                    professional.Id,
                    professional.Name,
                    professional.BirthDate,
                    professional.Contact,
                    professional.RegisterNumber,
                    professional.AppointmentValue
                );
    }
}
