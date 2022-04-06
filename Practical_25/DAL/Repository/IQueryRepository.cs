using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IQueryRepository
    {
        Task<List<Employee>> GetEmployee(int? id);
    }
}
