using EduTrack.Api.Models.DTOs.User;
using FluentValidation;

namespace EduTrack.Api.Validators.User;

public class UpdateUserRoleValidator : AbstractValidator<UpdateUserRoleDto>
{
    public UpdateUserRoleValidator()
    {
        RuleFor(x => x.Role)
            .NotEmpty();
    }
}