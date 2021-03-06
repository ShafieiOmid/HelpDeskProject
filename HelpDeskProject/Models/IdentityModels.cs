﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace HelpDeskProject.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DatabaseContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    public class MyDbContext : DbContext
    {
        
        static MyDbContext()
        {
           
           Database.SetInitializer
                (new DropCreateDatabaseIfModelChanges<MyDbContext>());

          
        }

        public MyDbContext() : base("DatabaseContext")
		{
        }
        public DbSet<Devices.Printer.Printer> Printers { get; set; }
        public DbSet<RepairModel> Repairs { get; set; }
        public DbSet<Devices.Printer.Cartridge> Cartridges { get; set; }
    }
}