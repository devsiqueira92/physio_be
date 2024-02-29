using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.MedicalAppointment.Queries.GetAll;

internal sealed class GetMedicalAppointmentsHandler : IRequestHandler<GetMedicalAppointmentsQuery, Result<List<MedicalAppointmentResponse>>>
{
    private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;

    public GetMedicalAppointmentsHandler(IMedicalAppointmentRepository medicalAppointmentRepository)
    {
        _medicalAppointmentRepository = medicalAppointmentRepository;
    }

    public async Task<Result<List<MedicalAppointmentResponse>>> Handle(GetMedicalAppointmentsQuery request, CancellationToken cancellationToken)
    {
            var medicalAppointments = await _medicalAppointmentRepository.GetAllAsync(request.page, request.pageSize, request.userId, cancellationToken);

            if (!medicalAppointments.Any())
                return Result.Failure<List<MedicalAppointmentResponse>>(null);

            var list = medicalAppointments.Select(medicalAppointment => 
                new MedicalAppointmentResponse(
                    medicalAppointment.Id, 
                    medicalAppointment.BeatsPerMinute, 
                    medicalAppointment.BloodPressure, 
                    medicalAppointment.BloodOxygenation,
                    medicalAppointment.Evolution,
                    medicalAppointment.Notes,
                    medicalAppointment.Weight,
                    medicalAppointment.SchedulingId,
                    
                    medicalAppointment.SchedulingEntity.PatientEntity.Name, 
                    medicalAppointment.SchedulingEntity.ProfessionalEntity.Name, 
                    medicalAppointment.SchedulingEntity.Date
                )).ToList();

            return new List<MedicalAppointmentResponse>(list);
    }
}
