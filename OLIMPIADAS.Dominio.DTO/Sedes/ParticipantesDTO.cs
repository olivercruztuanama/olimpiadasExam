using OLIMPIADAS.Base.Core;

namespace EMPENIO.Dominio.DTO.Sedes
{
    public class ParticipantesDTO : EntityBase
    {
        public int IdParticipante { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
