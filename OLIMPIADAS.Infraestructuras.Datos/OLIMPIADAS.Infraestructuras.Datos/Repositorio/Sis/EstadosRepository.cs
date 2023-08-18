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
    public class EstadosRepository : DbProvider, IEstadosRepository
    {
        EstadosHelper helper = new EstadosHelper();
        public EstadosRepository(string strConn) : base(strConn)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<EstadosDTO>> GetEstados()
        {
            string query = string.Format(helper.SqlGetEstados);

            var data = await base.ReadQuery<EstadosDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new EstadosDTO()
                    {
                        IdEstado = Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"])
                    }).ToList();
        }
    }
}