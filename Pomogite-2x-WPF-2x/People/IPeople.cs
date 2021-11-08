using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomogite_2x_WPF_2x.People
{
    interface IPeople
    {
        int SalaryWorks();
        int SalaryWorks(int Salary);
        int SalaryWorks(int Salary, int NumberWorks);
    }
}
