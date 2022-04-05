using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class OnSiteOverTimePay : ITOverTimePay
    {
        public int MyOverTimePay(int hour)
        {
            int departmentpay = 1000;
            return hour * departmentpay;
        }
    }
}
