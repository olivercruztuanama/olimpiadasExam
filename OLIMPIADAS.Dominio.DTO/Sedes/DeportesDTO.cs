using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Dominio.DTO.Sedes
{
    public class DeportesDTO : EntityBase
    {
        public int IdDeporte { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
    }
}