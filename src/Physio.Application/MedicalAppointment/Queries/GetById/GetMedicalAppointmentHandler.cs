using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.MedicalAppointment.Queries.GetById;

internal sealed class GetMedicalAppointmentHandler : IRequestHandler<GetMedicalAppointmentQuery, Result<MedicalAppointmentResponse>>
{
    private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;

    public GetMedicalAppointmentHandler(IMedicalAppointmentRepository medicalAppointmentRepository)
    {
        _medicalAppointmentRepository = medicalAppointmentRepository;
    }

    public async Task<Result<MedicalAppointmentResponse>> Handle(GetMedicalAppointmentQuery request, CancellationToken cancellationToken)
    {
            var medicalAppointment = await _medicalAppointmentRepository.GetBySchedulingAsync(Guid.Parse(request.id), cancellationToken);

            if (medicalAppointment is null)
                return Result.Failure<MedicalAppointmentResponse>(DomainErrors.Generic.NotFound);

            return new MedicalAppointmentResponse(medicalAppointment.Id,
                medicalAppointment.BeatsPerMinute,
                medicalAppointment.BloodPressure,
                medicalAppointment.BloodOxygenation,
                medicalAppointment.Evolution,
                medicalAppointment.Notes,
                medicalAppointment.Weight,
                medicalAppointment.SchedulingId
            );
    }
}
