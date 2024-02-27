
namespace Physio.Shared.Communications.Responses;

public record PatientResponse(Guid? id = null, string? name = null, string? contact = null, DateOnly? birthDate = null);
