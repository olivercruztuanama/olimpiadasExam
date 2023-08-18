using OLIMPIADAS.Base.DataHelper;
using OLIMPIADAS.Dominio.DTO.Login;
using OLIMPIADAS.Dominio.Interfaces.General;
using OLIMPIADAS.Infraestructuras.Datos.Helper.Sis;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OLIMPIADAS.Infraestructuras.Datos.Repositorio.General
{
    public class GeneralRepository : DbProvider, IGeneralRepository
    {
        LoginHelper helper = new LoginHelper();
        public GeneralRepository(string strConn) : base(strConn)
        {
        }
        public async Task<UsuariosDTO> AutentificarUsuario(string usuario, string password)
        {
            string query = string.Format(helper.SqlGetLogin, usuario);

            var data = await base.ReadQuery<UsuariosDTO>(query, isReader: true);

            return (from rw in data.AsEnumerable()
                    select new UsuariosDTO()
                    {
                        Usuario = Convert.ToString(rw["Usuario"]),
                        Contrasenia = Convert.ToString(rw["Contrasenia"]),
                        IdEstado = Convert.ToInt32(rw["IdEstado"]),
                    }).First();
        }
    }
}
