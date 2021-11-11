using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomogite_2x_WPF_2x.StructurCompanyPg
{
   public class Departament
    {
        //имя департамента
        public string NameDepartament { get; set; }
        //количество сотрудников
        public int Quantity { get; set; }
        // айди департамента
        public int ID { get; set; }
        //конструктор департамента
        public Departament(string nameDepartament, int quantity, int id) => (NameDepartament, Quantity, ID) = (nameDepartament, quantity, id);
        public Departament()
        {
        }
   }
}
