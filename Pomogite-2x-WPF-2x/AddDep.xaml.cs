using Pomogite_2x_WPF_2x.StructurCompanyPg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pomogite_2x_WPF_2x
{
    /// <summary>
    /// Логика взаимодействия для AddDep.xaml
    /// </summary>
    public partial class AddDep : Window, INotifyChanged
    {
       
        public AddDep()
        {
           
            InitializeComponent();
        }
        /// <summary>
        /// добавление работника в коллекцию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddWork_Click(object sender, RoutedEventArgs e)
        {
           
           MainWindow.company.Workers.Add(new People.Worker(Convert.ToString(NameWork.Text), Convert.ToString(LastNameWork.Text), Convert.ToInt32(AgeWork.Text), Convert.ToInt32(Salary.Text), Convert.ToInt32(ID.Text)));
            Changed();
        }
        /// <summary>
        /// добавление студента в коллекцию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStud_Click(object sender, RoutedEventArgs e)
        {
           MainWindow.company.Students.Add(new People.Student(Convert.ToString(NameStud.Text), Convert.ToString(LastNameStud.Text), Convert.ToInt32(AgeStud.Text), Convert.ToInt32(300), Convert.ToInt32(IDStud.Text)));
            Changed();
        }
        /// <summary>
        /// добавление департамента в коллекцию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDepart_Click(object sender, RoutedEventArgs e)
        {
           MainWindow.company.Departaments.Add(new Departament(Convert.ToString(NameDep.Text), Convert.ToInt32(QuantityWork.Text), Convert.ToInt32(IDDep.Text)));
            Changed();


        }

        public void Changed()
        {
            MessageBox.Show("Обновите программу");
        }
    }
}
