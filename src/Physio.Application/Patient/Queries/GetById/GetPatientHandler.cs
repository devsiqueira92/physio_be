using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Queries.GetById;

internal sealed class GetPatientHandler : IRequestHandler<GetPatientQuery, Result<PatientResponse>>
{
    private readonly IPatientRepository _patientRepository;

    public GetPatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Result<PatientResponse>> Handle(GetPatientQuery request, CancellationToken cancellationToken)
    {
            var patient = await _patientRepository.GetAsync(Guid.Parse(request.id), cancellationToken);

            if (patient is null)
                return Result.Failure<PatientResponse>(DomainErrors.Generic.NotFound);

            return new PatientResponse(patient.Id, patient.Name, patient.Contact, patient.IdentificationNumber, patient.BirthDate);
    }
}
