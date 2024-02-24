using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Commands.Update;

internal sealed class UpdateClinicCommandHandler : IRequestHandler<UpdateClinicCommand, Result>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClinicCommandHandler(IClinicRepository clinicRepository, IUnitOfWork unitOfWork)
    {
        _clinicRepository = clinicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateClinicCommand request, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetAsync(request.clinic.id);
        if (clinic is not null)
        {
            clinic.Update(
                request.clinic.name,
                request.clinic.address,
                request.clinic.contact,
                request.clinic.identificationNumber,
                request.userId
            );

            _clinicRepository.Update(clinic);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<ClinicResponse>(DomainErrors.Generic.UpdateError);

    }
}
