using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Scheduling.Queries.GetById;
internal sealed class GetSchedulingHandler : IRequestHandler<GetSchedulingQuery, Result<SchedulingResponse>>
{
    private readonly ISchedulingRepository _schedulingRepository;

    public GetSchedulingHandler(ISchedulingRepository schedulingRepository)
    {
        _schedulingRepository = schedulingRepository;
    }

    public async Task<Result<SchedulingResponse>> Handle(GetSchedulingQuery request, CancellationToken cancellationToken)
    {
        var scheduling = await _schedulingRepository.GetWithDetailsAsync(Guid.Parse(request.id), cancellationToken);

        if (scheduling is null)
            return Result.Failure<SchedulingResponse>(DomainErrors.Generic.NotFound);

        return new SchedulingResponse(
            scheduling.Id, 
            scheduling.Date, 
            scheduling.PatientId, 
            scheduling.ProfessionalId, 
        
            schedulingTypeId: scheduling.SchedulingTypeId, 
            schedulingStatusId: scheduling.SchedulingStatusId,
            patientName: scheduling.PatientEntity.Name,
            patientContact: scheduling.PatientEntity.Contact,
            patientBirthDate: scheduling.PatientEntity.BirthDate,
            professionalName: scheduling.ProfessionalEntity.Name
        );
    }
}
