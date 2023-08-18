using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Dominio.DTO.Login
{
    /// <summary>
    /// Clase que mapea la tabla menu
    /// </summary>
    public class MenuDTO : EntityBase
    {
        public string Codmenu { get; set; }
        public string Desmenu { get; set; }
        public int Orden { get; set; }
        public int Estado { get; set; }
        public string Controlmenu { get; set; }
    }
}
