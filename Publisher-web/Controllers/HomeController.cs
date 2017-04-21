using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bus.Abstract;
using Entity;
using Microsoft.Ajax.Utilities;

namespace Publisher_web.Controllers
{
    public class HomeController : Controller
    {
        private IJournalManager journalManager;
        public HomeController(IJournalManager journalManager)
        {
            this.journalManager = journalManager;
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Journals = journalManager.GetAll();
            return View();
        }

        public ActionResult Publishes(int id)
        {
            ViewBag.Publishes = journalManager.Get(id).Publishes;
            ViewBag.Journal = journalManager.Get(id).Name;
            return View();
        }

        /// <summary>
        /// Adds new journal
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (string.IsNullOrEmpty(form["JournalName"]))
            {
                TempData["notice"] = "Journal Name can not be empty";
            }
            else
            {
                var journal = new JournalModel
                {
                    Name = form["JournalName"],
                    PublishCount = 0
                };
                journalManager.InsertJournal(journal);
            }
            ViewBag.Journals = journalManager.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Publishes(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName))
            {
                if (!file.FileName.Split('.').Last().Equals("pdf"))
                {
                    TempData["notice"] = "Please choose a pdf file";
                }
                else
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                    var journalId = Convert.ToInt32(Request.UrlReferrer.ToString().Split('/').Last());
                    var publish = new PublishModel()
                    {
                        Name = fileName,
                        IsDeleted = false,
                        JournalId = journalId,
                        PublishDate = DateTime.Now,
                        Url = path
                    };
                    if (journalManager.InsertPublish(publish))
                    {
                        var journal = journalManager.Get(journalId);
                        journal.PublishCount++;
                        journalManager.Update(journal);
                    }

                    file.SaveAs(path);
                }
            }
            return Redirect(Request.UrlReferrer.ToString());
        }

        
        public ActionResult Delete(int id)
        {
            journalManager.Delete(id);
            ViewBag.Journals = journalManager.GetAll();
            return View("Index");
        }
    }
}