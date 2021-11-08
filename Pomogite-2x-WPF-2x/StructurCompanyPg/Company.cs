using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Pomogite_2x_WPF_2x.StructurCompanyPg
{
  public class Company
    {
        // названия кмпании
        public string NameCompany { get; set; }
        //коллекция департаментов
        public List<Departament> Departaments = new List<Departament>();
        //коллекция студентов
        public List<People.Student> Students = new List<People.Student>();
        //коллекция работников
        public List<People.Worker> Workers = new List<People.Worker>();
        //конструктор создания компании
        public Company()
        {

        }
        public Company(string nameCompany, List<Departament> departaments, List<People.Worker> workers, List<People.Student> students)
        {
            this.NameCompany = nameCompany;
            this.Departaments = departaments;
            this.Workers = workers;
            this.Students = students;
        }

        /// <summary>
        /// происходит десериализация файла
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Company DeserializeXml(string path)// десериализации Xml
        {

            Company сompany = new Company();

            // создания сериализации для листа
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Company));

            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);// создания потока

            сompany = xmlSerializer.Deserialize(stream) as Company;//десериализация

            stream.Close();// закрытие потока

            return сompany;
        }
  }
}
