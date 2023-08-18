using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Infraestructuras.Datos.Helper.Sis
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper() : base(Properties.Resources.LoginSql)
        {
        }
        public string SqlGetLogin
        {
            get { return base.GetSqlXml("GetLogin"); }
        }
    }
}
