using OLIMPIADAS.Servicios.Aplicacion.General;
using System.Web.Mvc;

namespace Gestor.MVC.Controllers
{
    public class BaseController : Controller
    {
        public bool IsValidSesion
        {
            get
            {
                if (Session[DatosSesion.SesionUsuario] != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Permite redirigir a la página de inicio
        /// </summary>
        public ActionResult RedirectToLogin()
        {
            string url = System.Web.HttpContext.Current.Request.Url.PathAndQuery;
            return RedirectToAction(ConstantesAppServicio.LoginAction, ConstantesAppServicio.DefaultControler);
        }
    }
}