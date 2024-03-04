using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.MedicalAppointment.Commands.Delete;

internal sealed class DeleteMedicalAppointmentCommandHandler : IRequestHandler<DeleteMedicalAppointmentCommand, Result>
{
    private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMedicalAppointmentCommandHandler(IMedicalAppointmentRepository medicalAppointmentRepository, IUnitOfWork unitOfWork)
    {
        _medicalAppointmentRepository = medicalAppointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteMedicalAppointmentCommand request, CancellationToken cancellationToken)
    {
        var medicalAppointment = await _medicalAppointmentRepository.GetAsync(Guid.Parse(request.medicalAppointment));
        if (medicalAppointment is not null)
        {
            medicalAppointment.Delete(request.userId);

            _medicalAppointmentRepository.Update(medicalAppointment);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<MedicalAppointmentResponse>(DomainErrors.Generic.UpdateError);

    }
}
