using System.Collections.Generic;

namespace Gestor.MVC.Models
{

    public class Worker
    {
        // By default, the Entity Framework interprets a property that's named ID or classnameID as the primary key.
        public int ID { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Office { get; set; }

        public string Extn { get; set; }

        public string Salary { get; set; }

    }

    public class MenuModel
    {
        public int OpcionId { get; set; }
        public string Nombre { get; set; }
        public int PadreId { get; set; }
        public int NroOrden { get; set; }
        public string OpcionURL { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public bool Selected { get; set; }
        public bool Folder { get; set; }
        public bool Expanded { get; set; }
        public string DesControlador { get; set; }
        public string DesAccion { get; set; }
        public string DesArea { get; set; }
        public string AccesoDirecto { get; set; }
        public string ClassItem { get; set; }
        private List<MenuModel> listItems = new List<MenuModel>();

        public List<MenuModel> ListItems
        {
            get { return listItems; }
            set { listItems = value; }
        }
    }
}