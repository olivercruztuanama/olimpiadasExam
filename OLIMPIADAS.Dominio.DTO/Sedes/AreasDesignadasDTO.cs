using OLIMPIADAS.Base.Core;

namespace EMPENIO.Dominio.DTO.Sedes
{
    public class AreasDesignadasDTO : EntityBase
    {
        public int IdAreaDesignada { get; set; }
        public int IdTipoComplejo { get; set; }
        public int IdDeporte { get; set; }
        public int IdAreaLocalizacion { get; set; }
        public string Organizador { get; set; }
    }
}
