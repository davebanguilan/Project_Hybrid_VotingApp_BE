

namespace Votes.Core.DTO
{
    public class AuthenticatedUser
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

    }
}
