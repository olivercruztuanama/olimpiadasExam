using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Infraestructuras.Datos.Helper.Sis
{
    public class TipoComplejosDeportivosHelper : HelperBase
    {
        public TipoComplejosDeportivosHelper() : base(Properties.Resources.TipoComplejosDeportivosSql)
        {
        }
        public string SqlGetListaTipoComplejosDeportivos
        {
            get { return base.GetSqlXml("GetListaTipoComplejosDeportivos"); }
        }
    }
}
