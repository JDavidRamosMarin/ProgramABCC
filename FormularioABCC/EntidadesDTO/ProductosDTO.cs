using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularioABCC.EntidadesDTO
{
    public class ProductosDTO
    {
        public int Sku { get; set; }
        public string NombreArticulo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int DepartamentoId { get; set; }
        public int ClaseId { get; set; }
        public int FamiliaId { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }
        public int Descontinuado { get; set; }
        public DateTime FechaDeBaja
        {
            get; set;
        }
    }
}
