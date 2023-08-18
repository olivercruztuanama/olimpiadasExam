using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Infraestructuras.Datos.Helper.Sis
{
    public class EstadosHelper : HelperBase
    {
        public EstadosHelper() : base(Properties.Resources.EstadosSql)
        {
        }
        public string SqlGetEstados
        {
            get { return base.GetSqlXml("GetListaEstados"); }
        }
    }
}
