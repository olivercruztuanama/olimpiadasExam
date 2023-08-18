using OLIMPIADAS.Base.Core;

namespace EMPENIO.Dominio.DTO.Sedes
{
    public class PresupuestoComplejoDeportivoDTO : EntityBase
    {
        public int IdPresupuestoComplejoDeportivo { get; set; }
        public int IdComplejoDeportivo { get; set; }
        public decimal Presupuesto { get; set; }
    }
}
