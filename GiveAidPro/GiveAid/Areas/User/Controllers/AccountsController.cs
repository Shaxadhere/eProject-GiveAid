using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;
using System.Threading.Tasks;
using System.Net;
using GiveAid.Security;
using System.IO;
using System.Data.Entity;

namespace GiveAid.Areas.User.Controllers
{
    [FormAuthentication(RoleId = "3")]
    public class AccountsController : Controller
    {
        db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        
        public ActionResult Settings()
        {
            tbl_User user = (tbl_User)Session["User"];
            return View();
        }

        [Authorize]
        public async Task<ActionResult> EditInfo(int? id)
        {
            tbl_User user = (tbl_User)Session["User"];
            if (user == null)
            {
                user = new db_GiveAidProEntities1().tbl_User.FirstOrDefault(x => x.Email == User.Identity.Name);
            }

            id = user.PK_ID;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_User tbl_User = await db.tbl_User.FindAsync(id);
            if (tbl_User == null)
            {
                return HttpNotFound();
            }
            return View(tbl_User);
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<ActionResult> EditInfo(HttpPostedFileBase file, tbl_User tbl_User)
        {
            if (file != null)
            {
                Random rd = new Random();
                int rdnum = rd.Next();
                string path = Server.MapPath("~/Templates/Frontend/img/");
                string filename = rdnum + file.FileName;
                string fullpath = Path.Combine(path, filename);
                file.SaveAs(fullpath);
                tbl_User.Picture = rdnum + file.FileName;
            }
            if (ModelState.IsValid)
            {
                if (tbl_User.FullName == null)
                {
                    db.Entry(tbl_User).State = EntityState.Modified;
                    db.Entry(tbl_User).Property("FullName").IsModified = false;
                    db.Entry(tbl_User).Property("Active").IsModified = false;
                    db.Entry(tbl_User).Property("Deleted").IsModified = false;
                    db.Entry(tbl_User).Property("FK_UserType").IsModified = false;

                }
                if (tbl_User.Email == null)
                {
                    db.Entry(tbl_User).State = EntityState.Modified;
                    db.Entry(tbl_User).Property("Email").IsModified = false;
                    db.Entry(tbl_User).Property("Active").IsModified = false;
                    db.Entry(tbl_User).Property("Deleted").IsModified = false;
                    db.Entry(tbl_User).Property("FK_UserType").IsModified = false;
                }
                if (tbl_User.Password == null)
                {
                    db.Entry(tbl_User).State = EntityState.Modified;
                    db.Entry(tbl_User).Property("Password").IsModified = false;
                    db.Entry(tbl_User).Property("Active").IsModified = false;
                    db.Entry(tbl_User).Property("Deleted").IsModified = false;
                    db.Entry(tbl_User).Property("FK_UserType").IsModified = false;
                }
                if (tbl_User.Picture == null)
                {
                    db.Entry(tbl_User).State = EntityState.Modified;
                    db.Entry(tbl_User).Property("Picture").IsModified = false;
                    db.Entry(tbl_User).Property("Active").IsModified = false;
                    db.Entry(tbl_User).Property("Deleted").IsModified = false;
                    db.Entry(tbl_User).Property("FK_UserType").IsModified = false;
                }

                await db.SaveChangesAsync();
                return View();
            }
            return View(tbl_User);
        }
    }
}