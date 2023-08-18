using OLIMPIADAS.Dominio.DTO.Login;
using OLIMPIADAS.Dominio.DTO.Sedes;
using System;
using System.Collections.Generic;

namespace Gestor.MVC.Models
{
    public class Objetos
    {
        public int Count { get; set; }
        public string Htmlview { get; set; }
        public List<string> ListaHtmlview { get; set; }

        public Exception Excepcion { get; set; }
        public int Pageview { get; set; }
        public Boolean isPDfCas { get; set; }
        public string FechaPadre { get; set; }
        public List<UsuariosDTO> AllUsuarios { get; set; }
        public List<string> ClientesString { get; set; }
        public decimal Ingresos { get; set; }
        public decimal Egresos { get; set; }
        public decimal Capital { get; set; }
        public decimal Cartera { get; set; }
        public decimal Total { get; set; }
        public string Logo { get; set; }
        public string TypeUser { get; set; }
        public List<EstadosDTO> ListaEstados { get; set; }
        public List<SedesDTO> ListaSedes { get; set; }
        public List<TipoComplejosDeportivosDTO> ListaTipoComplejosDeportivos { get; set; }
    }
}