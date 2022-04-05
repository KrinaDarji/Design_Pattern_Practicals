using Practical_24.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practical_24.Mediator
{
    public interface RespondMediator
    {
        void PostEmployee(Employee employee);
        void PutEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
    }
}
