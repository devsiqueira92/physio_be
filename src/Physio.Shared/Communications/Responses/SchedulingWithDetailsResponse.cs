

namespace Physio.Shared.Communications.Responses;

public record SchedulingWithDetailListResponse(DateTime date, List<SchedulingDetailsResponse> schedulings);
