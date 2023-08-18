namespace OLIMPIADAS.Servicios.Aplicacion.General
{
    public class ConstantesAppServicio
    {
        public const string FormatoFecha = "dd/MM/yyyy";
        public const string ParametroDefecto = "-1";
        public const string LoginAction = "Login";
        public const string DefaultControler = "Pages";
        public const string ExtensionPdf = "pdf";
        public const string ExtensionPng = "png";
        public const string ExtensionJpg = "jpg";
        public const string ExtensionMp4 = "mp4";

        public const string PathWroot = "C:\\inetpub\\wwwroot\\site\\";

        public const string Activo = "A";
        public const string Activoname = "ACTIVO";
        public const string Inactivo = "B";
        public const string Inactivoname = "INACTIVO";
        public const string Borrado = "C";
        public const string Eliminado = "X";
        public const string Eliminadoname = "ELIMINADO";

        public const int Pendiente = 0;
        public const string Pendientename = "PENDIENTE";
        public const int Aprobado = 1;
        public const int CodiPadre = 0;
        public const string Aprobadoname = "APROBADO";
        public const int Desaprobado = 2;
        public const string Desaprobadoname = "DESAPROBADO";
        public const int Preaprobado = 3;
        public const string Preaprobadoname = "PRE-APROBADO";
        public const int Predesaprobado = 4;
        public const string Predesaprobadoname = "PRE-DESAPROBADO";

        public const int RegEventoNone = 0;
        public const int RegEventoNew = 1;
        public const int RegEventoUpd = 2;
        public const int RegEventoDel = 3;

        public const string InitialUrl = "InitialUrl";
        public const string Pageview = "Pageview";

        public const int ArchTipoDni = 1;
        public const int ArchTipoImagen = 2;
        public const int ArchTipoFirma = 3;
        public const int TODOS = -1;

    }

    /// <summary>
    /// Constantes para los datos de sesion
    /// </summary>
    public class DatosSesion
    {
        public const string SesionUsuario = "SesionUsuario";
        public const string InicioSesion = "InicioSesion";
        public const string SesionMenucodi = "SesionMenucodi";
        public const string SesionDoccodi = "SesionDoccodi";
        public const string SesionOrden = "SesionOrden";
        public const string SesionEstados = "SesionEstados";
    }
}
