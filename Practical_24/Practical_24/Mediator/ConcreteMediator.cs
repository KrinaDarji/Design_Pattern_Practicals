using Practical_24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_24.Mediator
{
    public class ConcreteMediator : RequestMediator, RespondMediator
    {
        private readonly ApplicationDBContext dBContext;
        public ConcreteMediator(ApplicationDBContext dBContext)
        {
            DBContext = dBContext;
        }

        public ApplicationDBContext DBContext { get; }

        public void DeleteEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void GetEmployee()
        {
            
        }

        public void GetEmployeeByID()
        {
            throw new NotImplementedException();
        }

        public void PostEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void PutEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
