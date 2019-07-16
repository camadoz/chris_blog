namespace chris_blog.Migrations
{
    using chris_blog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<chris_blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(chris_blog.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            #region RoleManager
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>
                (context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }


            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            #endregion

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));


            if (!context.Users.Any(u => u.Email == "JoeSchmo@Mailinotor"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "madozc@gmail.com",
                    Email = "madozc@gmail.com",
                    FirstName = "Christophe",
                    LastName = "Madoz",
                    DisplayName = "ChrisM"


                }, "Abc&123! ");

            }


            if (!context.Users.Any(u => u.Email == "JoeSchmo@Mailinotor"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "madoz@gmail.com",
                    Email = "madoz@gmail.com",
                    FirstName = "Christopher",
                    LastName = "Mad",
                    DisplayName = "Chris"


                }, "Abc&123! ");
            }

            var userId = userManager.FindByEmail("madozc@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("madozc@gmail.com").Id;
            userManager.AddToRole(userId, "Moderator");
        }
    }
}
