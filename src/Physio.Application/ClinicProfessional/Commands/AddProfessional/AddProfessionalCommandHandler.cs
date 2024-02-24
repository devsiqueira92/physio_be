﻿using MediatR;
using Physio.Domain.Entities;
using Physio.Domain.Errors;
using Physio.Domain.RepositoryInterfaces;
using Physio.Domain.Shared;
using Physio.Shared.Communications.Responses;

namespace Physio.Application.ClinicProfessional.Commands.AddProfessional;

internal sealed class AddProfessionalCommandHandler : IRequestHandler<AddProfessionalCommand, Result<ProfessionalClinicResponse>>
{
    private readonly IProfessionalClinicRepository _professionalClinicRepository;
    private readonly IProfessionalRepository _professionalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddProfessionalCommandHandler(IProfessionalClinicRepository professionalClinicRepository, IProfessionalRepository professionalRepository, IUnitOfWork unitOfWork)
    {
        _professionalClinicRepository = professionalClinicRepository;
        _professionalRepository = professionalRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ProfessionalClinicResponse>> Handle(AddProfessionalCommand request, CancellationToken cancellationToken)
    {
        var hasProfessional = await _professionalRepository.FindByRegisterNumberAsync(request.professional.registerNumber);

        if (hasProfessional is not null)
            return Result.Failure<ProfessionalClinicResponse>(DomainErrors.ProfessionalClinic.ProfessionalAlreadyRegistred);

        var newProfessional = ProfessionalEntity.CreateAsProfessionalClinic(request.professional.name,
                request.professional.birthDate,
                request.professional.contact,
                request.professional.registerNumber,
                request.professional.appointmentValue,
                request.userId
            );

        if (newProfessional.IsSuccess)
        {
            var professionalClinic = ProfessionalClinicEntity.Create(newProfessional.Value, request.professional.clinicId, request.userId);

            if (newProfessional.IsSuccess)
            {
                await _professionalClinicRepository.CreateAsync(professionalClinic.Value);
                await _unitOfWork.SaveChangesAsync();

                return new ProfessionalClinicResponse(
                    professionalClinic.Value.Id,
                    newProfessional.Value.Name,
                    newProfessional.Value.BirthDate,
                    newProfessional.Value.Contact,
                    newProfessional.Value.RegisterNumber,
                    newProfessional.Value.AppointmentValue,
                    professionalClinic.Value.Id
                );
            }
        }

        return Result.Failure<ProfessionalClinicResponse>(DomainErrors.Generic.CreateError);
    }
}
