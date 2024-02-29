using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalPatient.Queries.GetProfessionalPatients;

internal sealed class GetProfessionalPatientsHandler : IRequestHandler<GetProfessionalPatientsQuery, Result<List<PatientResponse>>>
{
    private readonly IProfessionalPatientRepository _professionalPatientRepository;

    public GetProfessionalPatientsHandler(IProfessionalPatientRepository professionalPatientRepository)
    {
        _professionalPatientRepository = professionalPatientRepository;
    }

    public async Task<Result<List<PatientResponse>>> Handle(GetProfessionalPatientsQuery request, CancellationToken cancellationToken)
    {
        var patientsOfProfessional = await _professionalPatientRepository.GetAllAsync(request.request.pageNumber, request.request.pageSize, request.userId, cancellationToken);

        if (!patientsOfProfessional.Any())
            return Result.Failure<List<PatientResponse>>(null);

        var list = patientsOfProfessional.Select(
                professional => new PatientResponse(
                    professional.PatientId,
                    professional.PatientEntity.Name,
                    professional.PatientEntity.Contact,
                    professional.PatientEntity.IdentificationNumber,
                    professional.PatientEntity.BirthDate
                )
            ).ToList();

        return new List<PatientResponse>(list);
    }

}
