using ABCCProgram.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCCProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartamentoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Departamento>>> Get()
        {
            return await context.Departamentos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Departamento>> DepGet(int id)
        {
            return await context.Departamentos.FirstOrDefaultAsync(dep => dep.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> DepPost(Departamento departamento)
        {
            context.Add(departamento);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
