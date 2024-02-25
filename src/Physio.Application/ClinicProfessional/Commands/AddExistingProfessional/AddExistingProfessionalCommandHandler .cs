using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicProfessional.Commands.AddExistingProfessional;

internal sealed class AddExistingProfessionalCommandHandler : IRequestHandler<AddExistingProfessionalCommand, Result<ProfessionalClinicResponse>>
{
    private readonly IClinicProfessionalRepository _professionalClinicRepository;
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddExistingProfessionalCommandHandler(IClinicProfessionalRepository professionalClinicRepository, IProfessionalRepository professionalRepository, IUnitOfWork unitOfWork)
    {
        _professionalClinicRepository = professionalClinicRepository;
        _professionalRepository = professionalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProfessionalClinicResponse>> Handle(AddExistingProfessionalCommand request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetAsync(request.professional.professionalId);

        if (professional is null)
            return Result.Failure<ProfessionalClinicResponse>(DomainErrors.ProfessionalClinic.ProfessionalNotFound);

        var isRegistred = await _professionalClinicRepository.CheckAvailabilityAsync(professional.Id, request.professional.clinicId);
        if (!isRegistred)
        {
            var professionalClinic = ClinicProfessionalEntity.Create(professional, request.professional.professionalId, request.userId);

            if (professionalClinic.IsSuccess)
            {
                await _professionalClinicRepository.CreateAsync(professionalClinic.Value);
                await _unitOfWork.SaveChangesAsync();

                return new ProfessionalClinicResponse(
                    professionalClinic.Value.Id,
                    professional.Name,
                    professional.BirthDate,
                    professional.Contact,
                    professional.RegisterNumber,
                    professional.AppointmentValue,
                    professionalClinic.Value.Id
                );
            }
        }

        return Result.Failure<ProfessionalClinicResponse>(DomainErrors.ProfessionalClinic.ProfessionalAlreadyRegistred);
    }
}
