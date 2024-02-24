using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Patient.Commands.Delete;

internal sealed class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, Result>
{
    private readonly IPatientRepository _patientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePatientCommandHandler(IPatientRepository patientRepository, IUnitOfWork unitOfWork)
    {
        _patientRepository = patientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetAsync(Guid.Parse(request.patient));
        if (patient is not null)
        {
            patient.Delete(request.userId);

            _patientRepository.Update(patient);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<PatientResponse>(DomainErrors.Generic.UpdateError);

    }
}
