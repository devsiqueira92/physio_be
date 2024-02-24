using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Commands.Update;

internal sealed class UpdatePatientCommandHandler : IRequestHandler<UpdatePatientCommand, Result>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetAsync(request.patient.id);
        if (patient is not null)
        {
            patient.Update(request.patient.name, request.patient.birthDate, request.patient.contact, request.userId);

            _patientRepository.Update(patient);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<PatientResponse>(DomainErrors.Generic.UpdateError);

    }
}
