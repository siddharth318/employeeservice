using EmployeeService.DTOS;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {

        //EmployeeContext context = new EmployeeContext();
        private readonly EmployeeContext _employeeContext;
        public bool AddEmployee(Employee e)
        {
            _employeeContext.employeess.Add(e);
            _employeeContext.SaveChanges();
            return true;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            List<Employee> result = null;
            result = await _employeeContext.employeess.ToListAsync();
            return result;
        }
        public Employee GetEmployeeById(int id)
        {
            return _employeeContext.employeess.Where(e => e.Id == id).FirstOrDefault();
        }
        public bool UpdateEmployee(int id, Employee e)
        {
            //var result = context.Database.ExecuteSqlRaw($"update employeess set Name={e.Name}, Designation={e.Designation}, Email={e.Email}, Phone={e.Phone}, Password={e.Password} where id={e.Id}");
            var result = _employeeContext.employeess.FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                result.Id = id;
                result.Name = e.Name;
                result.Email = e.Email;
                result.Phone = e.Phone;
                result.Designation = e.Designation;
                result.Password = e.Password;
            }
            _employeeContext.SaveChanges();
            return true;
        }
        public bool DeleteEmployee(int id)
        {
            //var result = context.Database.ExecuteSqlRaw($"delete from employees ")
            var result = _employeeContext.employeess.Where(e => e.Id == id).FirstOrDefault();
            _employeeContext.employeess.Remove(result);
            _employeeContext.SaveChanges();
            return true;
        }

        //authentication part starts

        public EmployeeService(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public bool RegisterCustomer(Employee employee)
        {
            try
            {
                _employeeContext.employeess.Add(employee);
                _employeeContext.SaveChanges();
            }
            catch { return false; }
            return true;
        }
        public bool ValidateUser(EmployeeLoginDTO customer)
        {
            var result = _employeeContext.employeess
                  .Where(c => c.Email == customer.Email && c.Password == customer.Password)
                  .FirstOrDefault(); //
            if (result != null)
                return true;
            return false;
        }

    }
}
