
namespace Physio.Shared.Communications.Requests;

public record SchedulingUpdateRequest(Guid id, DateTime date, Guid patientId, Guid professionalId, Guid schedulingStatusId, Guid schedulingType, Guid clinicId);

