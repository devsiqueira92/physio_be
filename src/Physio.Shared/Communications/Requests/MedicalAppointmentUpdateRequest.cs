
namespace Physio.Shared.Communications.Requests;

public record MedicalAppointmentUpdateRequest(Guid id, string name, string beatsPerMinute, string bloodPressure, string bloodOxygenation, string evolution, string notes, decimal weight, Guid schedulingId);

