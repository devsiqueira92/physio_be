using MediatR;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicProfessional.Queries.GetClinicProfessionals;

internal sealed class GetClinicProfessionalsHandler : IRequestHandler<GetClinicProfessionalsQuery, Result<List<ProfessionalResponse>>>
{
    private readonly IClinicProfessionalRepository _professionalClinicRepository;

    public GetClinicProfessionalsHandler(IClinicProfessionalRepository professionalClinicRepository)
    {
        _professionalClinicRepository = professionalClinicRepository;
    }

    public async Task<Result<List<ProfessionalResponse>>> Handle(GetClinicProfessionalsQuery request, CancellationToken cancellationToken)
    {
        var professionalsOfClinic = await _professionalClinicRepository.GetAllAsync(request.request.pageNumber, request.request.pageSize, request.userId, cancellationToken);

        if (!professionalsOfClinic.Any())
            return Result.Failure<List<ProfessionalResponse>>(null);

        var list = professionalsOfClinic.Select(
                clinic => new ProfessionalResponse(
                    clinic.Id,
                    clinic.ProfessionalEntity.Name,
                    clinic.ProfessionalEntity.BirthDate,
                    clinic.ProfessionalEntity.Contact,
                    clinic.ProfessionalEntity.RegisterNumber,
                    clinic.ProfessionalEntity.AppointmentValue
                )
            ).ToList();

        return new List<ProfessionalResponse>(list);
    }

}
