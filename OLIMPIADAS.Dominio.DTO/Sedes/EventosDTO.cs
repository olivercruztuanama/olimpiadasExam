using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Dominio.DTO.Sedes
{
    public class EventosDTO : EntityBase
    {
        public int IdEvento { get; set; }
        public int IdPresupuestoComplejoDeportivo { get; set; }
        public int IdTipoEvento { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int Duracion { get; set; }
    }
}