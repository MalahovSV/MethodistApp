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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {

        public Users()
        {
            InitializeComponent();
            dataLoad();
            bindEvents();
        }

        private void dataLoad()
        {
            using (MethodologistApplicationContext db = new MethodologistApplicationContext())
            {
                var usersData = db.Users.Join(db.JobTitles,
                    u => u.JobTitleId,
                    c => c.JobTitleId,
                    (u, c) => new
                    {
                        UserId = u.UserId,
                        LoginUser = u.LoginUser,
                        PasswordUser = u.PasswordUser,
                        Surname = u.Surname,
                        FirstName = u.FirstName,
                        SecondName = u.SecondName,
                        Email = u.Email,
                        JobTitleName = c.JobTitle1
                    }).ToList();

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("Логин");
                dataTable.Columns.Add("Пароль");
                dataTable.Columns.Add("Фамилия");
                dataTable.Columns.Add("Имя");
                dataTable.Columns.Add("Отчество");
                dataTable.Columns.Add("Почта");
                dataTable.Columns.Add("Должность");
                foreach (var user in usersData)
                {
                    dataTable.Rows.Add(user.UserId,
                        user.LoginUser,
                        user.PasswordUser,
                        user.Surname,
                        user.FirstName,
                        user.SecondName,
                        user.Email,
                        user.JobTitleName);
                }
                UsersTable.ItemsSource = dataTable.AsDataView();
            }
        }
        private void bindEvents()
        {
            UsersTable.MouseDoubleClick += (s, e) =>
            {
                if (UsersTable.SelectedValue is not null)
                {
                    DataRowView dataRow = (DataRowView)UsersTable.SelectedValue;
                    EditViews.EditUser editUser = new EditViews.EditUser(Int32.Parse(dataRow[0].ToString()));
                    editUser.ShowDialog();
                    dataLoad();
                }
            };
        }

        private void NewUserButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)UsersTable.SelectedValue;
            EditViews.EditUser editUser = new EditViews.EditUser(0);
            editUser.ShowDialog();
            dataLoad();
        }
    }
}
