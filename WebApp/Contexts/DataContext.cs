using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Contexts;

public class DataContext : IdentityDbContext<UserEntity>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<UserAddressEntity> UserAddresses { get; set; }

    public DbSet<ProductEntity> Products { get; set; }

    public DbSet<TagEntity> Tags { get; set; }

    public DbSet<ProductTagEntity> ProductTags { get; set; }

    public DbSet<ContactFormEntity> ContactForms { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole {
                Id = "f0237b71-fe5d-40b5-af1a-f703e065998d",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            },
            new IdentityRole
            {
                Id = "12fddf82-afca-405b-9c7a-f827156eb4b1",
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
            });

        var passwordHasher = new PasswordHasher<UserEntity>();
        var userEntity = new UserEntity
        {
            Id = "4b9ae07c-75ef-4582-bd11-2b17ca2e0a97",
            UserName = "admin@domain.com",
            NormalizedUserName = "ADMIN@DOMAIN.COM",
            Email = "admin@domain.com",
            NormalizedEmail = "ADMIN@DOMAIN.COM",
            ConcurrencyStamp = Guid.NewGuid().ToString(),

        };
        userEntity.PasswordHash = passwordHasher.HashPassword(userEntity, "BytMig123!");
        builder.Entity<UserEntity>().HasData(userEntity);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            UserId = userEntity.Id,
            RoleId = "f0237b71-fe5d-40b5-af1a-f703e065998d"
        });

        builder.Entity<TagEntity>().HasData(
            new TagEntity { Id = 1, TagName = "new" },
            new TagEntity { Id = 2, TagName = "featured"},
            new TagEntity { Id = 3, TagName = "popular"}
        );

        builder.Entity<ProductEntity>().HasData(
            new ProductEntity { Id = 1, Title = "HyperX Cloud 2", Price = 1190, ImageUrl = "https://assets.mmsrg.com/isr/166325/c1/-/ASSET_MMS_80726870/fee_786_587_png/HYPERX-Cloud-II-Wireless---Tr%C3%A5dl%C3%B6st-Gamingheadset-f%C3%B6r-PC--PS4-%26-Nintendo-Switch", Description = "Det ursprungliga HyperX Cloud II är ett ultrabekvämt gamingheadset med utmärkt ljud. " }
        );

        builder.Entity<ProductTagEntity>().HasData(
            new ProductTagEntity { ProductId = 1, TagId = 1 }    
        );
    }
}
