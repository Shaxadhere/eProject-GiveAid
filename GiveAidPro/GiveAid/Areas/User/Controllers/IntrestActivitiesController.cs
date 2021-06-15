using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;
using GiveAid.Security;

namespace GiveAid.Areas.User.Controllers
{
    [FormAuthentication(RoleId = "3")]
    public class IntrestActivitiesController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_Activity.OrderByDescending(o => o.DateTime).Where(w => w.Deleted == false).Take(10).ToListAsync());
        }
        public async Task<ActionResult> MyIntrest()
        {
            tbl_User user = (tbl_User)Session["User"];
            if (user == null)
            {
                user = new db_GiveAidProEntities1().tbl_User.FirstOrDefault(x => x.Email == User.Identity.Name);
            }
            return View(await db.tbl_IntrestActivities.Where(w => w.FK_User == user.PK_ID).ToListAsync());
        }
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Activity);
        }
        
        public async Task<ActionResult> SendIntrest(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Activity tbl_Activity = await db.tbl_Activity.FindAsync(id);
            if (tbl_Activity == null)
            {
                return HttpNotFound();
            }
            return View(new tbl_IntrestActivities() {FK_Activity=tbl_Activity.PK_ID });
        }
        
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> SendIntrest(tbl_IntrestActivities tbl_IntrestActivities)
        {
            tbl_User user = (tbl_User)Session["User"];
            if (user == null)
            {
                user = new db_GiveAidProEntities1().tbl_User.FirstOrDefault(x => x.Email == User.Identity.Name);
            }
            tbl_IntrestActivities.FK_User = user.PK_ID;
            tbl_IntrestActivities.Active = true;
            tbl_IntrestActivities.Deleted = false;
            tbl_IntrestActivities.DateTime = DateTime.Now;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_IntrestActivities.Add(tbl_IntrestActivities);
                    await db.SaveChangesAsync();
                    return Json(new { success = true });
                }
                else
                {
                    string errorsList = "";
                    foreach (var item in ModelState.Values)
                    {
                        foreach (var err in item.Errors)
                        {
                            errorsList += "<li>" + err.ErrorMessage + "</li>";
                        }
                    }
                    errorsList = "<ul>" + errorsList + "</ul>";
                    return Json(new { success = false, errors = errorsList });
                }
            }
            catch
            {
                return Json(new { success = false, model = View(tbl_IntrestActivities) });
            }
            
        }
        
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_IntrestActivities tbl_IntrestActivities = await db.tbl_IntrestActivities.FindAsync(id);
            if (tbl_IntrestActivities == null)
            {
                return HttpNotFound();
            }
            return View(tbl_IntrestActivities);
        }
        
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_IntrestActivities tbl_IntrestActivities = await db.tbl_IntrestActivities.FindAsync(id);
            db.tbl_IntrestActivities.Remove(tbl_IntrestActivities);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

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
