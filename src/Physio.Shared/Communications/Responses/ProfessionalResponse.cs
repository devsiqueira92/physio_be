
namespace Physio.Shared.Communications.Responses;

public record ProfessionalResponse(Guid id, string name, DateOnly birthDate, string contact, string registerNumber, decimal appointmentValue);
