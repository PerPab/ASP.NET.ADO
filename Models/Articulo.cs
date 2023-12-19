using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace ADO.MVC.Models
{
    public class Articulo
    {

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
