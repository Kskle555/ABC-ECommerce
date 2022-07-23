using Abc.MvcWebUI.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Identity
{
    public class IdentityInitializer : DropCreateDatabaseIfModelChanges<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {


            //Rolleri

            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name="admin",Description="admin rolu"};
                manager.Create(role);

            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolu" }; 
                manager.Create(role);
                 
            }

            if (!context.Roles.Any(i => i.Name == "oguzbilgi"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "oguz", Surname = "bilgi", UserName = "kskle555", Email = "oguzhanbilgi35@gmail.com" };
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");

            }
            if (!context.Roles.Any(i => i.Name == "yagmurulusu"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var user = new ApplicationUser() { Name = "yagmur", Surname = "ulusu", UserName = "yagmurulusu", Email = "yagmurulusu@gmail.com" };
                manager.Create(user, "1234567");

                manager.AddToRole(user.Id, "user");

            }
            //user
            base.Seed(context);
        }
    }
}