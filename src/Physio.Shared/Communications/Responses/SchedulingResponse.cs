
namespace Physio.Shared.Communications.Responses;

public record SchedulingResponse(Guid id, 
        DateTime date, 
        Guid patientId, 
        Guid professionalId, 
        Guid schedulingId, 
        string patientName = null, 
        string patientContact = null, 
        DateOnly? patientBirthDate = null, 
        string schedulingType = null, 
        string professionalName = null, 
        string schedulingStatus = null
);
