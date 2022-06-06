using Microsoft.EntityFrameworkCore;
using Tegu.Net.Backend.Data.SQL.Entities;
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





        OnModelCreatingPartial(builder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}