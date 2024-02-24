
namespace Physio.Shared.Communications.Requests;

public record MedicalAppointmentCreateRequest(string name, string beatsPerMinute, string bloodPressure, string bloodOxygenation, string evolution, string notes, decimal? weight, Guid schedulingId);

