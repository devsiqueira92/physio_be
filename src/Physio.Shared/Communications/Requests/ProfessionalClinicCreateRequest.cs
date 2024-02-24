namespace Physio.Shared.Communications.Requests;

public record ProfessionalClinicCreateRequest(string name, DateOnly birthDate, string contact, string registerNumber, decimal appointmentValue, Guid clinicId);
