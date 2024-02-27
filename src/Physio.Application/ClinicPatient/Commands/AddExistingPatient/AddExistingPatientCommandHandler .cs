using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicPatient.Commands.AddExistingPatient;

internal sealed class AddExistingPatientCommandHandler : IRequestHandler<AddExistingPatientCommand, Result<ClinicPatientResponse>>
{
    private readonly IClinicPatientRepository _clinicPatientRepository;
    private readonly IClinicRepository _clinicRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddExistingPatientCommandHandler(IClinicPatientRepository clinicPatientRepository, IClinicRepository clinicRepository, IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _clinicPatientRepository = clinicPatientRepository;
        _patientRepository = patientRepository;
        _clinicRepository = clinicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ClinicPatientResponse>> Handle(AddExistingPatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetAsync(request.patient.patientId);

        if (patient is null)
            return Result.Failure<ClinicPatientResponse>(DomainErrors.ClinicPatient.PatientNotFound);

        var clinic = await _clinicRepository.GetUserIdAsync(request.userId.ToString());
        if (clinic is null)
            return Result.Failure<ClinicPatientResponse>(DomainErrors.Clinic.ClinicNotFound);


        var isRegistred = await _clinicPatientRepository.CheckAvailabilityAsync(patient.Id, clinic.Id);
        if (!isRegistred)
        {
            var clinicPatient = ClinicPatientEntity.Create(patient, clinic.Id, request.userId);

            if (clinicPatient.IsSuccess)
            {
                await _clinicPatientRepository.CreateAsync(clinicPatient.Value);
                await _unitOfWork.SaveChangesAsync();

                return new ClinicPatientResponse(
                    clinicPatient.Value.Id,
                    patient.Name,
                    patient.BirthDate,
                    patient.Contact,
                    clinicPatient.Value.Id
                );
            }
        }

        return Result.Failure<ClinicPatientResponse>(DomainErrors.ClinicPatient.PatientAlreadyRegistred);
    }
}
