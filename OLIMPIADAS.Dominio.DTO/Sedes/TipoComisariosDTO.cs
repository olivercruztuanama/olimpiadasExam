using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Dominio.DTO.Sedes
{
    public class TipoComisariosDTO : EntityBase
    {
        public int IdTipoComisario { get; set; }
        public string Descripcion { get; set; }
    }
}