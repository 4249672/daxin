using System.Threading.Tasks;
using Abp.Application.Services;
using DX.Loan.Friendships.Dto;

namespace DX.Loan.Friendships
{
    public interface IFriendshipAppService : IApplicationService
    {
        Task<FriendDto> CreateFriendshipRequest(CreateFriendshipRequestInput input);

        Task<FriendDto> CreateFriendshipRequestByUserName(CreateFriendshipRequestByUserNameInput input);

        void BlockUser(BlockUserInput input);

        void UnblockUser(UnblockUserInput input);

        void AcceptFriendshipRequest(AcceptFriendshipRequestInput input);
    }
}
