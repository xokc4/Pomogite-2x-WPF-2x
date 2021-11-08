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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pomogite_2x_WPF_2x
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //индекс по нажатию таблицы
        public static int firstIndex = 0;
        public Company company1;
        /// <summary>
        /// запускаеться программа и берет компанию с файла 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //путь файла
            string path = @"C:\Users\poc18\OneDrive\Рабочий стол\задание4\Now\Company.xml";
            //создания компании
            company1 = new Company();
            //депериализация файла
            company1 = company1.DeserializeXml(path);
        }
        /// <summary>
        /// кнопка для создани компании
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Csow_Click(object sender, RoutedEventArgs e)
        {

            refresh();
        }

        /// <summary>
        /// кнопка по выбору депортамента 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ref_Click(object sender, RoutedEventArgs e)
        {
            //заполняет лист коллекцией работников по айди департамента 
            lvWork.ItemsSource = company1.Workers.Where(idWork);
            //заполняет лист коллекцией студентов по айди департамента 
            lvStud.ItemsSource = company1.Students.Where(idStud);
        }
        /// <summary>
        /// метод по выдачи департаментот работников и студентов в таблицы 
        /// </summary>
        private void refresh()
        {   //заполняет лист коллекцией работников
            lvWork.ItemsSource = company1.Workers;
            //заполняет лист коллекцией студентов 
            lvStud.ItemsSource = company1.Students;
            //заполняет лист коллекцией департаментов
            lvDepart.ItemsSource = company1.Departaments;
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
        
        }
        /// <summary>
        /// кнопка по удалению работника, студентов и департаментов 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, RoutedEventArgs e)
        {// условие по удалению, если индекс = 2 то удаляеться работник и тд.
            if (firstIndex == 2)
            {
                int indexWork = lvWork.SelectedIndex;//индекс по удалению работника
                company1.Workers.RemoveAt(indexWork);//удаление работника в коллекции
            }
            if (firstIndex == 3)
            {
                int indexStud = lvStud.SelectedIndex;//индекс по удалению студента
                company1.Students.RemoveAt(indexStud);//удаление студента в коллекции
            }
            if (firstIndex ==1)
            {
                int indexDep = lvDepart.SelectedIndex;//индекс по удалению департамента
                company1.Departaments.RemoveAt(indexDep);//удаление департамента в коллекции
            }
            refresh();
        }
        /// <summary>
        /// кнопка по открытие новой формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_Click(object sender, RoutedEventArgs e)
        {
            AddDep add = new AddDep();//создание формы
       
            add.Show();//открытие формы
        }
        /// <summary>
        /// метод по выбору работника с помощью айди
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool idWork(People.Worker arg)
        {
            return arg.IdDepart == (lvDepart.SelectedItem as StructurCompanyPg.Departament).ID;
        }
        /// <summary>
        /// метод по выбору студентов с помощью айди 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool idStud(People.Student arg)
        {
            return arg.IdDepart == (lvDepart.SelectedItem as StructurCompanyPg.Departament).ID;
        }
        /// <summary>
        /// фокус таблицы на департаменте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvDepart_GotFocus(object sender, RoutedEventArgs e)
        {
            //индекс таблицы
            firstIndex = 1;
            VisibleDep();
            HiddenStud();
            HiddenWork();
        }
        
        /// <summary>
        /// фокус таблицы на работнике
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvWork_GotFocus(object sender, RoutedEventArgs e)
        {
            // индекс таблицы
            firstIndex = 2;
            VisibleWork();
            HiddenStud();
            HiddenDep();
        }
        /// <summary>
        /// фокус таблицы на студенте 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvStud_GotFocus(object sender, RoutedEventArgs e)
        {
            // индекс таблицы
            firstIndex = 3;
            HiddenWork();
            VisibleStud();
            HiddenDep();
        }
        /// <summary>
        /// показывает "текстблоки" с помощью которых можно изменить информацию о работнике
        /// </summary>
        public void VisibleWork()
        {
            NameWork.Visibility = Visibility.Visible;
            LastNameWork.Visibility = Visibility.Visible;
            AgeWork.Visibility = Visibility.Visible;
            SalaryWork.Visibility = Visibility.Visible;
            DepartIDWork.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// метод по скрытию "текстблоков" с помощью которых можно изменить информацию о департаменте 
        /// </summary>
        public void HiddenWork()
        {
            NameWork.Visibility = Visibility.Hidden;
            LastNameWork.Visibility = Visibility.Hidden;
            AgeWork.Visibility = Visibility.Hidden;
            SalaryWork.Visibility = Visibility.Hidden;
            DepartIDWork.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// показывает "текстблоки" с помощью которых можно изменить информацию о студенте
        /// </summary>
        public void VisibleStud()
        {
            NameStud.Visibility = Visibility.Visible;
            LastNameStud.Visibility = Visibility.Visible;
            AgeStud.Visibility = Visibility.Visible;
            SalaryStud.Visibility = Visibility.Visible;
            DepartIDStud.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// метод по скрытию "текстблоков" с помощью которых можно изменить информацию о департаменте 
        /// </summary>
        public void HiddenStud()
        {
            NameStud.Visibility = Visibility.Hidden;
            LastNameStud.Visibility = Visibility.Hidden;
            AgeStud.Visibility = Visibility.Hidden;
            SalaryStud.Visibility = Visibility.Hidden;
            DepartIDStud.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// показывает "текстблоки" с помощью которых можно изменить информацию о департаменте 
        /// </summary>
        public void VisibleDep()
        {
            NameDep.Visibility = Visibility.Visible;
            Quantity.Visibility = Visibility.Visible;
            ID.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// метод по скрытию "текстблоков" с помощью которых можно изменить информацию о департаменте 
        /// </summary>
        public void HiddenDep()
        {
            NameDep.Visibility = Visibility.Hidden;
            Quantity.Visibility = Visibility.Hidden;
            ID.Visibility = Visibility.Hidden;
        }
    }
}