using FamilyStoryApi.Model;
using Microsoft.EntityFrameworkCore;

namespace FamilyStoryApi.Data
{
    public class FamilyStoryContext(DbContextOptions<FamilyStoryContext> options) : DbContext(options)
    {
        public DbSet<UserInfo> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<UserGroupPermission> UserGroupPermissions { get; set; }

        public DbSet<Relatives> Relatives { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<LevelParentage> LevelParentages { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Family_Story;User id=sa;Password=1q2w3e4r@#$");*/

    }
}
