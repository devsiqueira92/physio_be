
namespace Physio.Shared.Communications.Requests;

public record ClinicUpdateRequest(Guid id, string name, string address, string contact, string identificationNumber);

