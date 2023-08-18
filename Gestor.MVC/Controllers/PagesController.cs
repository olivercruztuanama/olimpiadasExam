using OLIMPIADAS.Servicios.Aplicacion.General;
using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gestor.MVC.Controllers
{
    public class PagesController : Controller
    {
        public static String NombreCompleto, NTusername, version;
        string co = string.Empty;

        public ActionResult SearchResults()
        {
            return View();
        }

        public ActionResult LockScreen()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult InvoicePrint()
        {
            return View();
        }

        public ActionResult Login()
        {
            CerrarSesion();
            return View();
        }

        /// <summary>
        /// Permite cerrar sesion
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session[DatosSesion.SesionUsuario] = null;
            HttpCookie myCookie = new HttpCookie(DatosSesion.InicioSesion);
            myCookie.Expires = DateTime.Now.AddDays(-2d);
            Response.Cookies.Add(myCookie);
            return Json(1);
        }

        /// <summary>
        /// Permite realizar la validacion del usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> Autenticar(string usuario, string password)
        {
            string resultado = string.Empty;
            var entidad = await (new GeneralAppServicio()).AutentificarUsuarioAD(usuario.ToUpper(), password);

            if (entidad != null)
            {
                Session[DatosSesion.SesionUsuario] = entidad;
                this.CrearCokkie(usuario, 0);
                resultado = "1";
            }
            else
            {
                resultado = "Usuario o contraseña incorrecta!";
            }
            //if (entidad.Resultado == 1)
            //{
            //    FormsAuthentication.SetAuthCookie(usuario, false);
            //    //switch (entidad.Areacode)
            //    //{
            //    //    case ConstantesAppServicio.AreacodePortal: entidad.Areanomb = ConstantesAppServicio.AreanombPortal; break;
            //    //    case ConstantesAppServicio.AreacodeDiprove: entidad.Areanomb = ConstantesAppServicio.AreanombDiprove; break;
            //    //    case ConstantesAppServicio.AreacodeInterpol: entidad.Areanomb = ConstantesAppServicio.AreanombInterpol; break;
            //    //}
            //    Session[DatosSesion.SesionUsuario] = entidad;
            //    this.CrearCokkie(usuario, 0);
            //    resultado = entidad.Resultado.ToString();
            //}
            //else
            //{
            //    resultado = "Usuario o contraseña incorrecta!";
            //    //entidad = this.servicio.AutentificarUsuario(usuario, password, out resultado);
            //    //if (resultado == 1 || password == "47896")
            //    //{
            //    //    resultado = 1;
            //    //    FormsAuthentication.SetAuthCookie(usuario, false);
            //    //    Session[DatosSesion.SesionUsuario] = entidad;
            //    //    this.CrearCokkie(usuario, indicador);
            //    //}
            //}

            return Json(resultado);

        }

        /// <summary>
        /// Permite crear una cokkie con los datos del usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="indicador"></param>
        protected void CrearCokkie(string userName, int indicador)
        {
            if (indicador == 1)
            {
                HttpCookie cookie = Request.Cookies[DatosSesion.InicioSesion];

                if (cookie == null)
                {
                    cookie = new HttpCookie(DatosSesion.InicioSesion);
                }

                cookie[DatosSesion.SesionUsuario] = userName;
                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
            }
            else
            {
                HttpCookie myCookie = new HttpCookie(DatosSesion.InicioSesion);
                myCookie.Expires = DateTime.Now.AddDays(-2d);
                Response.Cookies.Add(myCookie);
            }
        }

        public ActionResult Login_2()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult NotFoundError()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult EmptyPage()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }


    }
}