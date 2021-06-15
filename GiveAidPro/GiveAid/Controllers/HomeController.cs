using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiveAid.Models;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;
using System.Web.Helpers;

namespace GiveAid.Controllers
{
    public class HomeController : Controller
    {
        db_GiveAidProEntities1 db;
        // GET: Home
        public ActionResult Index()
        {
            db = new db_GiveAidProEntities1();
            ViewBag.Causes = db.tbl_DonationCause.OrderBy(o => o.PK_ID).Where(w => w.Active == true).Take(3).ToList();
            ViewBag.About = db.tbl_About.OrderBy(o => o.PK_ID).Take(1).ToList();
            ViewBag.HelpCentre = db.tbl_QnA.OrderByDescending(o => o.DateTime).Where(w => w.Answer != null && w.Active == true).Take(3).ToList();
            ViewBag.Activities = db.tbl_Activity.OrderBy(o => o.PK_ID).Where(w => w.Active == true).Take(5);
            ViewBag.Partners = db.tbl_Partner.OrderBy(o => o.PK_ID).Where(w => w.Active == true).Take(4);
            return View();
        }
        public async Task<ActionResult> CauseDetails(int? id)
        {
            db = new db_GiveAidProEntities1();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_DonationCause tbl_DonationCause = await db.tbl_DonationCause.FindAsync(id);
            if (tbl_DonationCause == null)
            {
                return HttpNotFound();
            }
            return View(tbl_DonationCause);
        }
        public async Task<ActionResult> HelpCentre()
        {
            db = new db_GiveAidProEntities1();
            return View(await db.tbl_QnA.OrderByDescending(o => o.DateTime).Where(w => w.Answer != null && w.Active == true).Take(12).ToListAsync());
        }
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(Contact con)
        {
            try
            {

                con.ToEmail = "giveaidpro@gmail.com";
                con.EMailBody = con.UserEmail + "      " + con.EMailBody;
                WebMail.SmtpServer = "smtp.gmail.com";
                //gmail port to send emails  
                WebMail.SmtpPort = 587;
                WebMail.SmtpUseDefaultCredentials = true;
                //sending emails with secure protocol  
                WebMail.EnableSsl = true;
                WebMail.UserName = "giveaidpro@gmail.com";
                WebMail.Password = "giveaidpro123";
                WebMail.From = "giveaidpro@gmail.com";
                //Send email  

                WebMail.Send(to: con.ToEmail, subject: con.EmailSubject, body: con.EMailBody, isBodyHtml: true);
                ViewBag.Status = "Email Sent Successfully.";

            }
            catch (Exception ex)
            {
                ex.ToString();
                ViewBag.Status = "Problem while sending email, Please check details.";
            }
            return View();
        }
        public ActionResult About()
        {
            db = new db_GiveAidProEntities1();

            var Abt = db.tbl_About.Where(w => w.Active == true && w.Deleted == false);
            if (Abt != null)
            {
                ViewBag.Abt = Abt.OrderBy(o => o.PK_ID).Take(1).ToList();
            }

            var Ach = db.tbl_OurAchievements.Where(w => w.Active == true && w.Deleted == false);
            if (Ach != null)
            {
                ViewBag.Ach = Ach.OrderBy(o => o.PK_ID).Take(3).ToList();
            }

            var Part = db.tbl_Partner.Where(w => w.Active == true && w.Deleted == false);
            if (Part != null)
            {
                ViewBag.Part = Part.OrderBy(o => o.PK_ID).Take(3).ToList();
            }

            var Team = db.tbl_TeamMember.Where(w => w.Active == true && w.Deleted == false);
            if (Team != null)
            {
                ViewBag.Team = Team.OrderBy(o => o.PK_ID).Take(3).ToList();
            }
            return View();
        }
    }
    
}