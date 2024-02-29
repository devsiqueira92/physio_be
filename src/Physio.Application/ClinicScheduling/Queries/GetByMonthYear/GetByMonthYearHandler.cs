using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Queries.GetByMonthYear;

internal sealed class GetByMonthYearHandler : IRequestHandler<GetByMonthYearQuery, Result<List<SchedulingResponse>>>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;

    public GetByMonthYearHandler(IClinicSchedulingRepository clinicSchedulingRepository)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
    }

    public async Task<Result<List<SchedulingResponse>>> Handle(GetByMonthYearQuery request, CancellationToken cancellationToken)
    {

        var clinicSchedulings = await _clinicSchedulingRepository.GetByMonthYearAsync(request.by.month, request.by.year, request.userId);

        var list = clinicSchedulings.Select(scheduling => new SchedulingResponse(scheduling.Id, scheduling.Date, scheduling.PatientId, scheduling.ProfessionalId, scheduling.SchedulingStatusId)).ToList();

        return new List<SchedulingResponse>(list);
    }
}
