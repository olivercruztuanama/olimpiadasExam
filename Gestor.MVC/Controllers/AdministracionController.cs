using Gestor.MVC.Models;
using OLIMPIADAS.Dominio.DTO.Sedes;
using OLIMPIADAS.Servicios.Aplicacion.General;
using OLIMPIADAS.Servicios.Aplicacion.Intranet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gestor.MVC.Controllers
{
    public class AdministracionController : BaseController
    {
        //
        // GET: /Administracion/
        public ActionResult Index()
        {
            return View();
        }

        #region Sedes

        /// <summary>
        /// Vista Sedes
        /// </summary>
        /// <returns></returns>
        public ActionResult Sedes()
        {
            if (!this.IsValidSesion) return this.RedirectToLogin();
            var model = new Objetos() { Pageview = int.Parse(ConfigurationManager.AppSettings[ConstantesAppServicio.Pageview].ToString()) };

            return View(model);
        }
        public async Task<JsonResult> GetListaSedes()
        {
            var model = new Objetos();
            model.Count = 1;
            var datos = await (new OlimpiadasServicios()).GetSedes();
            model.ListaEstados = (List<EstadosDTO>)Session[DatosSesion.SesionEstados];
            model.Htmlview = ListaSedesHtml(datos);
            var json = Json(model, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 1073741824;
            return json;
        }
        private string ListaSedesHtml(List<SedesDTO> lista)
        {
            StringBuilder strHtml = new StringBuilder();
            string siteRoot = ConfigurationManager.AppSettings[ConstantesAppServicio.InitialUrl].ToString();

            //***************************      CABECERA DE LA TABLA         ***********************************//
            strHtml.Append("");
            strHtml.Append(@"");
            strHtml.Append("<table class='table table-striped table-bordered table-hover dataTables-example'>");

            #region cabecera

            strHtml.Append("<thead>");

            strHtml.Append("<tr>");
            strHtml.Append("<th>&nbsp;</th>");
            strHtml.Append("<th>Sedes</th>");
            strHtml.Append("<th>Estado</th>");
            strHtml.Append("</tr>");

            strHtml.Append("</thead>");

            #endregion

            if (lista != null)
            {
                #region detalle

                strHtml.Append("<tbody>");

                foreach (var d in lista)
                {
                    strHtml.Append("<tr>");

                    strHtml.Append("<td style='text-align:center'>");
                    strHtml.Append("<a href='#' onclick=\"edit_('" + d.IdSede + "','" + d.SedeDes + "','" + d.IdEstado + "');\">");
                    strHtml.Append("<img src='" + siteRoot + "/Contenido/Images/btn-edit.png' /></a>&nbsp;");
                    strHtml.Append("<a href='#' onclick=\"delete_('" + d.IdSede + "');\">");
                    strHtml.Append("<img src='" + siteRoot + "/Contenido/Images/btn-cancel.png' /></a>");
                    strHtml.Append("</td>");
                    strHtml.Append("<td>" + d.SedeDes + "</td>");
                    strHtml.Append("<td>" + d.EstadoDes + "</td>");

                    strHtml.Append("</tr>");
                }

                strHtml.Append("</tbody>");
                #endregion
            }
            strHtml.Append("</table>");

            return strHtml.ToString();
        }
        public async Task<JsonResult> SaveSede(int id, string sede, int estado)
        {
            var obj = new SedesDTO()
            {
                IdSede = id,
                SedeDes = sede,
                IdEstado = estado
            };
            var json = new JsonResult();
            try
            {
                var datos = await new OlimpiadasServicios().UpdateSede(obj);

                var model = new Objetos();
                model.Count = 1;
                model.ListaEstados = (List<EstadosDTO>)Session[DatosSesion.SesionEstados];
                model.Htmlview = ListaSedesHtml(datos);
                json = Json(model);
            }
            catch (Exception ex)
            {
            }

            return json;
        }
        public async Task<JsonResult> DeleteSede(int id)
        {
            var json = new JsonResult();
            try
            {
                var datos = await new OlimpiadasServicios().DeleteSede(id);

                var model = new Objetos();
                model.Count = 1;
                model.ListaEstados = (List<EstadosDTO>)Session[DatosSesion.SesionEstados];
                model.Htmlview = ListaSedesHtml(datos);
                json = Json(model);
            }
            catch (Exception ex)
            {
            }

            return json;
        }

        #endregion

        #region ComplejoDeportivo

        /// <summary>
        /// Vista Complejos deportivos
        /// </summary>
        /// <returns></returns>
        public ActionResult ComplejoDeportivo()
        {
            if (!this.IsValidSesion) return this.RedirectToLogin();
            var model = new Objetos() { Pageview = int.Parse(ConfigurationManager.AppSettings[ConstantesAppServicio.Pageview].ToString()) };

            return View(model);
        }
        public async Task<JsonResult> GetListaComplejos()
        {
            var model = new Objetos();
            model.Count = 1;
            var datos = await (new OlimpiadasServicios()).GetListaComplejos();
            model.ListaSedes = await (new OlimpiadasServicios()).GetSedes();
            model.ListaTipoComplejosDeportivos = await (new OlimpiadasServicios()).GetTipoComplejosDeportivos();
            model.ListaEstados = (List<EstadosDTO>)Session[DatosSesion.SesionEstados];
            model.Htmlview = ListaComplejosHtml(datos);
            var json = Json(model, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 1073741824;
            return json;
        }
        private string ListaComplejosHtml(List<ComplejoDeportivoAdiDTO> lista)
        {
            StringBuilder strHtml = new StringBuilder();
            string siteRoot = ConfigurationManager.AppSettings[ConstantesAppServicio.InitialUrl].ToString();

            //***************************      CABECERA DE LA TABLA         ***********************************//
            strHtml.Append("");
            strHtml.Append(@"");
            strHtml.Append("<table class='table table-striped table-bordered table-hover dataTables-example'>");

            #region cabecera

            strHtml.Append("<thead>");

            strHtml.Append("<tr>");
            strHtml.Append("<th>&nbsp;</th>");
            strHtml.Append("<th>Complejo Deportivo</th>");
            strHtml.Append("<th>Sede</th>");
            strHtml.Append("<th>Tipo</th>");
            strHtml.Append("<th>Estado</th>");
            strHtml.Append("</tr>");

            strHtml.Append("</thead>");

            #endregion

            if (lista != null)
            {
                #region detalle

                strHtml.Append("<tbody>");

                foreach (var d in lista)
                {
                    strHtml.Append("<tr>");

                    strHtml.Append("<td style='text-align:center'>");
                    strHtml.Append("<a href='#' onclick=\"edit_('" + d.IdComplejoDeportivo + "','" + d.ComplejoDeportivoDes + "','" + d.IdSede + "','" + d.IdTipoComplejoDeportivo + "','" + d.IdEstado + "');\">");
                    strHtml.Append("<img src='" + siteRoot + "/Contenido/Images/btn-edit.png' /></a>&nbsp;");
                    strHtml.Append("<a href='#' onclick=\"delete_('" + d.IdComplejoDeportivo + "');\">");
                    strHtml.Append("<img src='" + siteRoot + "/Contenido/Images/btn-cancel.png' /></a>");
                    strHtml.Append("</td>");
                    strHtml.Append("<td>" + d.ComplejoDeportivoDes + "</td>");
                    strHtml.Append("<td>" + d.SedeDes + "</td>");
                    strHtml.Append("<td>" + d.TipoComplejoDeportivoDes + "</td>");
                    strHtml.Append("<td>" + d.EstadoDes + "</td>");

                    strHtml.Append("</tr>");
                }

                strHtml.Append("</tbody>");
                #endregion
            }
            strHtml.Append("</table>");

            return strHtml.ToString();
        }
        public async Task<JsonResult> SaveComplejoDeportivo(int id, string complejo, int sede, int tipo, int estado)
        {
            var obj = new ComplejoDeportivoDTO()
            {
                IdComplejoDeportivo = id,
                ComplejoDeportivoDes = complejo,
                IdSede = sede,
                IdTipoComplejoDeportivo = tipo,
                IdEstado = estado
            };
            var json = new JsonResult();
            try
            {
                var datos = await new OlimpiadasServicios().SaveComplejoDeportivo(obj);

                var model = new Objetos();
                model.Count = 1;
                model.ListaSedes = await (new OlimpiadasServicios()).GetSedes();
                model.ListaTipoComplejosDeportivos = await (new OlimpiadasServicios()).GetTipoComplejosDeportivos();
                model.ListaEstados = (List<EstadosDTO>)Session[DatosSesion.SesionEstados];
                model.Htmlview = ListaComplejosHtml(datos);
                json = Json(model);
            }
            catch (Exception ex)
            {
            }

            return json;
        }
        public async Task<JsonResult> DeleteComplejoDeportivo(int id)
        {
            var json = new JsonResult();
            try
            {
                var datos = await new OlimpiadasServicios().DeleteComplejoDeportivo(id);

                var model = new Objetos();
                model.Count = 1;
                model.ListaSedes = await (new OlimpiadasServicios()).GetSedes();
                model.ListaTipoComplejosDeportivos = await (new OlimpiadasServicios()).GetTipoComplejosDeportivos();
                model.ListaEstados = (List<EstadosDTO>)Session[DatosSesion.SesionEstados];
                model.Htmlview = ListaComplejosHtml(datos);
                json = Json(model);
            }
            catch (Exception ex)
            {
            }

            return json;
        }

        #endregion

        #region Equipamientos

        /// <summary>
        /// Vista Equipamientos
        /// </summary>
        /// <returns></returns>
        public ActionResult Equipamientos()
        {
            if (!this.IsValidSesion) return this.RedirectToLogin();
            var model = new Objetos() { Pageview = int.Parse(ConfigurationManager.AppSettings[ConstantesAppServicio.Pageview].ToString()) };

            return View(model);
        }
        public async Task<JsonResult> GetListaEquipamientos()
        {
            var model = new Objetos();
            model.Count = 1;
            var datos = await (new OlimpiadasServicios()).GetEquipamientos();
            model.ListaEstados = (List<EstadosDTO>)Session[DatosSesion.SesionEstados];
            model.Htmlview = ListaEquipamientosHtml(datos);
            var json = Json(model, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = 1073741824;
            return json;
        }
        private string ListaEquipamientosHtml(List<EquipamientosDTO> lista)
        {
            StringBuilder strHtml = new StringBuilder();
            string siteRoot = ConfigurationManager.AppSettings[ConstantesAppServicio.InitialUrl].ToString();

            //***************************      CABECERA DE LA TABLA         ***********************************//
            strHtml.Append("");
            strHtml.Append(@"");
            strHtml.Append("<table class='table table-striped table-bordered table-hover dataTables-example'>");

            #region cabecera

            strHtml.Append("<thead>");

            strHtml.Append("<tr>");
            strHtml.Append("<th>&nbsp;</th>");
            strHtml.Append("<th>Equipamientos</th>");
            strHtml.Append("<th>Estado</th>");
            strHtml.Append("</tr>");

            strHtml.Append("</thead>");

            #endregion

            if (lista != null)
            {
                #region detalle

                strHtml.Append("<tbody>");

                foreach (var d in lista)
                {
                    strHtml.Append("<tr>");

                    strHtml.Append("<td style='text-align:center'>");
                    strHtml.Append("<a href='#' onclick=\"edit_('" + d.IdEquipamiento + "','" + d.EquipamientoDes + "','" + d.IdEstado + "');\">");
                    strHtml.Append("<img src='" + siteRoot + "/Contenido/Images/btn-edit.png' /></a>&nbsp;");
                    strHtml.Append("<a href='#' onclick=\"delete_('" + d.IdEquipamiento + "');\">");
                    strHtml.Append("<img src='" + siteRoot + "/Contenido/Images/btn-cancel.png' /></a>");
                    strHtml.Append("</td>");
                    strHtml.Append("<td>" + d.EquipamientoDes + "</td>");
                    strHtml.Append("<td>" + d.EstadoDes + "</td>");

                    strHtml.Append("</tr>");
                }

                strHtml.Append("</tbody>");
                #endregion
            }
            strHtml.Append("</table>");

            return strHtml.ToString();
        }

        #endregion

    }
}