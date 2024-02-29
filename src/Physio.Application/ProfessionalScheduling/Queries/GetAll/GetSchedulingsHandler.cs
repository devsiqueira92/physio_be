using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalScheduling.Queries.GetAll;

internal sealed class GetProfessionalSchedulingsHandler : IRequestHandler<GetProfessionalSchedulingsQuery, Result<List<SchedulingResponse>>>
{
    private readonly IProfessionalSchedulingRepository _professionalSchedulingRepository;

    public GetProfessionalSchedulingsHandler(IProfessionalSchedulingRepository professionalSchedulingRepository)
    {
        _professionalSchedulingRepository = professionalSchedulingRepository;
    }

    public async Task<Result<List<SchedulingResponse>>> Handle(GetProfessionalSchedulingsQuery request, CancellationToken cancellationToken)
    {
            var professionalSchedulings = await _professionalSchedulingRepository.GetAllAsync(request.page, request.pageSize, cancellationToken);

            if (!professionalSchedulings.Any())
                return Result.Failure<List<SchedulingResponse>>(null);

            var list = professionalSchedulings.Select(professionalScheduling => new SchedulingResponse(professionalScheduling.Id, professionalScheduling.Date, professionalScheduling.PatientId, professionalScheduling.ProfessionalId, professionalScheduling.SchedulingStatusId)).ToList();

            return new List<SchedulingResponse>(list);
    }
}
