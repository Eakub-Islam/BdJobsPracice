using FluentValidation;
using GymManagementSystem.AggregateRoots.Entities;
using GymManagementSystem.DTO;
using GymManagementSystem.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymManagementSystem.Handler
{
    public class MemberServiceHandler : IMemberServiceHandler
    {
        private readonly IRepository<Member> repository;
        private readonly IValidator<MemberDto> memberDtoValidator;

        public MemberServiceHandler(IRepository<Member> repository, IValidator<MemberDto> memberDtoValidator)
        {
            this.repository = repository;
            this.memberDtoValidator = memberDtoValidator;
        }

        // Get member details based on MemberDto input
        public async Task<MemberDto> GetByIdAsync(MemberDto memberDto)
        {
            var member = await repository.GetByIdAsync(memberDto.MemberId);
            return member?.MapToDto(new MemberDto());
        }

        // Get all members
        public async Task<IEnumerable<MemberDto>> GetAllAsync()
        {
            var members = await repository.GetAllAsync();
            return members.Select(member => member.MapToDto(new MemberDto())).ToList();
        }

       
        public async Task<int> AddAsync(MemberDto memberDto)
        {
            // Validation will throw if it fails
            await memberDtoValidator.ValidateAndThrowAsync(memberDto);

            var member = new Member().MapToEntity(memberDto);
            return await repository.AddAsync(member); 
        }

       
        public async Task<int> UpdateAsync(MemberDto memberDto)
        {
            // Validation will throw if it fails
            await memberDtoValidator.ValidateAndThrowAsync(memberDto);

            var member = await repository.GetByIdAsync(memberDto.MemberId);
            member?.MapToEntity(memberDto);

            return await repository.UpdateAsync(member); 
        }

       
        public async Task<int> DeleteAsync(MemberDto memberDto)
        {
            var member = await repository.GetByIdAsync(memberDto.MemberId);
            return await repository.DeleteAsync(member); // Return affected row count
        }

       
        public async Task<IEnumerable<MemberDto>> GetBySubscriptionTypeAsync(SubscriptionTypeDto type)
        {
            var subscriptionType = (SubscriptionType)type;
            var members = (await repository.GetAllAsync())
                .Where(m => m.SubscriptionType == subscriptionType);

            return members.Select(member => member.MapToDto(new MemberDto())).ToList();
        }
    }
}
