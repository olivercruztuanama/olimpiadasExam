/*****************************************************************************************
* Fecha de Creación: 29-11-2017
* Creado por: TRASCEND
* Descripción: Clase que implementa la interface de acceso a datos
* haciendo uso del Data Access Application Block
*****************************************************************************************/

using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace OLIMPIADAS.Base.DataHelper
{
    public class DbProvider
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Database dataBase;
        private readonly string _con;
        private readonly string sql = @"Server=.\SQLEXPRESS;Database=olimpiadas;Integrated Security=True;";
        private string _nameTable;
        private List<ColumnMaper> columnsMaper;



        /// <summary>
        /// Contructor de la clase
        /// </summary>
        /// <param name="dbName"></param>
        public DbProvider(string dbName)
        {
            _con = sql;
            _nameTable = string.Empty;
            columnsMaper = new List<ColumnMaper>();
        }


        public void AddColumnMapping(DbType dbType, SqlDbType sqlDbType, string name)
        {
            this.columnsMaper.Add(new ColumnMaper { DbTipo = dbType, SqlDbTipo = sqlDbType, Nombre = name });
        }
        public void TableName(string name)
        {
            _nameTable = name;
        }

        public async Task<DataTable> ReadQuery<T>(string query,
            bool storedProcedure = false, bool isReader = false, IEnumerable<T> paramss = null)
        {
            DataTable dataTable;
            using (SqlConnection con = new SqlConnection(_con))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        if (storedProcedure)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            if (paramss != null)
                            {
                                foreach (var param in paramss)
                                {
                                    foreach (var item in this.columnsMaper)
                                    {
                                        var nombre = item.Nombre;
                                        var valor = param.GetType().GetProperty(nombre).GetValue(param, null);

                                        if (valor != null)
                                        {
                                            cmd.Parameters.Add("@" + nombre.ToLower(), item.SqlDbTipo).Value = valor;
                                        }
                                    }
                                }
                            }
                        }

                        await con.OpenAsync();
                        dataTable = new DataTable();
                        if (isReader)
                        {
                            using (var reader = await cmd.ExecuteReaderAsync())
                            {
                                //var dataTablea = GetObjeto<T>(entitys, _nameTable);
                                dataTable.Load(reader);
                                reader.Close();
                                cmd.Dispose();
                            }
                        }
                        else { await cmd.ExecuteNonQueryAsync(); }
                    }
                    catch (Exception ex) { dataTable = null; }
                    finally { con.Close(); }

                    return dataTable;
                }
            }
        }


        public class ColumnMaper
        {
            public string Nombre { get; set; }
            public DbType DbTipo { get; set; }
            public SqlDbType SqlDbTipo { get; set; }
        }
    }
}
