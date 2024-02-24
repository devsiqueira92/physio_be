using FluentValidation;
using Physio.Shared.Communications.Requests;

namespace Physio.API.Validators.MedicalAppointment;

public class CreateMedicalAppointmentValidator : AbstractValidator<MedicalAppointmentCreateRequest>
{
    public CreateMedicalAppointmentValidator()
    {
        //RuleFor(x => x.schedulingId).NotEmpty().WithMessage("Name can't be null");
    }
}
