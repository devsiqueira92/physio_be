
namespace Physio.Shared.Communications.Requests;

public record ProfessionalCreateRequest(string name, DateOnly birthDate, string contact, string registerNumber, decimal appointmentValue);

