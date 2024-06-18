using MethodistApplication.Views.EditViews;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace MethodistApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для Disciplines.xaml
    /// </summary>
    public partial class Disciplines : UserControl
    {
        public Disciplines()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Дисциплина"); 
            dataTable.Columns.Add("Индекс группы");      
            dataTable.Columns.Add("Количество часов");
            dataTable.Rows.Add("1", "Информатика", "ИВТ-31", "232");
            dataTable.Rows.Add("2", "Информатика", "КТМ-31", "232");
            dataTable.Rows.Add("3", "Информатика", "ЭиЭ-31", "232");
            dataTable.Rows.Add("4", "Математика", "ИСП9-31", "277");
            dataTable.Rows.Add("5", "Математика", "ИСП9-32", "277");
            dataTable.Rows.Add("6", "Аналитическая геометрия", "ИВТ-31", "82");
            dataTable.Rows.Add("7", "Проектирование пользовательских интерфейсов", "ИВТ-31", "57");
            dataTable.Rows.Add("8", "Основы алгоритмизации и программирования", "ИСП 9-21", "126");
            dataTable.Rows.Add("9", "Основы алгоритмизации и программирования", "ИСП11-31", "126"); 
            DisciplinesDataGrid.ItemsSource = dataTable.AsDataView();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EditDisciplines editDisciplines = new EditDisciplines();
            editDisciplines.ShowDialog();
        }
    }
}
