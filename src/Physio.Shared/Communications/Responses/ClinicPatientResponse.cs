namespace Physio.Shared.Communications.Responses;

public record ClinicPatientResponse(Guid id, string name, DateOnly birthDate, string contact, Guid clinicId);

