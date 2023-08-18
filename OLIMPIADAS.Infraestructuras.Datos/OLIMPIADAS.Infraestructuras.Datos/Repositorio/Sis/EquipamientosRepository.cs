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
    public class EquipamientosRepository : DbProvider, IEquipamientosRepository
    {
        EquipamientosHelper helper = new EquipamientosHelper();
        public EquipamientosRepository(string strConn) : base(strConn)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<EquipamientosDTO>> GetEquipamientos()
        {
            string query = string.Format(helper.SqlGetEquipamientos);

            var data = await base.ReadQuery<EquipamientosDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new EquipamientosDTO()
                    {
                        IdEquipamiento = Convert.ToInt32(rw["IdEquipamiento"]),
                        EquipamientoDes = Convert.ToString(rw["EquipamientoDes"]),
                        IdEstado = DBNull.Value.Equals(rw["IdEstado"]) ? 0 : Convert.ToInt32(rw["IdEstado"]),
                        EstadoDes = Convert.ToString(rw["EstadoDes"])
                    }).ToList();
        }
    }
}
