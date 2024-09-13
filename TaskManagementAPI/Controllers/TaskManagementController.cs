
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace TaskManagementAPI.Controllers
{
    [EnableCors("myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : Controller
    {



        ILogger _logger;
        TaskManagementServices _service;
        public TaskManagementController(TaskManagementServices service,
            ILogger<TaskManagementController> log)
        {
            _service = service;
            _logger = log;
        }

        TaskManagementServices tra = new TaskManagementServices();
        // GET: api/<RestaurantController>
        [HttpGet]
        public Task<List<TaskManagement>> Get()
        {
            _logger.LogInformation("Get information :" + DateTime.Now.ToString() + Request.Host.Value);
            return tra.GetAllTaskManagement();
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public TaskManagement Get(int id)
        {
            return tra.GetById(id);
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public void Post([FromBody] TaskManagement r)
        {
            tra.AddTaskManagement(r);
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TaskManagement r)
        {
            tra.UpdateTaskManagement(id, r);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            tra.DeleteTaskManagement(id);
        }


    }

}

   
