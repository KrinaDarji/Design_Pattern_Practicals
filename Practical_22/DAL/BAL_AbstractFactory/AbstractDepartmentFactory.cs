using BAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.BAL_AbstractFactory
{
    public interface AbstractDepartmentFactory
    {
        IOvertimePay GetFactory(string deptname);
    }
}
