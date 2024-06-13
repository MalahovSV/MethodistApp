using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace MethodistApplication.Views.EditViews
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private int _userID { get; set; }
        public EditUser(int UserID)
        {
            InitializeComponent();
            this._userID = UserID;
            dataLoad();
        }

        private void dataLoad()
        {
            using (MethodologistApplicationContext db = new MethodologistApplicationContext())
            {
                var jobTitles = db.JobTitles;
                RankCombo.ItemsSource = jobTitles.ToList();
            }
            if (_userID != 0)
            {
                using (MethodologistApplicationContext db = new MethodologistApplicationContext())
                {
                    var users = db.Users.Where(p => p.UserId == _userID).ToList();

                    LoginField.Text = users[0].LoginUser;
                    PasswordField.Text = users[0].PasswordUser;
                    SurnameField.Text = users[0].Surname;
                    FirstNameField.Text = users[0].FirstName;
                    SecondNameField.Text = users[0].SecondName;
                    EmailField.Text = users[0].Email;
                    RankCombo.SelectedValue = users[0].JobTitleId;
                    this.Title = $@"Редактирование пользователя: {SurnameField.Text} {FirstNameField.Text} {SecondNameField.Text}";
                }

            }
            else
            {
                this.Title = $@"Добавление нового пользователя";
            }
        }
        

        private void RankCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(RankCombo.SelectedValue.ToString());
            
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (_userID != 0)
            {
                using (MethodologistApplicationContext db = new MethodologistApplicationContext())
                {
                    db.Users.Where(i => i.UserId == _userID).ExecuteUpdate(
                        s => s
                        .SetProperty(u => u.LoginUser, u => LoginField.Text)
                        .SetProperty(u => u.PasswordUser, u => PasswordField.Text)
                        .SetProperty(u => u.Email, u => EmailField.Text)
                        .SetProperty(u => u.Surname, u => SurnameField.Text)
                        .SetProperty(u => u.FirstName, u => FirstNameField.Text)
                        .SetProperty(u => u.SecondName, u => SecondNameField.Text)
                        .SetProperty(u => u.JobTitleId, u => Int32.Parse(RankCombo.SelectedValue.ToString()))
                        );
                    MessageBox.Show("Запись обновлена!", "Уведомление", MessageBoxButton.OK);
                }
            }
            else
            {
                using (MethodologistApplicationContext db = new MethodologistApplicationContext())
                {
                    db.Users.Add(new User(
                            
                        )
                    {
                        LoginUser = LoginField.Text,
                        PasswordUser = PasswordField.Text,
                        Email = EmailField.Text,
                        Surname = SurnameField.Text,
                        FirstName = FirstNameField.Text,
                        SecondName = SecondNameField.Text,
                        JobTitleId = Int32.Parse(RankCombo.SelectedValue.ToString())
                    });
                    db.SaveChanges();
                    MessageBox.Show("Запись добавлена!", "Уведомление", MessageBoxButton.OK);
                }
            }
        }
    }
}
