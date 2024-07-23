using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Test.Quiz.Api.Data.Entities;

namespace Test.Quiz.Api.Data.EntityFrameworkCore.Seeders
{
    public static class DatabaseSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(RoleSeeder.Data());
            modelBuilder.Entity<User>().HasData(UserSeeder.Data());
            modelBuilder.Entity<UserRole>().HasData(UserRoleSeeder.Data());
            modelBuilder.Entity<ToeicScore>().HasData(ToeicScoreSeeder.Data());

        }
    }
}
