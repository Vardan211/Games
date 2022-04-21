using Games.DataAcess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Games.DataAcess
{
    public  class ApplicationDbContext:IdentityDbContext<UserEntity,IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
    }
}
