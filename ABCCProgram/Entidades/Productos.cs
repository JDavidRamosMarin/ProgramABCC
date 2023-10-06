using System.ComponentModel.DataAnnotations;

namespace ABCCProgram.Entidades
{
    public class Productos
    {
        public int id { get; set; }
        public int Sku { get; set; }
        public string NombreArticulo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Departamento { get; set; }
        public int Clase { get; set; }
        public int Familia { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }
        public int Descontinuado { get; set; }
        public DateTime FechaDeBaja { get; set; }
    }
}
