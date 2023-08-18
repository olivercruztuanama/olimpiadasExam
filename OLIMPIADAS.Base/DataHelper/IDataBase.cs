/*********************************************************************************
* Fecha de Creación: 29-11-2017
* Creado por: TRASCEND
* Fecha de Modificación:
* Modificado por:
* Descripción: Interface que define los métodos de acceso a datos.
*********************************************************************************/

using System.Data;
using System.Data.Common;

namespace OLIMPIADAS.Base.DataHelper
{
    public interface IDataBase
    {
        DbCommand GetStoredProcCommand(string storedProcedureName);
        DbCommand GetSqlStringCommand(string query);
        void AddInParameter(DbCommand command, string name, DbType dbType, object value);
        IDataReader ExecuteReader(DbCommand command);
        void AddOutParameter(DbCommand command, string name, DbType dbType, int size);
        object GetParameterValue(DbCommand command, string name);
        object ExecuteScalar(DbCommand command);
        int ExecuteNonQuery(DbCommand command);
        void LoadDataSet(DbCommand command, DataSet dataSet, string tableName);

    }
}
