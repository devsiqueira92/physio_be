
namespace Physio.Shared.Communications.Requests;

public record PatientCreateRequest(string name, DateOnly birthDate, string contact);

