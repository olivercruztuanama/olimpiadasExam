using Gestor.MVC.Models;
using OLIMPIADAS.Dominio.DTO.Sedes;
using OLIMPIADAS.Servicios.Aplicacion.General;
using OLIMPIADAS.Servicios.Aplicacion.Intranet;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gestor.MVC.Controllers
{
    public class AppViewsController : BaseController
    {
        public List<EstadosDTO> ListaEstados
        {
            get
            {
                return (Session[DatosSesion.SesionEstados] != null) ?
                    (List<EstadosDTO>)Session[DatosSesion.SesionEstados] : new List<EstadosDTO>();
            }
            set { Session[DatosSesion.SesionEstados] = value; }
        }

        public async Task<ActionResult> Profile()
        {
            if (!base.IsValidSesion) return base.RedirectToLogin();
            var model = new Objetos() { Pageview = int.Parse(ConfigurationManager.AppSettings[ConstantesAppServicio.Pageview].ToString()) };
            this.ListaEstados = await (new OlimpiadasServicios()).GetEstados();
            return View(model);
        }

    }
}