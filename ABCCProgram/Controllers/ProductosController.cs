using ABCCProgram.DTOs;
using ABCCProgram.Entidades;
using ABCCProgram.Validaciones;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace ABCCProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ProductosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("CrearProducto")]
        public async Task<ActionResult> CreateProd(ProductosCreacionDTO productosCreacionDTO)
        {          
            var exist = await context.Productos
                .AnyAsync(prod => prod.Sku == productosCreacionDTO.Sku);
            var existNom = await context.Productos
                .AnyAsync(prod => prod.NombreArticulo == productosCreacionDTO.NombreArticulo);

            if (exist && existNom)
            {
                return BadRequest();
            }
            else if (exist || existNom)
            {
                return BadRequest();
            }

            if (productosCreacionDTO.Cantidad > productosCreacionDTO.Stock)
            {
                return BadRequest("La cantidad no puede exceder el stock en la tienda.");
            }

            var prodCDTO = new Productos()
            {
                Sku = productosCreacionDTO.Sku,
                NombreArticulo = productosCreacionDTO.NombreArticulo,
                Marca = productosCreacionDTO.Marca,
                Modelo = productosCreacionDTO.Modelo,
                DepartamentoId = productosCreacionDTO.DepartamentoId,
                ClaseId = productosCreacionDTO.ClaseId,
                FamiliaId = productosCreacionDTO.FamiliaId,
                FechaDeAlta = productosCreacionDTO.FechaDeAlta,
                Stock = productosCreacionDTO.Stock,
                Cantidad = productosCreacionDTO.Cantidad,
                Descontinuado = 0,
                FechaDeBaja = new DateTime(1900, 01, 01)
            };

            //if (prodCDTO.Stock > prodCDTO.Cantidad)
            //{
            //    return BadRequest("No hay suficiente stock.");
            //}

            context.Add(prodCDTO);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductosDTO>>> Get()
        {
            var prod = await context.Productos
                .Include(prodDB => prodDB.DepartamentoTab)
                .Include(prodDB => prodDB.ClaseTab)
                .Include(prodDB => prodDB.FamiliaTab)
                .ToListAsync();
            return mapper.Map<List<ProductosDTO>>(prod);
        }

        [HttpGet("{sku:int}")]
        public async Task<ActionResult<ProductosDTO>> GetBySKU(int sku)
        {
            if (sku == 0)
            {
                return BadRequest();
            }

            var prod = await context.Productos
                .Include(prodDB => prodDB.DepartamentoTab)
                .Include(prodDB => prodDB.ClaseTab)
                .Include(prodDB => prodDB.FamiliaTab)
                .FirstOrDefaultAsync(prodDB => prodDB.Sku == sku);

            // Verifica que exita el Sku dentro de la base de datos
            if (prod == null)
            {
                return NotFound();
            }

            var dto = mapper.Map<ProductosDTO>(prod);
            return dto;
        }

        [HttpPut("{sku:int}")]
        public async Task<ActionResult> PutProd(ProductosActualizacionDTO productosActualizacionDTO, int sku)
        {
            var existprod = await context.Productos.AnyAsync(prodDB => prodDB.Sku == sku);

            if (!existprod)
            {
                return NotFound("No existe este articulo.");
            }

            var prodDB = await context.Productos.FirstOrDefaultAsync(x => x.Sku == sku);

            prodDB = mapper.Map(productosActualizacionDTO, prodDB);
            
            if (prodDB.Cantidad > prodDB.Stock )
            {
                return BadRequest("No hay suficiente Stock.");
            }

            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{sku:int}")]
        public async Task<ActionResult> DelProd(int sku)
        {
            var existprod = await context.Productos.AnyAsync(prodDB => prodDB.Sku == sku);

            if (!existprod)
            {
                return NotFound();
            }

            var prod = await context.Productos.Where(x => x.Sku == sku).FirstOrDefaultAsync();

            context.Productos.Remove(prod);
            await context.SaveChangesAsync();
            return Ok();
        }


       
    }
}
