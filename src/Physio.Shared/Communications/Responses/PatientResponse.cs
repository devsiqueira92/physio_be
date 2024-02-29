
namespace Physio.Shared.Communications.Responses;

public record PatientResponse(Guid id, string name, string contact, string identificationNumber, DateOnly birthDate );
