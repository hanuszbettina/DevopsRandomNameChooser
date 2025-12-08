using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using randomNameGenerator.Data;
using randomNameGenerator.Models;

namespace randomNameGenerator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameController : ControllerBase
    {
        NameDbContext ctx;
        public NameController(NameDbContext ctx)
        {
            this.ctx = ctx;
        }

        [HttpPost]
        public async Task<IActionResult> AddTodo([FromBody] NameCreateDto dto)
        {
            try
            {
                var newName = new Name()
                {
                    Text = dto.Text
                };
                await this.ctx.Names.AddAsync(newName);
                await this.ctx.SaveChangesAsync();
                return Ok(newName);
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            try
            {
                var todoToDelete = await this.ctx.Names.FirstAsync(t => t.Id == id);
                this.ctx.Names.Remove(todoToDelete);
                await this.ctx.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new Error(ex.Message));
            }
        }

        [HttpGet]
        public async Task<List<NameViewDto>> GetTodos()
        {
            return await ctx.Names.AsNoTracking().Select(z => new NameViewDto()
            {
                Id = z.Id,
                CreatedAt = z.CreatedAt,
                Text = z.Text
            }).ToListAsync();
        }
    }
}
