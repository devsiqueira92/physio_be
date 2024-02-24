using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Clinic.Commands.Delete;

internal sealed class DeleteClinicCommandHandler : IRequestHandler<DeleteClinicCommand, Result>
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClinicCommandHandler(IClinicRepository clinicRepository, IUnitOfWork unitOfWork)
    {
        _clinicRepository = clinicRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteClinicCommand request, CancellationToken cancellationToken)
    {
        var clinic = await _clinicRepository.GetAsync(Guid.Parse(request.clinic));
        if (clinic is not null)
        {
            clinic.Delete(request.userId);

            _clinicRepository.Update(clinic);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<ClinicResponse>(DomainErrors.Generic.UpdateError);

    }
}
