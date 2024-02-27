using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Commands.Create;

internal sealed class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, Result<PatientResponse>>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PatientResponse>> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
    {
        var newPatient = PatientEntity.Create(request.patient.name, request.patient.birthDate, request.patient.contact, request.patient.identificationNumber, request.userId);
        if (newPatient.IsSuccess)
        {
            await _patientRepository.CreateAsync(newPatient.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new PatientResponse(newPatient.Value.Id, newPatient.Value.Name, newPatient.Value.Contact, newPatient.Value.BirthDate);
        }

        return Result.Failure<PatientResponse>(newPatient.Error);
    }
}
