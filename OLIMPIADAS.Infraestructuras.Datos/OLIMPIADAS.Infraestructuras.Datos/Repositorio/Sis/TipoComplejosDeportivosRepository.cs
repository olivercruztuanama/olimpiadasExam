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
    public class TipoComplejosDeportivosRepository : DbProvider, ITipoComplejosDeportivosRepository
    {
        TipoComplejosDeportivosHelper helper = new TipoComplejosDeportivosHelper();

        public TipoComplejosDeportivosRepository(string strConn) : base(strConn)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<TipoComplejosDeportivosDTO>> GetTipoComplejosDeportivos()
        {
            string query = string.Format(helper.SqlGetListaTipoComplejosDeportivos);

            var data = await base.ReadQuery<TipoComplejosDeportivosDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new TipoComplejosDeportivosDTO()
                    {
                        IdTipoComplejoDeportivo = Convert.ToInt32(rw["IdTipoComplejoDeportivo"]),
                        TipoComplejoDeportivoDes = Convert.ToString(rw["TipoComplejoDeportivoDes"]),
                        IdEstado = DBNull.Value.Equals(rw["IdEstado"]) ? 0 : Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"])
                    }).ToList();
        }
    }
}
