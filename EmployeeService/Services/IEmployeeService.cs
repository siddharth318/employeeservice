using EmployeeService.DTOS;
using EmployeeService.Models;

namespace EmployeeService.Services
{
    public interface IEmployeeService
    {
        bool AddEmployee(Employee e);
        bool DeleteEmployee(int id);
        Task<List<Employee>> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool RegisterCustomer(Employee employee);
        bool UpdateEmployee(int id, Employee e);
        bool ValidateUser(EmployeeLoginDTO customer);
    }
}