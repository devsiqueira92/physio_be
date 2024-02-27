
namespace Physio.Shared.Communications.Responses;

public record AddressResponse(Guid id, string street, string number, string city, string postalCode);
