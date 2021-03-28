using System.Threading.Tasks;
using Votes.Core.DTO;
using Votes.DB;

namespace Votes.Core
{
    public interface IUserService
    {
        Task<AuthenticatedUser> SignUp(User user);
        Task<AuthenticatedUser> SignIn(User user);
    }
}
