using ABCCProgram.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCCProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public FamiliaController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Familia>>> Get()
        {
            return await context.Familias.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Familia>> DepGet(int id)
        {
            return await context.Familias.FirstOrDefaultAsync(dep => dep.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> DepPost(Familia familia)
        {
            context.Add(familia);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
