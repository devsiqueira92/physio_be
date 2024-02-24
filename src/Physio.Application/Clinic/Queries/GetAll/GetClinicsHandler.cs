using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Queries.GetAll;

internal sealed class GetClinicsHandler : IRequestHandler<GetClinicsQuery, Result<List<ClinicResponse>>>
{
    private readonly IClinicRepository _clinicRepository;

    public GetClinicsHandler(IClinicRepository clinicRepository)
    {
        _clinicRepository = clinicRepository;
    }

    public async Task<Result<List<ClinicResponse>>> Handle(GetClinicsQuery request, CancellationToken cancellationToken)
    {
            var clinics = await _clinicRepository.GetAllAsync(request.page, request.pageSize, cancellationToken);

            if (!clinics.Any())
                return Result.Failure<List<ClinicResponse>>(null);

            var list = clinics.Select(
                    clinic => new ClinicResponse(
                        clinic.Id,
                        clinic.Name
                        //clinic.BirthDate, 
                        //clinic.Contact,
                        //clinic.RegisterNumber, 
                        //clinic.AppointmentValue
                    )
                ).ToList();

            return new List<ClinicResponse>(list);
    }
}
