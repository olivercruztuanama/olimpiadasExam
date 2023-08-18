using OLIMPIADAS.Base.DataHelper;
using OLIMPIADAS.Dominio.DTO.Sedes;
using OLIMPIADAS.Dominio.Interfaces.Sis;
using OLIMPIADAS.Infraestructuras.Datos.Helper.Sis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OLIMPIADAS.Infraestructuras.Datos.Repositorio.Sis
{
    public class ComplejoDeportivoRepository : DbProvider, IComplejoDeportivoRepository
    {
        ComplejoDeportivoHelper helper = new ComplejoDeportivoHelper();
        public ComplejoDeportivoRepository(string strConn) : base(strConn)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<ComplejoDeportivoAdiDTO>> GetComplejoDeportivo()
        {
            string query = string.Format(helper.SqlGetListaComplejoDeportivo);

            var data = await base.ReadQuery<ComplejoDeportivoAdiDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new ComplejoDeportivoAdiDTO()
                    {
                        IdComplejoDeportivo = Convert.ToInt32(rw["IdComplejoDeportivo"]),
                        ComplejoDeportivoDes = Convert.ToString(rw["ComplejoDeportivoDes"]),
                        IdSede = Convert.ToInt32(rw["IdSede"]),
                        IdTipoComplejoDeportivo = Convert.ToInt32(rw["IdTipoComplejoDeportivo"]),
                        IdEstado = DBNull.Value.Equals(rw["IdEstado"]) ? 0 : Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"]),
                        SedeDes = Convert.ToString(rw["SedeDes"]),
                        TipoComplejoDeportivoDes = Convert.ToString(rw["TipoComplejoDeportivoDes"])
                    }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<ComplejoDeportivoAdiDTO>> SaveComplejoDeportivo(ComplejoDeportivoDTO obj)
        {
            string query = string.Format(helper.SqlSaveComplejoDeportivo,
                obj.IdComplejoDeportivo, obj.ComplejoDeportivoDes, obj.IdSede, obj.IdTipoComplejoDeportivo, obj.IdEstado);

            var data = await base.ReadQuery<ComplejoDeportivoAdiDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new ComplejoDeportivoAdiDTO()
                    {
                        IdComplejoDeportivo = Convert.ToInt32(rw["IdComplejoDeportivo"]),
                        ComplejoDeportivoDes = Convert.ToString(rw["ComplejoDeportivoDes"]),
                        IdSede = Convert.ToInt32(rw["IdSede"]),
                        IdTipoComplejoDeportivo = Convert.ToInt32(rw["IdTipoComplejoDeportivo"]),
                        IdEstado = DBNull.Value.Equals(rw["IdEstado"]) ? 0 : Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"]),
                        SedeDes = Convert.ToString(rw["SedeDes"]),
                        TipoComplejoDeportivoDes = Convert.ToString(rw["TipoComplejoDeportivoDes"])
                    }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<ComplejoDeportivoAdiDTO>> DeleteComplejoDeportivo(int id)
        {
            string query = string.Format(helper.SqlDeleteComplejoDeportivo, id);

            var data = await base.ReadQuery<ComplejoDeportivoAdiDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new ComplejoDeportivoAdiDTO()
                    {
                        IdComplejoDeportivo = Convert.ToInt32(rw["IdComplejoDeportivo"]),
                        ComplejoDeportivoDes = Convert.ToString(rw["ComplejoDeportivoDes"]),
                        IdSede = Convert.ToInt32(rw["IdSede"]),
                        IdTipoComplejoDeportivo = Convert.ToInt32(rw["IdTipoComplejoDeportivo"]),
                        IdEstado = DBNull.Value.Equals(rw["IdEstado"]) ? 0 : Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"]),
                        SedeDes = Convert.ToString(rw["SedeDes"]),
                        TipoComplejoDeportivoDes = Convert.ToString(rw["TipoComplejoDeportivoDes"])
                    }).ToList();
        }
    }
}
