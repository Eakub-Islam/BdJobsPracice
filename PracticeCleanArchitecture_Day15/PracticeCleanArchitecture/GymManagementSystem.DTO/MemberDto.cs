
using System;
using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.DTO
{
    public class MemberDto
    {
        public Guid MemberId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string MemberName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string MemberEmail { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string MemberPhoneNumber { get; set; }

        [Required(ErrorMessage = "Subscription type is required.")]
        public SubscriptionTypeDto MemberSubscriptionType { get; set; }
    }

    public enum SubscriptionTypeDto
    {
        Basic,
        Premium,
        VIP
    }
}


