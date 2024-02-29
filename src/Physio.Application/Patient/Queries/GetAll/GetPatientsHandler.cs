using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Queries.GetAll;

internal sealed class GetPatientsHandler : IRequestHandler<GetPatientsQuery, Result<List<PatientResponse>>>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientsHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<List<PatientResponse>>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
            var patients = await _patientRepository.GetPatientsByUserIdAsync(request.userId);

            if (!patients.Any())
                return Result.Failure<List<PatientResponse>>(null);

            var list = patients.Select(patient => new PatientResponse(patient.Id, patient.Name, patient.Contact, patient.IdentificationNumber, patient.BirthDate)).ToList();

            return new List<PatientResponse>(list);
    }
}
