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
    /// Логика взаимодействия для Staffs.xaml
    /// </summary>
    public partial class Staffs : UserControl
    {
        public Staffs()
        {
            InitializeComponent();
            loadData();
            bindEvents();
        }

        private void bindEvents()
        {
            StaffTable.MouseDoubleClick += (s, e) =>
             {
                 if (StaffTable.SelectedValue is not null)
                 {
                     DataRowView dataRow = (DataRowView)StaffTable.SelectedValue;
                     EditViews.EditEmployeer editEmployeer = new EditViews.EditEmployeer(Int32.Parse(dataRow[0].ToString()));
                     editEmployeer.ShowDialog();
                     loadData();
                 }
             };
        }

        private void loadData()
        {
            using (MethodologistApplicationContext db = new MethodologistApplicationContext())
            {
                var employeeData = db.Employeers.Join(db.Ranks,
                    u => u.RankId,
                    c => c.RankId,
                    (u, c) => new
                    {
                        EmployeersId = u.EmployeersId,
                        Surname = u.Surname,
                        FirstName = u.FirstName,
                        SecondName = u.SecondName,
                        DateBirth = u.DateBirth,
                        Email = u.Email,
                        NumberPhone = u.NumberPhone,
                        RankName = c.NameRank,
                    }).ToList();

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Фамилия");
                dataTable.Columns.Add("Имя");
                dataTable.Columns.Add("Отчество");
                dataTable.Columns.Add("Дата рождения");
                dataTable.Columns.Add("Почта");
                dataTable.Columns.Add("Номер телефона");
                dataTable.Columns.Add("Должность");
                foreach (var employee in employeeData)
                {
                    dataTable.Rows.Add(employee.EmployeersId,
                        employee.Surname,
                        employee.FirstName,
                        employee.SecondName,
                        employee.DateBirth.Value.ToShortDateString(),
                        employee.Email,
                        employee.NumberPhone,
                        employee.RankName);
                }
                StaffTable.ItemsSource = dataTable.AsDataView();
            }
        }

        private void AddStaffButton_Click(object sender, RoutedEventArgs e)
        {
            EditEmployeer editStaff = new EditEmployeer(0);
            
            editStaff.ShowDialog();
        }
    }
}
