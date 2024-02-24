using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Commands.Update;

internal sealed class UpdateProfessionalCommandHandler : IRequestHandler<UpdateProfessionalCommand, Result>
{
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProfessionalCommandHandler(IProfessionalRepository professionalRepository, IUnitOfWork unitOfWork)
    {
        _professionalRepository = professionalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateProfessionalCommand request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetAsync(request.professional.id);
        if (professional is not null)
        {
            professional.Update(
                request.professional.name, 
                request.professional.birthDate,
                request.professional.contact,
                request.professional.registerNumber,
                request.professional.appointmentValue,
                request.userId
            );

            _professionalRepository.Update(professional);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }

        return Result.Failure<ProfessionalResponse>(DomainErrors.Generic.UpdateError);

    }
}
