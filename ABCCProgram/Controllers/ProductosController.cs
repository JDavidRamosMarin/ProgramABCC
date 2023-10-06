using ABCCProgram.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            context.Add(productos);
            await context.SaveChangesAsync();
            return Ok();
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

        [HttpDelete("{sku:int}")]
        public async Task<ActionResult> DelProd(Productos producto, int sku)
        {
            var existprod = await context.Productos.AnyAsync(prodDB => prodDB.Sku == sku);

            if (!existprod)
            {
                return NotFound();
            }

            context.Remove(new Productos() { Sku = sku });
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
