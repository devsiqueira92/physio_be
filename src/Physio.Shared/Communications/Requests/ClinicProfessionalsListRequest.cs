namespace Physio.Shared.Communications.Requests;

public record ClinicProfessionalsListRequest(Guid clinicId, int pageNumber = 1, int pageSize = 10);
