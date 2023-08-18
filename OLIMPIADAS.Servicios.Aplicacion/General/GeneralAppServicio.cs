using OLIMPIADAS.Dominio.DTO.Login;
using OLIMPIADAS.Servicios.Aplicacion.Factory;
using System.Threading.Tasks;

namespace OLIMPIADAS.Servicios.Aplicacion.General
{
    public class GeneralAppServicio
    {
        /// <summary>
        /// Valida y devuelve datos de usuario logueado
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<UsuariosDTO> AutentificarUsuarioAD(string usuario, string password)
        {
            #region Encrytacion
            string encrip_clave = password;
            string passPhrase = string.Empty, saltValue = string.Empty, hashAlgorithm = string.Empty, initVector = string.Empty;
            int passwordIterations = 0, keySize = 0;
            GetValoresDefault(ref passPhrase, ref saltValue, ref hashAlgorithm, ref passwordIterations, ref initVector, ref keySize);
            var RijndaelSimple = new RijndaelSimple();
            var passDecryptUsrFile = RijndaelSimple.Encrypt(encrip_clave, passPhrase, saltValue, hashAlgorithm, passwordIterations, initVector, keySize);
            passDecryptUsrFile = passDecryptUsrFile.Replace("/", "|").Replace("+", "*");
            #endregion

            var result = await FactorySis.GetGeneralRepository().AutentificarUsuario(usuario.ToUpper(), passDecryptUsrFile);

            return result;
        }

        /// <summary>
        /// Load de parametros para encriptacion de contraseña
        /// </summary>
        /// <param name="passPhrase"></param>
        /// <param name="saltValue"></param>
        /// <param name="hashAlgorithm"></param>
        /// <param name="passwordIterations"></param>
        /// <param name="initVector"></param>
        /// <param name="keySize"></param>
        public void GetValoresDefault(ref string passPhrase, ref string saltValue, ref string hashAlgorithm, ref int passwordIterations, ref string initVector, ref int keySize)
        {
            passPhrase = "MySqlCSharpSystem";
            saltValue = "AccountingSoftware";
            hashAlgorithm = "SHA1";
            passwordIterations = 2;
            initVector = "@1B2c3D4e5F6g7H8";
            keySize = 256;
        }
    }
}
