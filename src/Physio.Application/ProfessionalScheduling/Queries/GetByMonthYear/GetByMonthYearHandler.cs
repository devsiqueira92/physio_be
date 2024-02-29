using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetByMonthYear;

internal sealed class GetByMonthYearHandler : IRequestHandler<GetByMonthYearQuery, Result<List<SchedulingResponse>>>
{
    private readonly IProfessionalSchedulingRepository _professionalSchedulingRepository;

    public GetByMonthYearHandler(IProfessionalSchedulingRepository professionalSchedulingRepository)
    {
        _professionalSchedulingRepository = professionalSchedulingRepository;
    }

    public async Task<Result<List<SchedulingResponse>>> Handle(GetByMonthYearQuery request, CancellationToken cancellationToken)
    {

        var professionalSchedulings = await _professionalSchedulingRepository.GetByMonthYearAsync(request.by.month, request.by.year, request.userId);

        var list = professionalSchedulings.Select(scheduling => new SchedulingResponse(scheduling.Id, scheduling.Date, scheduling.PatientId, scheduling.ProfessionalId, scheduling.SchedulingStatusId)).ToList();

        return new List<SchedulingResponse>(list);
    }
}
