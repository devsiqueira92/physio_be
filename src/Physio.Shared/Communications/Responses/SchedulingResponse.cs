
namespace Physio.Shared.Communications.Responses;

public record SchedulingResponse(Guid id, 
        DateTime date, 
        Guid patientId, 
        Guid professionalId, 
        string patientName = null, 
        string patientContact = null, 
        DateOnly? patientBirthDate = null, 
        string schedulingType = null, 
        string professionalName = null, 
        string schedulingStatus = null,
        Guid? schedulingStatusId = null,
        Guid? schedulingTypeId = null
);
