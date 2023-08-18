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
    public class SedesRepository : DbProvider, ISedesRepository
    {
        SedesHelper helper = new SedesHelper();
        public SedesRepository(string strConn) : base(strConn)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<SedesDTO>> GetSedes()
        {
            string query = string.Format(helper.SqlGetSedes);

            var data = await base.ReadQuery<SedesDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new SedesDTO()
                    {
                        IdSede = Convert.ToInt32(rw["IdSede"]),
                        SedeDes = Convert.ToString(rw["SedeDes"]),
                        IdEstado = Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"])
                    }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<SedesDTO>> UpdateSede(SedesDTO obj)
        {
            string query = string.Format(helper.SqlUpdateSedes, obj.IdSede, obj.SedeDes, obj.IdEstado);

            var data = await base.ReadQuery<SedesDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new SedesDTO()
                    {
                        IdSede = Convert.ToInt32(rw["IdSede"]),
                        SedeDes = Convert.ToString(rw["SedeDes"]),
                        IdEstado = Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"])
                    }).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<SedesDTO>> DeleteSede(int id)
        {
            string query = string.Format(helper.SqlDeleteSedes, id);

            var data = await base.ReadQuery<SedesDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new SedesDTO()
                    {
                        IdSede = Convert.ToInt32(rw["IdSede"]),
                        SedeDes = Convert.ToString(rw["SedeDes"]),
                        IdEstado = Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"])
                    }).ToList();
        }
    }
}
