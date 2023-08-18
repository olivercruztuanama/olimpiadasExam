using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Infraestructuras.Datos.Helper.Sis
{
    public class SedesHelper : HelperBase
    {
        public SedesHelper() : base(Properties.Resources.SedesSql)
        {
        }
        public string SqlGetSedes
        {
            get { return base.GetSqlXml("GetListaSedes"); }
        }
        public string SqlUpdateSedes
        {
            get { return base.GetSqlXml("UpdateSedes"); }
        }
        public string SqlDeleteSedes
        {
            get { return base.GetSqlXml("DeleteSedes"); }
        }
    }
}
