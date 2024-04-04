
namespace Physio.Shared.Communications.Requests;

public record ProfessionalCreateRequest(string name, DateTime birthDate, string contact, string registerNumber, decimal appointmentValue);

