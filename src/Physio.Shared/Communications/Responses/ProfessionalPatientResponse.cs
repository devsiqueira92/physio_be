namespace Physio.Shared.Communications.Responses;

public record ProfessionalPatientResponse(Guid id, string name, DateOnly birthDate, string contact, Guid clinicId);