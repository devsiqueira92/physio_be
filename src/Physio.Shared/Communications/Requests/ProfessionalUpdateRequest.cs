
namespace Physio.Shared.Communications.Requests;

public record ProfessionalUpdateRequest(Guid id, string name, DateOnly birthDate, string contact, string registerNumber, decimal appointmentValue);

