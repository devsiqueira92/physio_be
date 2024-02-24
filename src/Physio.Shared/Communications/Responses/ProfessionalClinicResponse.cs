namespace Physio.Shared.Communications.Responses;

public record ProfessionalClinicResponse(Guid id, string name, DateOnly birthDate, string contact, string registerNumber, decimal appointmentValue, Guid clinicId);

