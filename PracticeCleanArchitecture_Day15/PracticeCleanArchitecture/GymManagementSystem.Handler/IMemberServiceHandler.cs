using GymManagementSystem.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymManagementSystem.Handler
{
    public interface IMemberServiceHandler
    {
        Task<MemberDto> GetByIdAsync(MemberDto memberDto);

        Task<IEnumerable<MemberDto>> GetAllAsync();

        Task<int> AddAsync(MemberDto memberDto);    
        Task<int> UpdateAsync(MemberDto memberDto); 

        Task<int> DeleteAsync(MemberDto memberDto); 

        Task<IEnumerable<MemberDto>> GetBySubscriptionTypeAsync(SubscriptionTypeDto type);
    }
}
