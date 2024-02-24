namespace Physio.Shared.Communications.Requests;

public record PaginatedRequest(int pageNumber = 1, int pageSize = 10);