using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicPatient.Commands.AddPatient;

internal sealed class AddClinicPatientCommandHandler : IRequestHandler<AddClinicPatientCommand, Result<ClinicPatientResponse>>
{
    private readonly IClinicPatientRepository _clinicPatientRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddClinicPatientCommandHandler(IClinicPatientRepository clinicPatientRepository, IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _clinicPatientRepository = clinicPatientRepository;
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ClinicPatientResponse>> Handle(AddClinicPatientCommand request, CancellationToken cancellationToken)
    {
        var hasPatient = await _patientRepository.FindByDocumentNumberAsync(request.patient.contact);

        if (hasPatient)
            return Result.Failure<ClinicPatientResponse>(DomainErrors.ProfessionalClinic.ProfessionalAlreadyRegistred);

        var newPatient = PatientEntity.Create(request.patient.name,
                request.patient.birthDate,
                request.patient.contact,
                request.userId
            );

        if (newPatient.IsSuccess)
        {
            var clinicPatient = ClinicPatientEntity.Create(newPatient.Value, request.clinicId, request.userId);

            if (clinicPatient.IsSuccess)
            {
                await _clinicPatientRepository.CreateAsync(clinicPatient.Value);
                await _unitOfWork.SaveChangesAsync();

                return new ClinicPatientResponse(
                    clinicPatient.Value.Id,
                    newPatient.Value.Name,
                    newPatient.Value.BirthDate,
                    newPatient.Value.Contact,
                    clinicPatient.Value.ClinicId
                );
            }
        }

        return Result.Failure<ClinicPatientResponse>(DomainErrors.Generic.CreateError);
    }
}
