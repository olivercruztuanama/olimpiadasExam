/*****************************************************************************************
* Fecha de Creación: 29-11-2017
* Creado por: TRASCEND
* Descripción: Clase padre de las entidades de la aplicación
*****************************************************************************************/

using System;
using System.IO;
using System.Xml.Serialization;

namespace OLIMPIADAS.Base.Core
{
    /// <summary>
    /// </summary>
    [Serializable]
    public abstract class EntityBase
    {
        public String SerializarParaXml()
        {
            XmlSerializer xmlSerializer = null;
            StringWriter sw = null;
            try
            {
                sw = new StringWriter();
                xmlSerializer = new XmlSerializer(this.GetType());
                xmlSerializer.Serialize(sw, this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
            }
            return sw.ToString();
        }

        public String RetornaNombreTablaXMLRoot()
        {
            String name = "";
            XmlAttributes tempAttrs = null;
            try
            {
                tempAttrs = new XmlAttributes(this.GetType());
                name = tempAttrs.XmlRoot.ElementName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return name.ToString();
        }
    }
}
