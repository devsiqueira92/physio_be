namespace Physio.Shared.Communications.Requests;

public record ClinicPatientCreateRequest(string name, DateOnly birthDate, string contact, Guid clinicId);
