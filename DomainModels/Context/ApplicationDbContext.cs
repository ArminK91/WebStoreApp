using System;
using System.IO;
using DomainModels.DbModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Design;

namespace DomainModels.Context
{
    public class ApplicationDbContext : DbContext
    {
         private IConfigurationRoot _configuration { get; }
         private readonly IHttpContextAccessor _httpContextAccessor;

         public ApplicationDbContext()
         {

         }
        public ApplicationDbContext(IConfiguration configuration, DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _configuration = (IConfigurationRoot)configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //ConnectionStrings:DefaultConnection
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"], b => b.MigrationsAssembly("DomainModels"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);




            //builder.Entity<IdentityRole>().ToTable("Roles", "dbo");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "dbo");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "dbo");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "dbo");
            //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "dbo");
            builder.Entity<ApplicationUser>().ToTable("Users", "dbo");

            //builder.Entity<ApplicationUser>().ToTable("Users", "dbo");
            builder.Entity<Product>().ToTable("Products", "dbo");
            builder.Entity<Customer>().ToTable("Customers", "dbo");
            builder.Entity<Image>().ToTable("Images", "dbo");
            builder.Entity<ProductImages>().ToTable("ProductsImages", "dbo");
            builder.Entity<Category>().ToTable("Categories", "dbo");
            builder.Entity<Automobil>().ToTable("Automobili", "dbo");
            builder.Entity<Sifarnik>().ToTable("Sifarnik", "dbo");


            builder.Entity<ProductImages>();


           

            builder.Entity<ProductImages>()
                .HasOne(bc => bc.Image)
                .WithMany(c => c.ProductImages)
                .HasForeignKey(bc => bc.ProductId);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductImages> ProductsImages { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Automobil> Automobili { get; set; }
        public DbSet<Sifarnik> Sifarnik { get; set; }

    }


  
}