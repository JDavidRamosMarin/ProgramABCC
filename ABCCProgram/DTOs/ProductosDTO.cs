using ABCCProgram.Entidades;
using ABCCProgram.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace ABCCProgram.DTOs
{
    public class ProductosDTO
    {
        //public int id { get; set; }
        [ValidacionSKU]
        public int Sku { get; set; }

        public string NombreArticulo { get; set; }
    
        public string Marca { get; set; }
        
        public string Modelo { get; set; }
        
        //public int DepartamentoId { get; set; }
        public Departamento DepartamentoTab { get; set; }
        
        //public int ClaseId { get; set; }
        public Clase ClaseTab { get; set; }
        
        //public int FamiliaId { get; set; }
        public Familia FamiliaTab { get; set; }
        public DateTime FechaDeAlta { get; set; }

        public int Stock { get; set; }

        public int Cantidad { get; set; }

        public int Descontinuado { get; set; }
        public DateTime FechaDeBaja { get; set; } = new DateTime(1900, 01, 01);
    }
}
