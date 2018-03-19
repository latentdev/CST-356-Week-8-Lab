using CST_356_Week_7_Lab.Models;
using CST_356_Week_7_Lab.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace CST_356_Week_7_Lab.Controllers
{
    [Authorize]
    public class ClassController : Controller
    {
        private IClassService mService;
        public ClassController(IClassService service)
        {
            mService = service;
        }

        // GET: Classes
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            ViewBag.userID = userID;

            return View(mService.GetAllClasses(userID));
        }

        public ActionResult Create(string userID)
        {
            ViewBag.userID = userID;
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClassViewModel classViewModel)
        {
            if (ModelState.IsValid)
            {
                mService.SaveClass(classViewModel);
                return RedirectToAction("Index", new { UserId = classViewModel.UserID });
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(mService.GetClass(id));
        }

        [HttpPost]
        public ActionResult Edit(ClassViewModel classViewModel)
        {
            if (ModelState.IsValid)
            {
                mService.UpdateClass(classViewModel);

                return RedirectToAction("Index", new { userID = classViewModel.UserID });
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var viewModel = mService.GetClass(id);
            viewModel.ClassLength = mService.CalculateClassLength(viewModel.StartTime, viewModel.EndTime);
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mService.DeleteClass(id);

            return RedirectToAction("Index", new { userID = id });
        }
    }
}