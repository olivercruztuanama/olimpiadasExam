using System.Web.Mvc;

namespace Gestor.MVC.Controllers
{
    public class DashboardsController : BaseController
    {
        public ActionResult Dashboard_1()
        {
            if (!this.IsValidSesion) return this.RedirectToLogin();
            else return RedirectToAction("Profile", "AppViews");
            //return View();
        }

        public ActionResult Dashboard_2()
        {
            return View();
        }

        public ActionResult Dashboard_3()
        {
            return View();
        }

        public ActionResult Dashboard_4()
        {
            return View();
        }

        public ActionResult Dashboard_4_1()
        {
            return View();
        }

        public ActionResult Dashboard_5()
        {
            return View();
        }

    }
}