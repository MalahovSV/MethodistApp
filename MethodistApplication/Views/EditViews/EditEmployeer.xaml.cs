using Microsoft.EntityFrameworkCore;
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

namespace MethodistApplication.Views.EditViews
{
    /// <summary>
    /// Логика взаимодействия для EditStaff.xaml
    /// </summary>
    public partial class EditEmployeer : Window
    {
        private int _employeerId;
        public EditEmployeer(int employeerId)
        {
            InitializeComponent();
            _employeerId = employeerId;
            loadData();

        }

        private void loadData()
        {
            using (MethodologistApplicationContext db = new MethodologistApplicationContext())
            {
                var ranks = db.Ranks;
                RanksCombo.ItemsSource = ranks.ToList();
            }
            if (_employeerId != 0)
            {
                using (MethodologistApplicationContext db = new MethodologistApplicationContext())
                {
                    var employeers = db.Employeers.Where(p => p.EmployeersId == _employeerId).ToList();

                    SurnameField.Text = employeers[0].Surname;
                    FirstNameField.Text = employeers[0].FirstName;
                    SecondNameField.Text = employeers[0].SecondName;

                    EmailField.Text = employeers[0].Email;
                    RanksCombo.SelectedValue = employeers[0].RankId;
                    this.Title = $@"Редактирование сотрудника: {SurnameField.Text} {FirstNameField.Text} {SecondNameField.Text}";
                }

            }
            else
            {
                this.Title = $@"Добавление нового пользователя";
            }
        }

        private void onAcceptButton(object sender, RoutedEventArgs e)
        {
            if (_employeerId != 0)
            {
                using (MethodologistApplicationContext db = new MethodologistApplicationContext())
                {
                    db.Employeers.Where(i => i.EmployeersId == _employeerId).ExecuteUpdate(
                        s => s
                        .SetProperty(u => u.Surname, u => SurnameField.Text)
                        .SetProperty(u => u.FirstName, u => FirstNameField.Text)
                        .SetProperty(u => u.SecondName, u => SecondNameField.Text)
                        .SetProperty(u => u.DateBirth, u => DateBirthField.SelectedDate.Value)
                        .SetProperty(u => u.Inn, u => INNField.Text)
                        .SetProperty(u => u.NumberSnils, u => SnilsField.Text)
                        .SetProperty(u => u.SerialPassport, u => SerialPassField.Text)
                        .SetProperty(u => u.NumberPassport, u => NumberPassField.Text)
                        .SetProperty(u => u.WhenIssued, u => WhenIssuedField.SelectedDate.Value)
                        .SetProperty(u => u.IssuidBy, u => IssuidIssuedField.Text)
                        .SetProperty(u => u.RegistrationAddres, u => AddressField.Text)
                        .SetProperty(u => u.RankId, u => Int32.Parse(RanksCombo.SelectedValue.ToString()))
                        .SetProperty(u => u.NameBank, u => NameBankField.Text)
                        .SetProperty(u => u.AccountNumber, u => AccountNumberField.Text)
                        .SetProperty(u => u.NumberPhone, u => NumberPhoneField.Text)
                        .SetProperty(u => u.Email, u => EmailField.Text)
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
                        //LoginUser = LoginField.Text,
                        //PasswordUser = PasswordField.Text,
                        Email = EmailField.Text,
                        Surname = SurnameField.Text,
                        FirstName = FirstNameField.Text,
                        SecondName = SecondNameField.Text,
                        //JobTitleId = Int32.Parse(RankCombo.SelectedValue.ToString())
                    });
                    db.SaveChanges();
                    MessageBox.Show("Запись добавлена!", "Уведомление", MessageBoxButton.OK);
                }
            }
        }

        private void RanksCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show($"{RanksCombo.SelectedValue.ToString()}");
        }
    }


}
