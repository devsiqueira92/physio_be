

namespace Physio.Shared.Communications.Responses;

public record SchedulingDetailsResponse(Guid id, string patientName, string professionalName, string schedulingStatus);
