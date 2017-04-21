using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Bus;
using Bus.Abstract;
using Entity;

namespace Subscriber_web.Controllers
{
    public class HomeController : Controller
    {
        private ISubscriberManager subscriberManager;
        private IJournalManager journalManager;
        public HomeController(IJournalManager journalManager,ISubscriberManager subscriberManager)
        {
            this.journalManager = journalManager;
            this.subscriberManager = subscriberManager;
        }

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Journals = journalManager.GetAll();
            return View();
        }

        public ActionResult Subscribe(int id)
        {
            //Subscribe
            var subsriberJournal = new SubscriberJournalModel
            {
                JournalId = id,
                SubscriberId = Convert.ToInt32(Session["LogedUserID"])
            };

            subscriberManager.Subscribe(subsriberJournal);
            FillViewBagForLoggedInUser();
            return View("Index");
        }

        public ActionResult UnSubscribe(int id)
        {
            subscriberManager.UnSubscribe(id);
            FillViewBagForLoggedInUser();
            return View("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username,string password)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                var loginUser = subscriberManager.Get(username, password);
                if (loginUser != null)
                {
                    Session["LogedUsername"] = loginUser.Username;
                    Session["LogedUserID"] = loginUser.Id.ToString();
                    FillViewBagForLoggedInUser();
                    return View("Index");
                }
            }

            return View(username);
        }

        public void FillViewBagForLoggedInUser()
        {
            var loginUser = subscriberManager.Get(Convert.ToInt32(Session["LogedUserID"]));
            if (loginUser != null)
            {
                ViewBag.UserSubscriptionList = loginUser.SubscriberJournalsList;
                ViewBag.Journals = journalManager.GetAll();
            }
        }
    }
}