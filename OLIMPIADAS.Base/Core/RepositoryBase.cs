/*****************************************************************************************
* Fecha de Creación: 29-11-2017
* Creado por: TRASCEND
* Descripción: Clase padre de las clases repositorio
*****************************************************************************************/

using OLIMPIADAS.Base.DataHelper;

namespace OLIMPIADAS.Base.Core
{
    public abstract class RepositoryBase
    {
        public DbProvider dbProvider;

        public RepositoryBase(string strConn)
        {
            dbProvider = new DbProvider(strConn);
        }

        public RepositoryBase()
        {

        }

    }
}
