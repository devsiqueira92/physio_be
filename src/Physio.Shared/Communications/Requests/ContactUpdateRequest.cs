
namespace Physio.Shared.Communications.Requests;

public record ContactUpdateRequest(Guid id, string contact, string type);

