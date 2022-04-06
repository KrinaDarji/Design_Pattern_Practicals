using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public sealed class Service
    {
      
        private readonly ApplicationDBContext context;
        private static Service instance = null; public Service(ApplicationDBContext context)
        {
            this.context = context;
        }
        private Service() { }
        public static Service GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Service();
                return instance;
            }
        }


        public async Task<bool> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return false;
            }
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await context.Employees.Include(x => x.Department).Where(x => x.Status == false).ToListAsync();
            return employees;
        }
        public async Task DeleteEmployee(int id)
        {
            var employee = await GetEmployee(id);
            employee.Status = true;
            context.Update(employee);
            await context.SaveChangesAsync();
        }
        public async Task<Employee> GetEmployee(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return await context.Employees.FindAsync(id);
        }
        public async Task UpdateEmployee(Employee employee)
        {
            context.Update(employee);
            await context.SaveChangesAsync();
        }
        public async Task<bool> IsEmployeeExist(int id)
        {
            var entity = await GetEmployee(id);
            return entity != null;
        }
    }
}
