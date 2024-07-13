using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Data
{
    public class EmployeeRepository
        
    {
        private readonly AppDbContext _appDbContext;
        public EmployeeRepository(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _appDbContext.Set<Employee>().AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeAsync(int id)
        {
            return await _appDbContext.Employees.FindAsync(id);

        }
        public async         Task
         UpdateEmployeeAsync(int id,Employee model)
        {
            var employee= await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("No Employee found.");
            }
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.Position = model.Position;
            employee.PhoneNumber = model.PhoneNumber;
            employee.Department = model.Department;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("No Employee found");
            }
            _appDbContext.Employees.Remove(employee);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _appDbContext.Employees.FindAsync(id);
        }

        public async Task UpdateEmployee(int id , Employee model)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.Email = model.Email;
            employee.Position = model.Position;
            employee.PhoneNumber = model.PhoneNumber;
            employee.Department = model.Department;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new Exception("Employee not found");
            }
            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();
        }

        
    }
}
