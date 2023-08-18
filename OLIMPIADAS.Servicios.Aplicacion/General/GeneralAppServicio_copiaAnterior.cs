using PNP.Dominio.DTO.Sis;
using PNP.Servicios.Aplicacion.Factory;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;


namespace PNP.Servicios.Aplicacion.General
{
    public class GeneralAppServicio
    {
        public List<PnpMenuDTO> GetListarMenu()
        {
            return FactorySis.GetPnpMenuRepository().List();
        }

        public string ListadoTareasHtml(PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cabecera
            //***************************      CABECERA DE LA TABLA         ***********************************//
            strHtml.Append("<table class='table table-striped table-bordered table-hover dataTables-example'>");

            strHtml.Append("<thead>");

            strHtml.Append("<tr>");
            strHtml.Append("<th>Pagina Web</th>");
            strHtml.Append("<th>Descripcion</th>");
            strHtml.Append("<th>Estado</th>");
            strHtml.Append("<th>Usuario</th>");
            strHtml.Append("<th>Fecha</th>");
            strHtml.Append("<th>Archivo/Imagen/Url</th>");
            strHtml.Append("<th>Tecnico realizó</th>");
            if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
            {
                strHtml.Append("<th>Direccion realizó</th>");
            }
            strHtml.Append("<th></th>");
            strHtml.Append("</tr>");

            strHtml.Append("</thead>");

            #endregion

            return strHtml.ToString();
        }

        public string ListadoTareasBannerHtml(List<PnpBannerDTO> lista, string color, int tipo, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cuerpo
            string url = string.Format(ConstantesAppServicio.PathDirectorioImage, usuario.Areanomb) + "{0}";
            
            foreach (var d in lista)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;
                strHtml.Append("<tr>");
                switch (tipo)
                {
                    case 1: strHtml.Append("<td bgcolor='" + color + "'>Banner</td>"); break;
                    case 2: strHtml.Append("<td bgcolor='" + color + "'>Mini Banner</td>"); break;
                }

                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }

                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado: 
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado: 
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }

                strHtml.Append("<td bgcolor='" + color + "'>" + d.Banntitulo + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'>"+ d.Bannimage + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick=\"clickView('" + string.Format(url, d.Bannimage) + "');\"><img src='/Contenido/Images/btn-open.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Banncodi + "," + d.Detregcodi + ",1,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Banncodi + "," + d.Detregcodi + ",1,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }

            #endregion

            return strHtml.ToString();
        }

        public string ListadoTareasComunicadosHtml(List<PnpComunicadosDTO> lista, string color, int tipo, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();
            
            #region cuerpo
            string url = "window.location=\"/pnp/intranet/AppViews/Exportar?fi={0}\"";
            
            foreach (var d in lista)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;

                strHtml.Append("<tr>");
                switch (tipo)
                {
                    case 1: strHtml.Append("<td bgcolor='" + color + "'>Comunicados</td>"); break;
                    case 2: strHtml.Append("<td bgcolor='" + color + "'>Notas de Prensa</td>"); break;
                }

                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }

                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Comtitulo + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Comarch + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick='" + string.Format(url, d.Comarch) + "';\"><img src='/Contenido/Images/btn-download.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Comcodi + "," + d.Detregcodi + ",2,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Comcodi + "," + d.Detregcodi + ",2,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }

            #endregion

            return strHtml.ToString();
        }

        public string ListadoTareasMenuHtml(List<PnpMenuDTO> lista, string color, int tipo, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cuerpo
            foreach (var d in lista)
            {
                strHtml.Append("<tr>");
                switch (tipo)
                {
                    case 1: strHtml.Append("<td bgcolor='" + color + "'>Menu Portal</td>"); break;
                    case 2: strHtml.Append("<td bgcolor='" + color + "'>Sub-Menu Portal</td>"); break;
                }
                string evento_ = string.Empty, aprob_ = string.Empty;
                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }
                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }

                strHtml.Append("<td bgcolor='" + color + "'>" + d.Menutitle + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Lastuser + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + (d.Lastdate != null ? d.Lastdate.ToString(ConstantesAppServicio.FormatoFecha) : "") + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Menuurl + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick='upd_(" + d.Menucodi + "," + d.Detregcodi + ",3,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Menucodi + "," + d.Detregcodi + ",3,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }

            #endregion

            return strHtml.ToString();
        }

        public string ListadoTareasVideosHtml(List<PnpVideosDTO> lista, string color, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cuerpo
            string url = string.Format(ConstantesAppServicio.PathDirectorioVideo, usuario.Areanomb) + "{0}";
            foreach (var d in lista)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;
                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }
                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }
                strHtml.Append("<tr>");
                strHtml.Append("<td bgcolor='" + color + "'>Videos</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Videotitulo + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Lastuser + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + (d.Lastdate != null ? d.Lastdate.ToString(ConstantesAppServicio.FormatoFecha) : "") + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Videoimage + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick=\"clickView('" + string.Format(url, d.Videolink) + "');\"><img src='/Contenido/Images/btn-open.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick=\"clickViewVideo('" + string.Format(url, d.Videoimage) + "', '" + string.Format(url, d.Videolink) + "');\"><img src='/Contenido/Images/ContextMenu/menueye.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Videocodi + "," + d.Detregcodi + ",2,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Videocodi + "," + d.Detregcodi + ",2,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }

            #endregion

            return strHtml.ToString();
        }

        public List<PnpUserDTO> GetUsuariosPNP()
        {
            return FactorySis.GetPnpUserRepository().List();
        }

        public PnpUserDTO GetByIdPnpUser(int usercode)
        {
            return FactorySis.GetPnpUserRepository().GetById(usercode, ConstantesAppServicio.ParametroDefecto);
        }

        public void DeleteUsuarioPNP(int usercode)
        {
            FactorySis.GetPnpUserRepository().Delete(usercode);
        }

        #region banner
        public List<PnpBannerDTO> GetBanner(int banntipo, int modcodi)
        {
            return FactorySis.GetPnpBannerRepository().GetByCriteria(banntipo, modcodi);
        }

        public PnpBannerDTO GetByIdBanner(int banncodi, int detregcodi)
        {
            return FactorySis.GetPnpBannerRepository().GetById(banncodi, detregcodi);
        }

        public void DeleteBanner(int banncodi)
        {
            FactorySis.GetPnpBannerRepository().Delete(banncodi);
        }
        #endregion

        #region comunicados
        public List<PnpComunicadosDTO> GetComunicados(int comtipo, int modcodi)
        {
            return FactorySis.GetPnpComunicadosRepository().GetByCriteria(comtipo, modcodi);
        }

        public PnpComunicadosDTO GetByIdComunicados(int comcodi, int detregcodi)
        {
            return FactorySis.GetPnpComunicadosRepository().GetById(comcodi, detregcodi);
        }

        public void DeleteComunicado(int comcodi)
        {
            FactorySis.GetPnpComunicadosRepository().Delete(comcodi);
        }
        #endregion

        #region menu portal

        public PnpMenuDTO GetByIdMenuPortal(int id, int detregcodi)
        {
            return FactorySis.GetPnpMenuRepository().GetById(id, detregcodi);
        }

        public List<PnpMenuDTO> GetMenuPortal(int padrecodi, int modcodi)
        {
            return FactorySis.GetPnpMenuRepository().GetByCriteria(padrecodi, modcodi);
        }

        public void DeleteMenu(int menucodi)
        {
            FactorySis.GetPnpMenuRepository().Delete(menucodi);
        }

        public void UpdateOnlyEstado(int id, string estado)
        {
            FactorySis.GetPnpDetalleregistroRepository().UpdateEstado(id, estado);
        }

        public void UpdateOnlyEstadoDetReg(int id, int evnt, int estado, int estadoEvnt)
        {
            FactorySis.GetPnpDetalleregistroRepository().UpdateEstadoDetalleReg(id, evnt, estado, estadoEvnt);
        }
        #endregion

        #region servicios al ciudadano

        public List<PnpDepservicioDTO> ListaDepServicios()
        {
            return FactorySis.GetPnpDepservicioRepository().List();
        }

        //public List<PnpDocumentosDTO> GetServiciosUsuario(int modcodi, int tipodoccodi)
        //{
        //    return FactorySis.GetPnpDocumentosRepository().GetByCriteria(modcodi, tipodoccodi);
        //}

        public PnpDocumentosDTO GetByIdDocumentos(int doccodi, int detregcodi)
        {
            return FactorySis.GetPnpDocumentosRepository().GetById(doccodi, detregcodi);
        }


        public string ListadoTareasServUsuariosHtml(List<PnpDocumentosDTO> ListaServiciosUsuario, string color, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cuerpo
            string url = "window.location=\"/pnp/intranet/AppViews/Exportar?fi={0}\"";

            foreach (var d in ListaServiciosUsuario)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;

                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }

                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }           


                strHtml.Append("<tr>");
                strHtml.Append("<td bgcolor='" + color + "'>Servicio al Usuario/Tramites</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombre + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombarch1 + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick='" + string.Format(url, d.Docnombarch1) + "';\"><img src='/Contenido/Images/btn-download.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }
            
            #endregion

            return strHtml.ToString();
        }
        
        #endregion

        #region Normas Legales

        public string ListadoTareasNormasLegalesHtml(List<PnpDocumentosDTO> listaNLCiudadano, List<PnpDocumentosDTO> listaNLPolicia, string color, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cuerpo
            string url = "window.location=\"/pnp/intranet/AppViews/Exportar?fi={0}\"";

            foreach (var d in listaNLCiudadano)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;

                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }

                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }           


                strHtml.Append("<tr>");
                strHtml.Append("<td bgcolor='" + color + "'>Normas Legales/Ciudadano</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombre + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombarch1 + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick='" + string.Format(url, d.Docnombarch1) + "';\"><img src='/Contenido/Images/btn-download.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }

            foreach (var d in listaNLPolicia)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;

                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }

                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }
                strHtml.Append("<tr>");
                strHtml.Append("<td bgcolor='" + color + "'>Normas Legales/Policía</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombre + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombarch1 + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick='" + string.Format(url, d.Docnombarch1) + "';\"><img src='/Contenido/Images/btn-download.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }

            #endregion

            return strHtml.ToString();
        }

        #endregion

        #region videos
        public List<PnpVideosDTO> GetVideos(int modcodi)
        {
            return FactorySis.GetPnpVideosRepository().GetByCriteria(modcodi);
        }

        public PnpVideosDTO GetByIdVideos(int videocodi, int detregcodi)
        {
            return FactorySis.GetPnpVideosRepository().GetById(videocodi, detregcodi);
        }
        #endregion

        #region Contratacoines CAS


        public List<PnpDocumentosDTO> GetDocumentos(int modcodi, int tipodoccodi)
        {
            return FactorySis.GetPnpDocumentosRepository().GetByCriteria(modcodi, tipodoccodi);
        }

        public string ListadoTareasContratacionesCASHtml(List<PnpDocumentosDTO> listaContratacionesCAS, string color, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cuerpo
            string url = "window.location=\"/pnp/intranet/AppViews/Exportar?fi={0}\"";

            foreach (var d in listaContratacionesCAS)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;

                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }

                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }           


                strHtml.Append("<tr>");
                strHtml.Append("<td bgcolor='" + color + "'>Contrataciones CAS</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombre + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombarch1 + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick='" + string.Format(url, d.Docnombarch1) + "';\"><img src='/Contenido/Images/btn-download.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }
            

            #endregion

            return strHtml.ToString();
        }

        #endregion

        #region Concesiones

        public string ListadoTareasConcesionesHtml(List<PnpDocumentosDTO> listaConcesiones, string color, PnpUserDTO usuario)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cuerpo
            string url = "window.location=\"/pnp/intranet/AppViews/Exportar?fi={0}\"";

            foreach (var d in listaConcesiones)
            {
                string evento_ = string.Empty, aprob_ = string.Empty;

                switch (d.Registroevento)
                {
                    case ConstantesAppServicio.RegEventoNew: evento_ = "Nuevo"; break;
                    case ConstantesAppServicio.RegEventoUpd: evento_ = "Editó"; break;
                    case ConstantesAppServicio.RegEventoDel: evento_ = "Eliminó"; break;
                }

                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: aprob_ = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado:
                    case ConstantesAppServicio.Preaprobado: aprob_ = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado:
                    case ConstantesAppServicio.Predesaprobado: aprob_ = ConstantesAppServicio.Desaprobadoname; break;
                }


                strHtml.Append("<tr>");
                strHtml.Append("<td bgcolor='" + color + "'>Convocatoria a Conceciones </td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombre + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>Pendiente</td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'></td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + d.Docnombarch1 + "</td>");
                strHtml.Append("<td bgcolor='" + color + "'>" + evento_ + " registro" + "</td>");
                if (usuario.Userperfil == ConstantesAppServicio.UserperfilGeneral)
                {
                    strHtml.Append("<td bgcolor='" + color + "'>" + aprob_ + "</td>");
                }
                strHtml.Append("<td bgcolor='" + color + "' style='text-align:center'><a href='#' onclick='" + string.Format(url, d.Docnombarch1) + "';\"><img src='/Contenido/Images/btn-download.png' /></a>&nbsp;");
                strHtml.Append("<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,1);'><img src='/Contenido/Images/btn-ok.png' /></a>&nbsp;<a href='#' onclick='upd_(" + d.Doccodi + "," + d.Detregcodi + ",2,2);'><img src='/Contenido/Images/btn-cancel.png' /></a></td>");
                strHtml.Append("</tr>");
            }


            #endregion

            return strHtml.ToString();
        }

        #endregion

        #region adicionales

        public List<PnpAdicionalDTO> GetAdicionales(int aditipo, int modcodi)
        {
            return FactorySis.GetPnpAdicionalRepository().GetByCriteria(aditipo, modcodi);
        }

        public string AdicionalesHtml(List<PnpAdicionalDTO> lista, string areanomb)
        {
            StringBuilder strHtml = new StringBuilder();

            #region cabecera
            //***************************      CABECERA DE LA TABLA         ***********************************//
            strHtml.Append("<table class='table table-striped table-bordered table-hover dataTables-example'>");

            strHtml.Append("<thead>");

            strHtml.Append("<tr>");
            strHtml.Append("<th>Nombre</th>");
            strHtml.Append("<th>Descripcion</th>");
            strHtml.Append("<th>Imagen</th>");
            strHtml.Append("<th>Estado de Imagen</th>");
            strHtml.Append("<th>Visualizar en Web</th>");
            strHtml.Append("<th>Usuario</th>");
            strHtml.Append("<th></th>");
            strHtml.Append("</tr>");

            strHtml.Append("</thead>");

            #endregion

            #region cuerpo

            //***************************      CUERPO DE LA TABLA         ***********************************//
            string url = string.Format(ConstantesAppServicio.PathDirectorioImage, areanomb) + "{0}";
            strHtml.Append("<tbody>");

            foreach (var d in lista)
            {
                string estado1 = string.Empty, estado2 = string.Empty;
                switch (d.Registroestado)
                {
                    case ConstantesAppServicio.Activo: estado1 = ConstantesAppServicio.Activoname; break;
                    case ConstantesAppServicio.Inactivo: estado1 = ConstantesAppServicio.Inactivoname; break;
                }
                switch (d.Registroaprobar)
                {
                    case ConstantesAppServicio.Pendiente: estado2 = ConstantesAppServicio.Pendientename; break;
                    case ConstantesAppServicio.Aprobado: estado2 = ConstantesAppServicio.Aprobadoname; break;
                    case ConstantesAppServicio.Desaprobado: estado2 = ConstantesAppServicio.Desaprobadoname; break;
                    case ConstantesAppServicio.Preaprobado: estado2 = ConstantesAppServicio.Preaprobadoname; break;
                    case ConstantesAppServicio.Predesaprobado: estado2 = ConstantesAppServicio.Predesaprobadoname; break;
                }
                strHtml.Append("<tr class='gradeX'>");
                strHtml.Append("<td>" + d.Adititulo + "</td>");
                strHtml.Append("<td>" + d.Adidescrip + "</td>");
                strHtml.Append("<td>" + d.Adiimage + "</td>");
                strHtml.Append("<td>" + estado1 + "</td>");
                strHtml.Append("<td>" + estado2 + "</td>");
                strHtml.Append("<td>" + d.Lastuser + "</td>");
                if (d.Registroevento == ConstantesAppServicio.RegEventoNone)
                {
                    strHtml.Append("<td style='text-align:center'><a href='#' onclick=\"clickView('" + string.Format(url, d.Adiimage) + "');\"><img src='/Contenido/Images/Visualizar.png' /></a>&nbsp;");
                    strHtml.Append("<a href='#' onclick='edit_(" + d.Adicodi + ", " + d.Detregcodi + ");'><img src='/Contenido/Images/Pen.png' /></a>&nbsp;<a href='#' onclick='delete_(" + d.Adicodi + "," + d.Detregcodi + ");'><img src='/Contenido/Images/Trash.png' /></a></td>");
                }
                else { strHtml.Append("<td></td>"); }
                strHtml.Append("</tr>");
            }

            strHtml.Append("</tbody>");
            strHtml.Append("</table>");

            #endregion

            return strHtml.ToString();
        }

        #endregion

        #region usuarios
        public List<PnpUserprofileDTO> GetUsuariosDetallePNP(string usercodes)
        {
            return FactorySis.GetPnpUserprofileRepository().GetByCriteria(usercodes);
        }

        public List<PnpPerfilDTO> GetListPerfilesPNP()
        {
            return FactorySis.GetPnpPerfilRepository().List();
        }

        public List<PnpAreaDTO> GetListAreasPNP()
        {
            return FactorySis.GetPnpAreaRepository().List();
        }

        public List<PnpModuloDTO> GetListModulos()
        {
            return FactorySis.GetPnpModuloRepository().List();
        }

        public int SaveUsuario(PnpUserDTO obj, int tip)
        {
            return FactorySis.GetPnpUserRepository().Update(obj, tip);
        }

        public void SaveUsuarioDet(PnpUserprofileDTO obj)
        {
            FactorySis.GetPnpUserprofileRepository().Update(obj);
        }

        public void DeleteUsuarioDet(int id)
        {
            FactorySis.GetPnpUserprofileRepository().Delete(id);
        }
        #endregion
    }
}
