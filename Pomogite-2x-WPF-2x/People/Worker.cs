using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomogite_2x_WPF_2x.People
{
    public class Worker: People
    {
        public Worker()
        {

        }
        public Worker(string name, string lastName, int age, int salary, int idDepart) : base(name, lastName, age, salary, idDepart)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = SalaryWorks(salary);
            this.IdDepart = idDepart;
        }
    }
}
