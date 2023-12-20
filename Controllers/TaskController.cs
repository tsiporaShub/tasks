using Microsoft.AspNetCore.Mvc;
using tasks.Models;
using tasks.Services;

namespace tasks.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    // private static readonly string[] Summaries = new[]
    // {
    //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    // };

    // private readonly ILogger<WeatherForecastController> _logger;

    // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    // {
    //     _logger = logger;
    // }
 [HttpGet]
    public ActionResult<List<Task1>> Get()
    {
        return TasksService.GetAll();
    }

    [HttpGet("{id}")]
    public ActionResult<Task1> Get(int id)
    {
        var task = TasksService.GetById(id);
        if (task == null)
            return NotFound();
        return task;
    }

    [HttpPost]
    public ActionResult Post(Task1 newTask1)
    {
        var newId = TasksService.Add(newTask1);

        return CreatedAtAction("Post", 
            new {id = newId}, TasksService.GetById(newId));
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id,Task1 newTask)
    {
        var result = TasksService.Update(id, newTask);
        if (!result)
        {
            return BadRequest();
        }
        return NoContent();
    }
}
