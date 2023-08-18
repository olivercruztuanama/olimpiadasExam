using OLIMPIADAS.Base.Core;

namespace EMPENIO.Dominio.DTO.Sedes
{
    public class AreaLocalizacionDTO : EntityBase
    {
        public int IdAreaLocalizacion { get; set; }
        public string Descripcion { get; set; }
        public decimal Area { get; set; }
    }
}
