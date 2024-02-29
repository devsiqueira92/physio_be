
namespace Physio.Shared.Communications.Requests;

public record SchedulingCreateRequest(DateTime date, Guid patientId, Guid professionalId, string schedulingType, Guid? clinicId);

