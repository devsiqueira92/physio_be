using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetByDate;

internal sealed class GetByDateHandler : IRequestHandler<GetByDateQuery, Result<List<SchedulingWithDetailListResponse>>>
{
    private readonly IClinicSchedulingRepository _professionalSchedulingRepository;

    public GetByDateHandler(IClinicSchedulingRepository professionalSchedulingRepository)
    {
        _professionalSchedulingRepository = professionalSchedulingRepository;
    }

    public async Task<Result<List<SchedulingWithDetailListResponse>>> Handle(GetByDateQuery request, CancellationToken cancellationToken)
    {
        var professionalSchedulings = await _professionalSchedulingRepository.GetByDateAsync(request.date,request.userId, cancellationToken);

        if (professionalSchedulings is null)
            return Result.Failure<List<SchedulingWithDetailListResponse>>(DomainErrors.Generic.NotFound);

        var list = professionalSchedulings.Select(professionalScheduling => new SchedulingWithDetailListResponse(
                professionalScheduling.Date,
                professionalScheduling.Schedulings.Select(s => new SchedulingDetailsResponse(
                    s.Id,
                    s.PatientEntity.Name,
                    s.ProfessionalEntity.Name,
                    s.SchedulingStatusEntity.Name
                )).ToList()
            )).ToList();

        return new List<SchedulingWithDetailListResponse>(list);
    }
}
