using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Queries.GetByIdentificationNumber;

internal sealed class GetByIdentificationNumberHandler : IRequestHandler<GetByIdentificationNumberQuery, Result<PatientResponse>>
{
    private readonly IPatientRepository _patientRepository;

    public GetByIdentificationNumberHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<PatientResponse>> Handle(GetByIdentificationNumberQuery request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetByIdentificationNumberAsync(request.identificationNumber, cancellationToken);

        if (patient is null)
            return Result.Failure<PatientResponse>(DomainErrors.Generic.NotFound);

        return new PatientResponse(patient.Id, patient.Name, patient.Contact, patient.IdentificationNumber, patient.BirthDate);
    }
}
