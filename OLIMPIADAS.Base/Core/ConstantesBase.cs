/*****************************************************************************************
* Fecha de Creación: 29-1-2017
* Creado por: TRASCEND
* Descripción: Clase que contiene las constantes de capa de persitencia
*****************************************************************************************/



namespace OLIMPIADAS.Base.Core
{
    public class ConstantesBase
    {
        #region Constantes DAOHelperBase

        public const string Aplicacion = "RutaSqlAplicacion";
        public const string ExtensionSqlXml = "Sql.xml";
        public const string Insertar = "USP_SAVE_";
        public const string Actualizar = "USP_UPDATE_";
        public const string Eliminar = "USP_DELETE_";
        public const string Listar = "USP_LIST_";
        public const string ObtenerPorId = "USP_GETBYID_";
        public const string ObtenerPorCriterio = "USP_GETBYCRITERIA_";
        public const string KeyInsertar = "Save";
        public const string KeyActualizar = "Update";
        public const string KeyEliminar = "Delete";
        public const string KeyListar = "List";
        public const string KeyObtenerPorId = "GetById";
        public const string KeyObtenerPorCriterio = "GetByCriteria";
        public const string KeyTotalRecords = "TotalRecords";
        public const string KeyGetMaxId = "GetMaxId";
        public const string MainNodeSql = "Sqls";
        public const string SubNodeSql = "Sql";
        public const string KeyNode = "key";
        public const string QueryNode = "query";
        public const string SI = "S";
        public const string NO = "N";
        public const string FormatoFecha = "yyyy-MM-dd";
        public const string FormatoFechaExtendido = "yyyy-MM-dd HH:mm:ss";
        public const string FormatoFechaHora = "yyyy-MM-dd HH:mm";

        #endregion  
    }
}
