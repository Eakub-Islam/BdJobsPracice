using FluentValidation;
using GymManagementSystem.DTO;

public class MemberDtoValidator : AbstractValidator<MemberDto>
{
    public MemberDtoValidator()
    {
        // Validate MemberId only if it's for update or delete operations
        RuleFor(x => x.MemberId)
            .NotEmpty().WithMessage("Member ID is required.")
            .When(x => x.MemberId != Guid.Empty);  // Only validate if MemberId is set

        // Validate MemberName (cannot be empty, must have a reasonable length)
        RuleFor(x => x.MemberName)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

        // Validate MemberEmail (cannot be empty, must be a valid email address)
        RuleFor(x => x.MemberEmail)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        // Validate MemberPhoneNumber (cannot be empty, must follow a valid phone number pattern)
        RuleFor(x => x.MemberPhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format. Phone number should be between 10 and 15 digits.");

        // Validate MemberSubscriptionType (must be a valid enum value)
        RuleFor(x => x.MemberSubscriptionType)
            .IsInEnum().WithMessage("Invalid subscription type.");
    }
}
