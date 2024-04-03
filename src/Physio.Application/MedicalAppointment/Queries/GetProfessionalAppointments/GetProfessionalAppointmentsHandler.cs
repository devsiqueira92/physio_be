using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.GetProfessionalAppointments.Queries.GetAll;

internal sealed class GetProfessionalAppointmentsHandler : IRequestHandler<GetProfessionalAppointmentsQuery, Result<List<MedicalAppointmentResponse>>>
{
    private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
    private readonly IProfessionalRepository _professionalRepository;

    public GetProfessionalAppointmentsHandler(IMedicalAppointmentRepository medicalAppointmentRepository, IProfessionalRepository professionalRepository)
    {
        _professionalRepository = professionalRepository;
        _medicalAppointmentRepository = medicalAppointmentRepository;
    }

    public async Task<Result<List<MedicalAppointmentResponse>>> Handle(GetProfessionalAppointmentsQuery request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetUserIdAsync(request.userId);
            
        var medicalAppointments = await _medicalAppointmentRepository.GetProfessionalAppointmentsAsync(professional.Id, request.page, request.pageSize, cancellationToken);

        var list = medicalAppointments.Select(medicalAppointment => new MedicalAppointmentResponse(
                medicalAppointment.Id,
                medicalAppointment.BeatsPerMinute,
                medicalAppointment.BloodPressure,
                medicalAppointment.BloodOxygenation,
                medicalAppointment.Evolution,
                medicalAppointment.Notes,
                medicalAppointment.Weight
            )
        ).ToList();

        return new List<MedicalAppointmentResponse>(list);
    }
}
