using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetById;

internal sealed class GetProfessionalSchedulingHandler : IRequestHandler<GetProfessionalSchedulingQuery, Result<SchedulingResponse>>
{
    private readonly IProfessionalSchedulingRepository _professionalSchedulingRepository;

    public GetProfessionalSchedulingHandler(IProfessionalSchedulingRepository professionalSchedulingRepository)
    {
        _professionalSchedulingRepository = professionalSchedulingRepository;
    }

    public async Task<Result<SchedulingResponse>> Handle(GetProfessionalSchedulingQuery request, CancellationToken cancellationToken)
    {
            var professionalScheduling = await _professionalSchedulingRepository.GetWithDetailsAsync(Guid.Parse(request.id), cancellationToken);

            if (professionalScheduling is null)
                return Result.Failure<SchedulingResponse>(DomainErrors.Generic.NotFound);

            return new SchedulingResponse(professionalScheduling.Id, 
                    professionalScheduling.Date, 
                    professionalScheduling.PatientId, 
                    professionalScheduling.ProfessionalId, 
                    professionalScheduling.SchedulingStatusId,
                    professionalScheduling.PatientEntity.Name,
                    professionalScheduling.PatientEntity.Contact,
                    professionalScheduling.PatientEntity.BirthDate,
                    professionalScheduling.SchedulingTypeEntity.Name,

                    professionalScheduling.ProfessionalEntity.Name, 
                    professionalScheduling.SchedulingStatusEntity.Name
                );
    }
}
