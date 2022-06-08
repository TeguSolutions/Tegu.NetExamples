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

        #region Users

        var admintegu = new User
        {
            Id = Guid.Parse("b1ad8f85-f34a-4b0f-bf63-bfeb5f6173f4"),
            Email = "admintegu@tegu.net",
            FirstName = "Admin",
            LastName = "Tegu",
            PasswordHash = "$2a$11$E67YeDjnVXx47x7aPanznu2BT6Yql.0i1EvuY3MQhM4KcxbN9ljbu"
            //PasswordHash = BCrypt.Net.BCrypt.HashPassword("admintegu@tegu.net")
        };

        var bwtegu = new User
        {
            Id = Guid.Parse("079f5040-3662-4897-b827-d3505ea2438a"),
            Email = "bwtegu@tegu.net",
            FirstName = "B&W",
            LastName = "Tegu",
            PasswordHash = "$2a$11$z9bxZR2dYitdeBHvV1dVDOvERirnnEDkEwAH0tBxwunzFU0Z7omRG"
            //PasswordHash = BCrypt.Net.BCrypt.HashPassword("bwtegu@tegu.net")
        };

        var mixedtegu = new User
        {
            Id = Guid.Parse("6c266242-a52a-46d1-9083-dcf0f3745957"),
            Email = "mixedtegu@tegu.net",
            FirstName = "Mixed",
            LastName = "Tegu",
            PasswordHash = "$2a$11$cMGAh5FAcAnSd53qRDwq8OaEZlnqVE39l5cZ7mTE3KZmHli55wsnG"
            //PasswordHash = BCrypt.Net.BCrypt.HashPassword("mixedtegu@tegu.net")
        };

        var notegu = new User
        {
            Id = Guid.Parse("28218d70-5b0d-4d19-8171-1cae6ae75d30"),
            Email = "notegu@tegu.net",
            FirstName = "No",
            LastName = "Tegu",
            PasswordHash = "$2a$11$CYcwsHlqq1qV77xdsUae3.OsTWD3GCm5P7716vnVdsw1wJHeEdQZ2"
            //PasswordHash = BCrypt.Net.BCrypt.HashPassword("notegu@tegu.net")
        };

        builder.Entity<User>().HasData(
            admintegu,
            bwtegu,
            mixedtegu,
            notegu);

        #endregion

        #region User Roles

        builder.Entity<UserRole>().HasData(
            new UserRole { UserId = admintegu.Id, RoleId = RoleDefinitions.Tegu.Id },
            new UserRole { UserId = admintegu.Id, RoleId = RoleDefinitions.Client.Id },
            new UserRole { UserId = bwtegu.Id, RoleId = RoleDefinitions.Client.Id },
            new UserRole { UserId = mixedtegu.Id, RoleId = RoleDefinitions.Client.Id }
        );

        #endregion

        #region OwnedTegus

        var bwtegu_tegu1 = new OwnedTegu
        {
            Id = Guid.Parse("6f867827-f9bc-4163-aca1-f702430613d7"),
            OwnerId = bwtegu.Id,
            TeguTypeId = TeguTypeDefinitions.ArgentineBW.Id,
            Name = "The Beast"
        };

        var mixedtegu_tegu1 = new OwnedTegu
        {
            Id = Guid.Parse("df37fe94-6167-4be4-8270-0fdee04a83e8"),
            OwnerId = mixedtegu.Id,
            TeguTypeId = TeguTypeDefinitions.ArgentineBW.Id,
            Name = "Stop hiding!"
        };
        var mixedtegu_tegu2 = new OwnedTegu
        {
            Id = Guid.Parse("317d3ecd-3a02-4e39-9e8b-b30d31494b72"),
            OwnerId = mixedtegu.Id,
            TeguTypeId = TeguTypeDefinitions.ArgentineRed.Id,
            Name = "Don't eat my shoes!"
        };
        var mixedtegu_tegu3 = new OwnedTegu
        {
            Id = Guid.Parse("e3757b2f-734f-43ad-b0d4-1300766ed7a0"),
            OwnerId = mixedtegu.Id,
            TeguTypeId = TeguTypeDefinitions.Columbian.Id,
            Name = "No, those fingers are not food!"
        };

        builder.Entity<OwnedTegu>().HasData(
            bwtegu_tegu1,
            mixedtegu_tegu1,
            mixedtegu_tegu2,
            mixedtegu_tegu3);

        #endregion


        OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}