using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicScheduling.Queries.GetAll;

internal sealed class GetClinicSchedulingsHandler : IRequestHandler<GetClinicSchedulingsQuery, Result<List<SchedulingResponse>>>
{
    private readonly IClinicSchedulingRepository _clinicSchedulingRepository;

    public GetClinicSchedulingsHandler(IClinicSchedulingRepository clinicSchedulingRepository)
    {
        _clinicSchedulingRepository = clinicSchedulingRepository;
    }

    public async Task<Result<List<SchedulingResponse>>> Handle(GetClinicSchedulingsQuery request, CancellationToken cancellationToken)
    {
            var clinicSchedulings = await _clinicSchedulingRepository.GetAllAsync(request.page, request.pageSize, cancellationToken);

            if (!clinicSchedulings.Any())
                return Result.Failure<List<SchedulingResponse>>(null);

            var list = clinicSchedulings.Select(clinicScheduling => new SchedulingResponse(clinicScheduling.Id, clinicScheduling.Date, clinicScheduling.PatientId, clinicScheduling.ProfessionalId, clinicScheduling.SchedulingStatusId)).ToList();

            return new List<SchedulingResponse>(list);
    }
}
