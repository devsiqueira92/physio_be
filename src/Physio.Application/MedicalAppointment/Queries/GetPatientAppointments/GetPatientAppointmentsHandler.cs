using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.GetPatientAppointments.Queries.GetAll;

internal sealed class GetPatientAppointmentsHandler : IRequestHandler<GetPatientAppointmentsQuery, Result<List<MedicalAppointmentResponse>>>
{
    private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;

    public GetPatientAppointmentsHandler(IMedicalAppointmentRepository medicalAppointmentRepository)
    {
        _medicalAppointmentRepository = medicalAppointmentRepository;
    }

    public async Task<Result<List<MedicalAppointmentResponse>>> Handle(GetPatientAppointmentsQuery request, CancellationToken cancellationToken)
    {
        List<MedicalAppointmentEntity> medicalAppointments = await _medicalAppointmentRepository.GetPatientAppointmentsAsync(Guid.Parse(request.userId), request.pageSize, request.page, cancellationToken);

        List<MedicalAppointmentResponse> list = medicalAppointments.Select(medicalAppointment => new MedicalAppointmentResponse(
                medicalAppointment.Id,
                medicalAppointment.BeatsPerMinute,
                medicalAppointment.BloodPressure,
                medicalAppointment.BloodOxygenation,
                medicalAppointment.Evolution,
                medicalAppointment.Notes,
                medicalAppointment.Weight,
                medicalAppointment.SchedulingId,
                professionalName: medicalAppointment.SchedulingEntity.ProfessionalEntity.Name,
                patientName: medicalAppointment.SchedulingEntity.PatientEntity.Name,
                date: medicalAppointment.SchedulingEntity.Date
            )
        ).ToList();

        return new List<MedicalAppointmentResponse>(list);
    }
}
