using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Queries.GetAll;

internal sealed class GetProfessionalsHandler : IRequestHandler<GetProfessionalsQuery, Result<List<ProfessionalResponse>>>
{
    private readonly IProfessionalRepository _professionalRepository;

    public GetProfessionalsHandler(IProfessionalRepository professionalRepository)
    {
        _professionalRepository = professionalRepository;
    }

    public async Task<Result<List<ProfessionalResponse>>> Handle(GetProfessionalsQuery request, CancellationToken cancellationToken)
    {
            var professionals = await _professionalRepository.GetAllAsync(request.page, request.pageSize, cancellationToken);

            if (!professionals.Any())
                return Result.Failure<List<ProfessionalResponse>>(null);

            var list = professionals.Select(
                    professional => new ProfessionalResponse(
                        professional.Id, 
                        professional.Name, 
                        professional.BirthDate, 
                        professional.Contact,
                        professional.RegisterNumber, 
                        professional.AppointmentValue
                    )
                ).ToList();

            return new List<ProfessionalResponse>(list);
    }
}
