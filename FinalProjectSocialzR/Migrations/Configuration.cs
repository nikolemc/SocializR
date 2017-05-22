namespace FinalProjectSocialzR.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using FinalProjectSocialzR.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProjectSocialzR.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalProjectSocialzR.Models.ApplicationDbContext context)
        {
            var restrictedUser = "restrictedUser";
            var superUser = "superUser";
            var administrator = "administrator";

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);


            if (!context.Roles.Any(a => a.Name == restrictedUser))
            {
                var role = new IdentityRole { Name = restrictedUser };
                manager.Create(role);
            }
            if (!context.Roles.Any(a => a.Name == superUser))
            {
                var role = new IdentityRole { Name = superUser };
                manager.Create(role);
            }
            if (!context.Roles.Any(a => a.Name == administrator))
            {
                var role = new IdentityRole { Name = administrator };
                manager.Create(role);
            }

            var defaultAdministrator = "admin@gmail.com";
            var password = "Password1!";

            if (!context.Users.Any(a => a.UserName == defaultAdministrator))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultAdministrator };

                userManager.Create(user, password);
                userManager.AddToRole(user.Id, administrator);
            }


        }
    }
}
