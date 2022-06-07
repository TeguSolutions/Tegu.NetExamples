using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Entities;
using Tegu.Net.Shared.Definitions;

// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart

namespace Tegu.Net.Backend.Data.SQL.Context;

public partial class TeguSqlContext : DbContext
{
    public TeguSqlContext()
    {
    }

    public TeguSqlContext(DbContextOptions<TeguSqlContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<TeguType> TeguTypes { get; set; }

    public DbSet<OwnedTegu> OwnedTegus { get; set; }

    // Many To Many Relations
    public DbSet<UserRole> UserRoles { get; set; }



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        foreach (var relationship in builder.Model.GetEntityTypes().Where(e => !e.IsOwned())
                     .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }

        // MtM relations
        builder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        // Data seed
        foreach (var role in RoleDefinitions.Collection)
        {
            builder.Entity<Role>().HasData(new Role { Id = role.Id, Name = role.Name });
        }

        foreach (var teguType in TeguTypeDefinitions.Collection)
        {
            builder.Entity<TeguType>().HasData(new TeguType
            {
                Id = teguType.Id, FullName = teguType.FullName, Name = teguType.Name, LatinName = teguType.LatinName,
                Color = teguType.Color
            });
        }


        //builder.Entity<User>().HasData(new User()
        //{
        //    Id = Guid.NewGuid(),
        //    Email = "thetegu@tegu.net",
        //    FirstName = "",
        //    LastName = "",
        //    PasswordHash = BCrypt.Net.BCrypt.HashPassword("")
        //});


        OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}