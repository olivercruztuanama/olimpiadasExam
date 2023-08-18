using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Dominio.DTO.Login
{
    /// <summary>
    /// Clase que mapea la tabla usuarios
    /// </summary>
    public class UsuariosDTO : EntityBase
    {
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
    }
}
