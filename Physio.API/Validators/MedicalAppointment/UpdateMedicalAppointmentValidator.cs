using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.MedicalAppointment;

public class UpdateMedicalAppointmentValidator : AbstractValidator<MedicalAppointmentCreateRequest>
{
    public UpdateMedicalAppointmentValidator()
    {
        RuleFor(x => x.schedulingId).NotEmpty().WithMessage("Name can't be null");
    }
}
