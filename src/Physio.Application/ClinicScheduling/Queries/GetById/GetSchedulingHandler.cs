using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Queries.GetById;

internal sealed class GetClinicSchedulingHandler : IRequestHandler<GetClinicSchedulingQuery, Result<SchedulingResponse>>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;

    public GetClinicSchedulingHandler(IClinicSchedulingRepository clinicSchedulingRepository)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
    }

    public async Task<Result<SchedulingResponse>> Handle(GetClinicSchedulingQuery request, CancellationToken cancellationToken)
    {
            var clinicScheduling = await _clinicSchedulingRepository.GetWithDetailsAsync(Guid.Parse(request.id), cancellationToken);

            if (clinicScheduling is null)
                return Result.Failure<SchedulingResponse>(DomainErrors.Generic.NotFound);

            return new SchedulingResponse(clinicScheduling.Id, 
                    clinicScheduling.Date, 
                    clinicScheduling.PatientId, 
                    clinicScheduling.ProfessionalId, 
                    clinicScheduling.SchedulingStatusId,
                    clinicScheduling.PatientEntity.Name,
                    clinicScheduling.PatientEntity.Contact,
                    clinicScheduling.PatientEntity.BirthDate,
                    clinicScheduling.SchedulingTypeEntity.Name,

                    clinicScheduling.ProfessionalEntity.Name, 
                    clinicScheduling.SchedulingStatusEntity.Name
                );
    }
}
