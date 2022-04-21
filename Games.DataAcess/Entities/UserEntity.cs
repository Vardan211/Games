using Microsoft.AspNetCore.Identity;

namespace Games.DataAcess.Entities
{
    public class UserEntity: IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
