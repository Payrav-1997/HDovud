using System;
using System.Collections.Generic;
using HDovud.Entities.Enum;
using HDovud.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HDovud.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).IsRequired();
            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.RoleId).IsRequired();
            var users = new List<User>
            {
                new ()
                {
                    Id = 1,
                    Name = "User",
                    Email = "User@gmail.com",
                    RoleId = Roles.User,
                    Password = BCrypt.Net.BCrypt.HashPassword("user")
                },
                new ()
                {
                    Id = 2,
                    Name = "Admin",
                    Email = "Admin@gmail.com",
                    RoleId = Roles.Admin,
                    Password = BCrypt.Net.BCrypt.HashPassword("admin")
                }
               
            };
            builder.HasData(users);
        }
    }
}