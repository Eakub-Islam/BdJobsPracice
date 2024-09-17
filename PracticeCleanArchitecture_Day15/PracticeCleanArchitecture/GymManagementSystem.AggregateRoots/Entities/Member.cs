using GymManagementSystem.DTO;
using System;

namespace GymManagementSystem.AggregateRoots.Entities
{
    public enum SubscriptionType
    {
        Basic,
        Premium,
        VIP
    }

    public class Member
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public SubscriptionType SubscriptionType { get; set; }

        
        public MemberDto MapToDto(MemberDto memberDto)
        {
            if (memberDto == null)
                throw new ArgumentNullException(nameof(memberDto), "MemberDto cannot be null.");

            memberDto.MemberId = Id;
            memberDto.MemberName = Name;
            memberDto.MemberEmail = Email;
            memberDto.MemberPhoneNumber = PhoneNumber;
            memberDto.MemberSubscriptionType = (SubscriptionTypeDto)SubscriptionType;

            return memberDto;
        }


        // Update this Member entity with values from MemberDto
        public Member MapToEntity(MemberDto memberDto)
        {
            if (memberDto == null)
                throw new ArgumentNullException(nameof(memberDto), "MemberDto cannot be null.");

            Id = memberDto.MemberId;
            Name = memberDto.MemberName;
            Email = memberDto.MemberEmail;
            PhoneNumber = memberDto.MemberPhoneNumber;
            SubscriptionType = (SubscriptionType)memberDto.MemberSubscriptionType;

            return this; 
        }
    }

}
 
