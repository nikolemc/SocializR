using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProjectSocialzR.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FinalProjectSocialzR.Controllers
{
    public class UserCRUDController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

       
        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            var UserToDelete = db.Users.Find(id);
            db.Users.Remove(UserToDelete);
            db.SaveChanges();

            var vm = db.Users.ToList();
            return RedirectToAction("Index"); 
        }

       
        [HttpPost]
        public ActionResult EditUserInfo(ApplicationUser UserInfoToEdit)
        {
            var UserToEdit = db.Users.Find(UserInfoToEdit.Id);
            UserToEdit.UserName = UserInfoToEdit.UserName;      
            
            db.SaveChanges();

            var vm = db.Users.ToList();
            return View("Index", vm);
        }

        

        [HttpPost]
        public ActionResult ModifyUserRole(string UserId, string RoleName)
        {
           
            var userStore = new UserStore<ApplicationUser>(db);

            var userManager = new UserManager<ApplicationUser>(userStore);
            var oldRole = userManager.GetRoles(UserId).FirstOrDefault();
            userManager.RemoveFromRole(UserId, oldRole);
            userManager.AddToRole(UserId, RoleName);

            db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult AddNewUser(ApplicationUser UserInfoToAdd)
        {

            var userStore = new UserStore<ApplicationUser>(db);

            var userManager = new UserManager<ApplicationUser>(userStore);
            UserInfoToAdd.CompanyId = db.Users.Find(User.Identity.GetUserId())?.CompanyId;
            userManager.Create(UserInfoToAdd, "Password1!");
            userManager.AddToRole(UserInfoToAdd.Id, "restrictedUser");
            
            db.SaveChanges();

            var vm = db.Users.ToList();
            return View("Index", vm);
        }

        



        //closes the connection
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

