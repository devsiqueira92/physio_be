
namespace Physio.Shared.Communications.Requests;

public record PatientUpdateRequest(Guid id, string name, DateOnly birthDate, string contact, string identificationNumber);

