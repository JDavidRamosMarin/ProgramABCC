using System.ComponentModel.DataAnnotations;

namespace ABCCProgram.DTOs
{
    public class ProductosActualizacionDTO
    {
        //public int id { get; set; }
        //[Required(ErrorMessage = "El campo {0} es requerido")] // El dato es requerido
        //[ValidacionSKU]
        //public int Sku { get; set; }

        [StringLength(maximumLength: 15)]
        public string NombreArticulo { get; set; }

        [StringLength(maximumLength: 15)]
        public string Marca { get; set; }

        [StringLength(maximumLength: 20)]
        public string Modelo { get; set; }

        [Range(1, 9, ErrorMessage = "Ingresa un valor valido para departamento.")]
        public int DepartamentoId { get; set; }
        //public Departamento DepartamentoTab { get; set; }

        [Range(1, 99, ErrorMessage = "Ingresa un valor valido para clase.")]
        public int ClaseId { get; set; }
        //public Clase ClaseTab { get; set; }

        [Range(1, 999, ErrorMessage = "Ingresa un valor valido para familia.")]
        public int FamiliaId { get; set; }
        //public Familia FamiliaTab { get; set; }
        public DateTime FechaDeAlta { get; set; }

        [Range(0, 999999999, ErrorMessage = "Ingresa un valor valido para stock.")]
        public int Stock { get; set; }

        [Range(0, 999999999, ErrorMessage = "Ingresa un valor valido para cantidad.")]
        public int Cantidad { get; set; }

        [Range(0, 1, ErrorMessage = "Ingresa un valor valido para descontinuado entre 0 y 1.")]
        public int Descontinuado { get; set; }
        public DateTime FechaDeBaja { get; set; }
    }
}
