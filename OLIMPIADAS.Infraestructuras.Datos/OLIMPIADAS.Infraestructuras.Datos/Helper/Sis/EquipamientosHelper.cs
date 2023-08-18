using OLIMPIADAS.Base.Core;

namespace OLIMPIADAS.Infraestructuras.Datos.Helper.Sis
{
    public class EquipamientosHelper : HelperBase
    {
        public EquipamientosHelper() : base(Properties.Resources.EquipamientosSql)
        {
        }
        public string SqlGetEquipamientos
        {
            get { return base.GetSqlXml("GetListaEquipamientos"); }
        }
    }
}
