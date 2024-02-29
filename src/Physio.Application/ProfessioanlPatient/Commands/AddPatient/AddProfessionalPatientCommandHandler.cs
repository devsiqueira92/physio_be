using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ProfessionalPatient.Commands.AddPatient;

internal sealed class AddProfessionalPatientCommandHandler : IRequestHandler<AddProfessionalPatientCommand, Result<ProfessionalPatientResponse>>
{
    private readonly IProfessionalPatientRepository _professionalPatientRepository;
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddProfessionalPatientCommandHandler(IProfessionalPatientRepository professionalPatientRepository, IProfessionalRepository professionalRepository, IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _professionalPatientRepository = professionalPatientRepository;
        _patientRepository = patientRepository;
        _professionalRepository = professionalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProfessionalPatientResponse>> Handle(AddProfessionalPatientCommand request, CancellationToken cancellationToken)
    {
        var hasPatient = await _patientRepository.FindByDocumentNumberAsync(request.patient.contact);
        if (hasPatient)
            return Result.Failure<ProfessionalPatientResponse>(DomainErrors.ProfessionalClinic.ProfessionalAlreadyRegistred);

        var professional = await _professionalRepository.GetUserIdAsync(request.userId.ToString());
        if (professional is null)
            return Result.Failure<ProfessionalPatientResponse>(DomainErrors.Professional.ProfessionalNotFound);

        var newPatient = PatientEntity.Create(request.patient.name,
                request.patient.birthDate,
                request.patient.contact,
                request.patient.identificationNumber,
                request.userId
            );

        if (newPatient.IsSuccess)
        {
            var professionalPatient = ProfessionalPatientEntity.Create(newPatient.Value, professional.Id, request.userId);

            if (professionalPatient.IsSuccess)
            {
                await _professionalPatientRepository.CreateAsync(professionalPatient.Value);
                await _unitOfWork.SaveChangesAsync();

                return new ProfessionalPatientResponse(
                    professionalPatient.Value.Id,
                    newPatient.Value.Name,
                    newPatient.Value.BirthDate,
                    newPatient.Value.Contact,
                    professionalPatient.Value.ProfessionalId
                );
            }
        }

        return Result.Failure<ProfessionalPatientResponse>(DomainErrors.Generic.CreateError);
    }
}
