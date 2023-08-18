namespace OLIMPIADAS.Dominio.DTO.Sedes
{
    public class ComplejoDeportivoDTO : EstadosDTO
    {
        public int IdComplejoDeportivo { get; set; }
        public string ComplejoDeportivoDes { get; set; }
        public int IdSede { get; set; }
        public int IdTipoComplejoDeportivo { get; set; }
    }
    public class ComplejoDeportivoAdiDTO : ComplejoDeportivoDTO
    {
        public string SedeDes { get; set; }
        public string TipoComplejoDeportivoDes { get; set; }
    }
}
