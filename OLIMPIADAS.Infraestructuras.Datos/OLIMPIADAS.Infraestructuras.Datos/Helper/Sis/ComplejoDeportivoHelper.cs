using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Infraestructuras.Datos.Helper.Sis
{
    public class ComplejoDeportivoHelper : HelperBase
    {
        public ComplejoDeportivoHelper() : base(Properties.Resources.ComplejoDeportivoSql)
        {
        }
        public string SqlGetListaComplejoDeportivo
        {
            get { return base.GetSqlXml("GetListaComplejoDeportivo"); }
        }
        public string SqlSaveComplejoDeportivo
        {
            get { return base.GetSqlXml("UpdateComplejoDeportivo"); }
        }
        public string SqlDeleteComplejoDeportivo
        {
            get { return base.GetSqlXml("DeleteComplejoDeportivo"); }
        }
    }
}
