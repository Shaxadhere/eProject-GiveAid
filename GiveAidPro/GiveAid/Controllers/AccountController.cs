using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;
using System.Web.Security;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;
using System.IO;

namespace GiveAid.Controllers
{
    public class AccountController : Controller
    {
        db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        public ActionResult Login()
        {
            ViewBag.message = TempData["Message"];
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(Login log)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cred = db.tbl_User.FirstOrDefault(c => c.Email == log.Email && c.Password == log.Password);
                    if (cred != null)
                    {
                        FormsAuthentication.SetAuthCookie(log.Email, false);
                        Session["User"] = cred;
                        if (cred.FK_UserType == 1)
                        {
                            return RedirectToAction("Index", "Home", new { area = "AdminDash" });
                        }
                        else if (cred.FK_UserType == 3)
                        {
                            return RedirectToAction("Index", "Home", new { area = "User" });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid Credentials");
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                ModelState.AddModelError("unhandled", "Oops, something is wrong, have you tried checking your connection?");
            }
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Signup(tbl_User reg)
        {
            try
            {
                if (db.tbl_User.Any(o => o.Email == reg.Email))
                {
                    ViewBag.msg = "This Email is already in use";
                }
                else if (ModelState.IsValid)
                {
                    reg.FK_UserType = 3;
                    reg.Active = true;
                    reg.Deleted = false;
                    reg.Picture = "userdefault.jpeg";
                    db.tbl_User.Add(reg);
                    db.SaveChangesAsync();
                    string message = "Account created successfully";
                    TempData["Message"] = message;
                    FormsAuthentication.SetAuthCookie(reg.Email, false);
                    Session["User"] = reg;
                    return RedirectToAction("Index", "Home", new { area = "User" });
                }
                else
                {
                    ModelState.AddModelError("", "Please use valid data");
                }
            }
            catch
            {
                ModelState.AddModelError("unhandled", "Oops, something is wrong, have you tried checking your connection?");
            }
            return View();
        }
        public ActionResult Logout()
        {
            try
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                ModelState.AddModelError("unhandled", "Oops, something is wrong, have you tried checking your connection?");
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}