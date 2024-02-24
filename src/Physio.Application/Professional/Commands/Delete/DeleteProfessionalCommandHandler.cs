using MediatR;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.Professional.Commands.Delete;

internal sealed class DeleteProfessionalCommandHandler : IRequestHandler<DeleteProfessionalCommand, Result>
{
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProfessionalCommandHandler(IProfessionalRepository professionalRepository, IUnitOfWork unitOfWork)
    {
        _professionalRepository = professionalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteProfessionalCommand request, CancellationToken cancellationToken)
    {
        var professional = await _professionalRepository.GetAsync(Guid.Parse(request.professional));
        if (professional is not null)
        {
            professional.Delete(request.userId);

            _professionalRepository.Update(professional);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        return Result.Failure<ProfessionalResponse>(DomainErrors.Generic.UpdateError);

    }
}
