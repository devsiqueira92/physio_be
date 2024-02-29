namespace Physio.Shared.Communications.Requests;

public record ProfessionalPatientCreateRequest(string name, DateOnly birthDate, string contact, string identificationNumber);
