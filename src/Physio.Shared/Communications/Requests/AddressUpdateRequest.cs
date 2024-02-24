
namespace Physio.Shared.Communications.Requests;

public record AddressUpdateRequest(Guid id, string street, string number, string city, string postalCode);

