
namespace Physio.Shared.Communications.Responses;

public record MedicalAppointmentResponse(Guid id, 
    string beatsPerMinute, 
    string bloodPressure, 
    string bloodOxygenation, 
    string evolution, 
    string notes, 
    decimal? weight, 
    //Guid schedulingId, 
    string patientName = null, 
    string professionalName = null, 
    DateTime? date = null
);
