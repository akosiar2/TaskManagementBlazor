using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApplication.Interface;

namespace TaskWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService) { _taskService = taskService; }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Domain.Task>>> GetAll([FromQuery] int? status, [FromQuery] int? priority, [FromQuery] int? page = 1, [FromQuery] int? pageSize = 5)
        {
            return Ok(await _taskService.GetTasks(status, priority));
        }

        // GET: api/tasks/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Domain.Task>> GetById(int id)
        {
            var todo = await _taskService.GetTask(id);
            return todo is null ? NotFound() : todo;
        }

        // POST: api/tasks
        [HttpPost]
        public async Task<ActionResult<Domain.Task>> Create(Domain.Task todo)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _taskService.InsertTask(todo);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT: api/tasks/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Domain.Task input)
        {
            if (id != input.Id) return BadRequest("Id mismatch");
            
            await _taskService.UpdateTask(input);
            return NoContent();
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _taskService.TaskExistAsync(id);
            if (todo is false) return NotFound();

            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}
