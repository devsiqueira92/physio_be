using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Queries.GetByDate;

internal sealed class GetByDateHandler : IRequestHandler<GetByDateQuery, Result<List<SchedulingWithDetailListResponse>>>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;

    public GetByDateHandler(IClinicSchedulingRepository clinicSchedulingRepository)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
    }

    public async Task<Result<List<SchedulingWithDetailListResponse>>> Handle(GetByDateQuery request, CancellationToken cancellationToken)
    {
        var clinicSchedulings = await _clinicSchedulingRepository.GetByDateAsync(request.date,request.userId, cancellationToken);

        if (clinicSchedulings is null)
            return Result.Failure<List<SchedulingWithDetailListResponse>>(DomainErrors.Generic.NotFound);

        var list = clinicSchedulings.Select(clinicScheduling => new SchedulingWithDetailListResponse(
                clinicScheduling.Date,
                clinicScheduling.Schedulings.Select(s => new SchedulingDetailsResponse(
                    s.Id,
                    s.PatientEntity.Name,
                    s.ProfessionalEntity.Name,
                    s.SchedulingStatusEntity.Name
                )).ToList()
            )).ToList();

        return new List<SchedulingWithDetailListResponse>(list);
    }
}
