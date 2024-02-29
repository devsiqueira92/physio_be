using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalPatient.Commands.AddExistingPatient;

internal sealed class AddExistingPatientCommandHandler : IRequestHandler<AddExistingPatientCommand, Result<ProfessionalPatientResponse>>
{
    private readonly IProfessionalPatientRepository _professionalPatientRepository;
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddExistingPatientCommandHandler(IProfessionalPatientRepository professionalPatientRepository, IProfessionalRepository professionalRepository, IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _professionalPatientRepository = professionalPatientRepository;
        _patientRepository = patientRepository;
        _professionalRepository = professionalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProfessionalPatientResponse>> Handle(AddExistingPatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetAsync(request.patient.patientId);

        if (patient is null)
            return Result.Failure<ProfessionalPatientResponse>(DomainErrors.ProfessionalPatient.PatientNotFound);

        var professional = await _professionalRepository.GetUserIdAsync(request.userId.ToString());
        if (professional is null)
            return Result.Failure<ProfessionalPatientResponse>(DomainErrors.Professional.ProfessionalNotFound);


        var isRegistred = await _professionalPatientRepository.CheckAvailabilityAsync(patient.Id, professional.Id);
        if (!isRegistred)
        {
            var professionalPatient = ProfessionalPatientEntity.Create(patient, professional.Id, request.userId);

            if (professionalPatient.IsSuccess)
            {
                await _professionalPatientRepository.CreateAsync(professionalPatient.Value);
                await _unitOfWork.SaveChangesAsync();

                return new ProfessionalPatientResponse(
                    professionalPatient.Value.Id,
                    patient.Name,
                    patient.BirthDate,
                    patient.Contact,
                    professionalPatient.Value.Id
                );
            }
        }

        return Result.Failure<ProfessionalPatientResponse>(DomainErrors.ProfessionalPatient.PatientAlreadyRegistred);
    }
}
