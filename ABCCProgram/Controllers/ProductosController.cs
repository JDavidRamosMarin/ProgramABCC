using ABCCProgram.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ABCCProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ProductosController(ApplicationDbContext context) /*, IMapper mapper)*/
        {
            this.context = context;
            //this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProd(Productos productos)
        {
            
            var exist = await context.Productos.AnyAsync(prod => prod.Sku == productos.Sku);
            var existNom = await context.Productos.AnyAsync(prod => prod.NombreArticulo == productos.NombreArticulo);

            if (exist && existNom)
            {
                return BadRequest();
            }
            else if (exist || existNom)
            {
                return BadRequest();
            }

            context.Add(new Productos() 
            {
                Sku = productos.Sku,
                NombreArticulo = productos.NombreArticulo,
                Marca = productos.Marca,
                Modelo = productos.Modelo,
                Departamento = productos.Departamento,
                Clase = productos.Clase,
                Familia = productos.Familia,
                FechaDeAlta = productos.FechaDeAlta,
                Stock = productos.Stock,
                Cantidad = productos.Cantidad,
                Descontinuado = 0,
                FechaDeBaja = new DateTime(1900, 01, 01)
            });
            await context.SaveChangesAsync();
            return Ok();

            //if (exist && existNom )
            //{
            //    return BadRequest();
            //} else if (exist || existNom)
            //{
            //    return BadRequest();
            //}

            //context.Add(productos);
            //await context.SaveChangesAsync();
            //return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Productos>>> Get()
        {
            return await context.Productos.ToListAsync();
        }

        [HttpGet("{sku:int}")]
        public async Task<ActionResult<Productos>> GetBySKU(int sku)
        {
            if (sku == 0)
            {
                return BadRequest();
            }

            var prod = await context.Productos.FirstOrDefaultAsync(prodDB => prodDB.Sku == sku);

            // Verifica que exita el Sku dentro de la base de datos
            if (prod == null)
            {
                return NotFound();
            }

            return Ok(prod);
        }
    
        [HttpPut("{sku:int}")]
        public async Task<ActionResult> PutProd(Productos producto, int sku)
        {
            if (producto.Sku != sku)
            {
                return BadRequest();
            }

            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }

        // https://es.stackoverflow.com/questions/354425/borrar-registro-ignorando-id-identity-ef-c
        [HttpDelete("{sku:int}")]
        public async Task<ActionResult> DelProd(int sku)
        {
            var existprod = await context.Productos.AnyAsync(prodDB => prodDB.Sku == sku);

            if (!existprod)
            {
                return NotFound();
            }

            // Busca los Datos del producto

            var prod = await context.Productos.Where(x => x.Sku == sku).FirstOrDefaultAsync();

            context.Productos.Remove(prod);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
