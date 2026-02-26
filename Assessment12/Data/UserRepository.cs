using Assessment12.Models;

namespace Assessment12.Data
{
    public static class UserRepository
    {
        public static List<AppUser> Users = new List<AppUser>
        {
            new AppUser
            {
                Email = "admin@test.com",
                Password = "1234",
                Role = "Admin"
            },
            new AppUser
            {
                Email = "user@test.com",
                Password = "1234",
                Role = "User"
            }
        };
    }
}