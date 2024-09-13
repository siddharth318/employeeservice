using EmployeeService.DTOS;
using EmployeeService.Helper;
using EmployeeService.Models;
using EmployeeService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeService.Controllers
{
    [EnableCors("myPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        ILogger _logger;
        IEmployeeService Employee_Service;
        //EmployeeService.Services.EmployeeService Employee_Service;
        

        //performing logger action ILogger<EmployeeController> Log(it is the instance of logger) 
        /*public EmployeeController(EmployeeService.Services.EmployeeService employee_Service, ILogger<EmployeeController> log)
         {
             Employee_Service= employee_Service;
             //added for logger
             _logger = log;
         }
        */
      

        // public EmployeeController(EmployeeService.Services.EmployeeService employee_Service)
         public EmployeeController(IEmployeeService employee_Service1)
         {
             Employee_Service = employee_Service1;
             //added for logger
             //_logger = log;
         }


        // GET: api/<EmployeeController>
        [HttpGet]
        //[Authorize]
        public Task<List<Employee>> Get()
        {
            return Employee_Service.GetAllEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        //[Authorize]
        public Employee Get(int id)
        {
            //checking logger
            //_logger.LogInformation("Get information :" + DateTime.Now.ToString() + Request.Host.Value);
            return Employee_Service.GetEmployeeById(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post([FromBody] Employee e)
        {
           return new OkObjectResult(Employee_Service.AddEmployee(e));
            

        }


        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
       // [Authorize]
        public void Put(int id, [FromBody] Employee e)
        {
            Employee_Service.UpdateEmployee(id, e);
            //Employee_Service.DeleteEmployee(id);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public void Delete(int id)
        {
            Employee_Service.DeleteEmployee(id);
        }



        //token, authorization

        [HttpPost]
        [Route("Validate")] /// attribute based routing
        public ActionResult<TokenResult> Validate([FromBody] EmployeeLoginDTO c)
        {
            if (Employee_Service.ValidateUser(c))
                return new OkObjectResult(new TokenResult()
                {
                    Status = "true",
                    Token = new TokenHelper().GenerateToken(c)
                });
            return new NotFoundObjectResult(new TokenResult()
            {
                Status = "false",
                Token = null
            });
        }


    }
}
