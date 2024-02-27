using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicPatient.Queries.GetClinicPatients;

internal sealed class GetClinicPatientsHandler : IRequestHandler<GetClinicPatientsQuery, Result<List<PatientResponse>>>
{
    private readonly IClinicPatientRepository _clinicPatientRepository;

    public GetClinicPatientsHandler(IClinicPatientRepository clinicPatientRepository)
    {
        _clinicPatientRepository = clinicPatientRepository;
    }

    public async Task<Result<List<PatientResponse>>> Handle(GetClinicPatientsQuery request, CancellationToken cancellationToken)
    {
        var patientsOfClinic = await _clinicPatientRepository.GetAllAsync(request.request.pageNumber, request.request.pageSize, request.userId, cancellationToken);

        if (!patientsOfClinic.Any())
            return Result.Failure<List<PatientResponse>>(null);

        var list = patientsOfClinic.Select(
                clinic => new PatientResponse(
                    clinic.PatientId,
                    clinic.PatientEntity.Name,
                    clinic.PatientEntity.Contact,
                    clinic.PatientEntity.BirthDate
                )
            ).ToList();

        return new List<PatientResponse>(list);
    }

}
