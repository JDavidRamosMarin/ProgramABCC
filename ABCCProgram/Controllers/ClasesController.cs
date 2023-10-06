using ABCCProgram.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCCProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClasesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Clase>>> Get()
        {
            return await context.Clases.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Clase>> DepGet(int id)
        {
            return await context.Clases.FirstOrDefaultAsync(dep => dep.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> DepPost(Clase clase)
        {
            context.Add(clase);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
