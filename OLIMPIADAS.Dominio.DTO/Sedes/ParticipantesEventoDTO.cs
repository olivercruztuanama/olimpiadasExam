using OLIMPIADAS.Base.Core;

namespace EMPENIO.Dominio.DTO.Sedes
{
    public class ParticipantesEventoDTO : EntityBase
    {
        public int IdParticipantesEvento { get; set; }
        public int IdEvento { get; set; }
        public int IdParticipante { get; set; }
    }
}
