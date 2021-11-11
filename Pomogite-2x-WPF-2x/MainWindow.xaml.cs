using Pomogite_2x_WPF_2x.StructurCompanyPg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //создания компании
        public static  Company company;
        /// <summary>
        /// запускаеться программа и берет компанию с файла 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //путь файла
            string path = @"C:\Users\poc18\OneDrive\Рабочий стол\задание4\Now\Company.xml";
            company = new Company();
            //депериализация файла
            company = Company.DeserializeXml(path);
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
            lvWork.ItemsSource =  company.Workers.Where(idWork);
            //заполняет лист коллекцией студентов по айди департамента 
            lvStud.ItemsSource = company.Students.Where(idStud);
        }
        /// <summary>
        /// метод по выдачи департаментот работников и студентов в таблицы 
        /// </summary>
        private void refresh()
        {   //заполняет лист коллекцией работников
            lvWork.ItemsSource = company.Workers;
            //заполняет лист коллекцией студентов 
            lvStud.ItemsSource = company.Students;
            //заполняет лист коллекцией департаментов
            lvDepart.ItemsSource = company.Departaments;
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
                company.Workers.RemoveAt(indexWork);//удаление работника в коллекции
            }
            if (firstIndex == 3)
            {
                int indexStud = lvStud.SelectedIndex;//индекс по удалению студента
                company.Students.RemoveAt(indexStud);//удаление студента в коллекции
            }
            if (firstIndex ==1)
            {
                int indexDep = lvDepart.SelectedIndex;//индекс по удалению департамента
                int IDdelet = Convert.ToInt32(ID.Text);// удаление по ауди сотрудников
                company.Departaments.RemoveAt(indexDep);//удаление департамента в коллекции
                DeletStaff(IDdelet);
            }
            refresh();
        }
        /// <summary>
        /// удаление сотрудников после департамента 
        /// </summary>
        /// <param name="IDdelet"></param>
        public void DeletStaff(int IDdelet)
        {
            company.Workers.RemoveAll(item => item.IdDepart == IDdelet);
            company.Students.RemoveAll(item => item.IdDepart == IDdelet);
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
        /// <summary>
        /// кнопка обновления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshNow_Click(object sender, RoutedEventArgs e)
        {
            DeleteListView();
            refresh();
        }
        /// <summary>
        /// происходит удаление текста в таблице 
        /// </summary>
        public void DeleteListView()
        {
            lvDepart.ItemsSource = null;
            lvStud.ItemsSource = null;
            lvWork.ItemsSource = null;
        }
    }
}