using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Queries.GetById;

internal sealed class GetClinicHandler : IRequestHandler<GetClinicQuery, Result<ClinicResponse>>
{
    private readonly IClinicRepository _clinicRepository;

    public GetClinicHandler(IClinicRepository clinicRepository)
    {
        _clinicRepository = clinicRepository;
    }

    public async Task<Result<ClinicResponse>> Handle(GetClinicQuery request, CancellationToken cancellationToken)
    {
            var clinic = await _clinicRepository.GetAsync(Guid.Parse(request.id), cancellationToken);

            if (clinic is null)
                return Result.Failure<ClinicResponse>(DomainErrors.Generic.NotFound);

            return new ClinicResponse(
                    clinic.Id,
                    clinic.Name
                );
    }
}
