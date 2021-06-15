using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using GiveAid.Models;
using GiveAid.Security;
using System.Linq;

namespace GiveAid.Areas.User.Controllers
{
    [FormAuthentication(RoleId = "3")]
    public class QnAController : Controller
    {
        private db_GiveAidProEntities1 db = new db_GiveAidProEntities1();
        public async Task<ActionResult> Index()
        {
            tbl_User user = (tbl_User)Session["User"];
            if (user == null)
            {
                user = new db_GiveAidProEntities1().tbl_User.FirstOrDefault(x => x.Email == User.Identity.Name);
            }
            var tbl_QnA = db.tbl_QnA.Include(t => t.tbl_User);
            return View(await tbl_QnA.Where(w => w.Deleted == false && w.FK_User == user.PK_ID).ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(tbl_QnA tbl_QnA)
        {
            tbl_User user = (tbl_User)Session["User"];
            if (user == null)
            {
                user = new db_GiveAidProEntities1().tbl_User.FirstOrDefault(x => x.Email == User.Identity.Name);
            }
            if (tbl_QnA.Question == null)
            {
                ModelState.AddModelError("Question", "Question field is required!");
            }

            tbl_QnA.FK_User = user.PK_ID;
            tbl_QnA.Answer = null;
            tbl_QnA.DateTime = DateTime.Now;
            tbl_QnA.Active = true;
            tbl_QnA.Deleted = false;

            try
            {
                if (ModelState.IsValid)
                {
                    db.tbl_QnA.Add(tbl_QnA);
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
                return Json(new { success = false, model = View(tbl_QnA) });
            }
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
