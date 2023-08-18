using OLIMPIADAS.Dominio.DTO.Sedes;
using OLIMPIADAS.Servicios.Aplicacion.Factory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OLIMPIADAS.Servicios.Aplicacion.Intranet
{
    public class OlimpiadasServicios
    {
        #region Tabla Sedes

        /// <summary>
        /// Devuelve la lista de sedes
        /// </summary>
        /// <returns></returns>
        public async Task<List<SedesDTO>> GetSedes()
        {
            return await FactorySis.GetSedesRepository().GetSedes();
        }

        /// <summary>
        /// Actualiza o agregar una sede
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<SedesDTO>> UpdateSede(SedesDTO obj)
        {
            return await FactorySis.GetSedesRepository().UpdateSede(obj);
        }

        /// <summary>
        /// Elimina una sede
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<SedesDTO>> DeleteSede(int id)
        {
            return await FactorySis.GetSedesRepository().DeleteSede(id);
        }

        #endregion

        #region Tabla Equipamientos

        /// <summary>
        /// Devuelve la lista de equipamientos
        /// </summary>
        /// <returns></returns>
        public async Task<List<EquipamientosDTO>> GetEquipamientos()
        {
            return await FactorySis.GetEquipamientosRepository().GetEquipamientos();
        }

        #endregion

        #region Tabla Estados

        /// <summary>
        /// Devuelve la lista de estados
        /// </summary>
        /// <returns></returns>
        public async Task<List<EstadosDTO>> GetEstados()
        {
            return await FactorySis.GetEstadosRepository().GetEstados();
        }

        #endregion

        #region Tabla Complejo Deportivo

        /// <summary>
        /// Devuelve la lista de complejos deportivos
        /// </summary>
        /// <returns></returns>
        public async Task<List<ComplejoDeportivoAdiDTO>> GetListaComplejos()
        {
            return await FactorySis.GetComplejoDeportivoRepository().GetComplejoDeportivo();
        }

        /// <summary>
        /// Actualiza o agrega un complejo deportivo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public async Task<List<ComplejoDeportivoAdiDTO>> SaveComplejoDeportivo(ComplejoDeportivoDTO obj)
        {
            return await FactorySis.GetComplejoDeportivoRepository().SaveComplejoDeportivo(obj);
        }

        /// <summary>
        /// Eliminar un complejo deportivo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<ComplejoDeportivoAdiDTO>> DeleteComplejoDeportivo(int id)
        {
            return await FactorySis.GetComplejoDeportivoRepository().DeleteComplejoDeportivo(id);
        }

        #endregion

        #region Tabla Tipo Complejos Deportivos

        /// <summary>
        /// Devuelve la lista de tipo de complejos deportivos
        /// </summary>
        /// <returns></returns>
        public async Task<List<TipoComplejosDeportivosDTO>> GetTipoComplejosDeportivos()
        {
            return await FactorySis.GetTipoComplejosDeportivosRepository().GetTipoComplejosDeportivos();
        }

        #endregion
    }
}
