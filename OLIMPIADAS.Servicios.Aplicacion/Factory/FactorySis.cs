using OLIMPIADAS.Dominio.Interfaces.General;
using OLIMPIADAS.Dominio.Interfaces.Sis;
using OLIMPIADAS.Infraestructuras.Datos.Repositorio.General;
using OLIMPIADAS.Infraestructuras.Datos.Repositorio.Sis;

namespace OLIMPIADAS.Servicios.Aplicacion.Factory
{
    public class FactorySis
    {
        public static string StrConexion = "ContextoSIS";

        /// <summary>
        /// Interfaz para Login  
        /// </summary>
        /// <returns></returns>
        public static IGeneralRepository GetGeneralRepository()
        {
            return new GeneralRepository(StrConexion);
        }

        /// <summary>
        /// Interfaz para Tabla Sede 
        /// </summary>
        /// <returns></returns>
        public static ISedesRepository GetSedesRepository()
        {
            return new SedesRepository(StrConexion);
        }

        /// <summary>
        /// Interfaz para Tabla Estados 
        /// </summary>
        /// <returns></returns>
        public static IEstadosRepository GetEstadosRepository()
        {
            return new EstadosRepository(StrConexion);
        }

        /// <summary>
        /// Interfaz para Tabla Equipamientos 
        /// </summary>
        /// <returns></returns>
        public static IEquipamientosRepository GetEquipamientosRepository()
        {
            return new EquipamientosRepository(StrConexion);
        }

        /// <summary>
        /// Interfaz para Tabla Complejo Deportivos 
        /// </summary>
        /// <returns></returns>
        public static IComplejoDeportivoRepository GetComplejoDeportivoRepository()
        {
            return new ComplejoDeportivoRepository(StrConexion);
        }

        /// <summary>
        /// Interfaz para Tabla Tipo complejos deportivos 
        /// </summary>
        /// <returns></returns>
        public static ITipoComplejosDeportivosRepository GetTipoComplejosDeportivosRepository()
        {
            return new TipoComplejosDeportivosRepository(StrConexion);
        }
    }
}
