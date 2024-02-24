using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.MedicalAppointment.Commands.Update;

internal sealed class UpdateMedicalAppointmentCommandHandler : IRequestHandler<UpdateMedicalAppointmentCommand, Result>
{
    private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMedicalAppointmentCommandHandler(IMedicalAppointmentRepository medicalAppointmentRepository, IUnitOfWork unitOfWork)
    {
        _medicalAppointmentRepository = medicalAppointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateMedicalAppointmentCommand request, CancellationToken cancellationToken)
    {
        var medicalAppointment = await _medicalAppointmentRepository.GetAsync(request.medicalAppointment.id);
        if (medicalAppointment is not null)
        {
            var result = medicalAppointment.Update(
                request.medicalAppointment.beatsPerMinute, 
                request.medicalAppointment.bloodPressure, 
                request.medicalAppointment.bloodOxygenation,
                request.medicalAppointment.evolution,
                request.medicalAppointment.notes,
                request.medicalAppointment.weight,
                request.medicalAppointment.schedulingId,
                request.userId);

            if (result.IsSuccess)
            {
                _medicalAppointmentRepository.Update(medicalAppointment);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            return Result.Failure<MedicalAppointmentResponse>(result.Error);
        }
        return Result.Failure<MedicalAppointmentResponse>(DomainErrors.Generic.UpdateError);
    }
}
