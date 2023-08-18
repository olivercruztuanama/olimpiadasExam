using Gestor.MVC.Models;
using OLIMPIADAS.Dominio.DTO.Login;
using OLIMPIADAS.Servicios.Aplicacion.General;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Gestor.MVC.Controllers
{
    public class MenuController : BaseController
    {
        GeneralAppServicio _general = new GeneralAppServicio();

        // GET: Menu
        public ActionResult MenuPNP()
        {
            if (!this.IsValidSesion) return this.RedirectToLogin();

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PartialViewResult Menudet()
        {
            //if (Default) { return; }
            //ViewBag.MenudetPNP = _general.GetListarMenu();
            ViewBag.Menudet = this.CrearMenu();

            return PartialView();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public PartialViewResult DatosLoginIni()
        {
            int resu = 0;
            if (Session[DatosSesion.SesionUsuario] != null)
            {
                var usuario_ = (UsuariosDTO)Session[DatosSesion.SesionUsuario];
                //var datos = (new IntranetAppServicio()).AutentificarUsuarioAD(usuario_.Idusr, string.Empty, out resu);
                //datos.Areanomb = usuario_.Areanomb.ToUpper();
                ViewBag.DatosLoginIni = usuario_;
            }

            return PartialView();
        }

        ///<summary>
        ///Arma el menu segun la aplicación y el usuario
        ///</summary>
        ///<returns></returns>
        private IList<MenuModel> CrearMenu()
        {
            IList<MenuModel> list = new List<MenuModel>();

            var usuario = ((UsuariosDTO)Session[DatosSesion.SesionUsuario]);

            list.Add(new MenuModel() { Nombre = "Inicio", Descripcion = "Profile", DesControlador = "AppViews", ClassItem = "fa fa-th-large" });
            list.Add(new MenuModel() { Nombre = "Sedes", Descripcion = "Sedes", DesControlador = "Administracion", ClassItem = "fa fa-edit" });
            list.Add(new MenuModel() { Nombre = "Complejo Deportivo", Descripcion = "ComplejoDeportivo", DesControlador = "Administracion", ClassItem = "fa fa-edit" });
            list.Add(new MenuModel() { Nombre = "Equipamientos", Descripcion = "Equipamientos", DesControlador = "Administracion", ClassItem = "fa fa-edit" });
            list.Add(new MenuModel() { Nombre = "Salir", Descripcion = "Login", DesControlador = "Pages", ClassItem = "fa fa-window-close" });

            return list;
        }

    }
}