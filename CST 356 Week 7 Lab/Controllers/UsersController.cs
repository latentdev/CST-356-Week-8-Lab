using CST_356_Week_7_Lab.Models;
using CST_356_Week_7_Lab.Services;
using System.Web.Mvc;

namespace CST_356_Week_7_Lab.Controllers
{
    public class UsersController : Controller
    {
        private IUserService mService;

        public UsersController(IUserService userService)
        {
            mService = userService;
        }

        #region Actions
        // GET: User
        public ActionResult Index()
        {
            return View(mService.GetAllUsers());
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                mService.SaveUser(userViewModel);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(mService.GetUser(id));
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                mService.UpdateUser(userViewModel);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(mService.GetUser(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mService.DeleteUser(id);
            return RedirectToAction("Index");
        }
        #endregion
    }
}