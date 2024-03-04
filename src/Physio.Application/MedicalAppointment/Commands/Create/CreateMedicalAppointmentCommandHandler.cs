using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.MedicalAppointment.Commands.Create;

internal sealed class CreateMedicalAppointmentCommandHandler : IRequestHandler<CreateMedicalAppointmentCommand, Result<MedicalAppointmentResponse>>
{
    private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMedicalAppointmentCommandHandler(IMedicalAppointmentRepository medicalAppointmentRepository, IUnitOfWork unitOfWork)
    {
        _medicalAppointmentRepository = medicalAppointmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MedicalAppointmentResponse>> Handle(CreateMedicalAppointmentCommand request, CancellationToken cancellationToken)
    {
        var newMedicalAppointment = MedicalAppointmentEntity.Create(
            request.medicalAppointment.beatsPerMinute,
            request.medicalAppointment.bloodPressure, 
            request.medicalAppointment.bloodOxygenation, 
            request.medicalAppointment.evolution, 
            request.medicalAppointment.notes, 
            request.medicalAppointment.weight, 
            request.medicalAppointment.schedulingId,
            request.userId
        );

        if (newMedicalAppointment.IsSuccess)
        {
            await _medicalAppointmentRepository.CreateAsync(newMedicalAppointment.Value, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new MedicalAppointmentResponse(
                newMedicalAppointment.Value.Id, 
                newMedicalAppointment.Value.BeatsPerMinute, 
                newMedicalAppointment.Value.BloodPressure, 
                newMedicalAppointment.Value.BloodOxygenation, 
                newMedicalAppointment.Value.Evolution, 
                newMedicalAppointment.Value.Notes, 
                newMedicalAppointment.Value.Weight
                //newMedicalAppointment.Value.SchedulingId
            );
        }

        return Result.Failure<MedicalAppointmentResponse>(newMedicalAppointment.Error);

    }
}
