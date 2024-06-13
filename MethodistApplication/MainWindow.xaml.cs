using MethodistApplication.Views;
using MethodistApplication.Views.EditViews;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MethodistApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginWindow loginWindow;
        private List<ToggleButton> _toggleButtons = new List<ToggleButton>();
        public MainWindow(LoginWindow loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
            _toggleButtons.Add(StaffButton);
            _toggleButtons.Add(UsersButton);
            _toggleButtons.Add(HoursesButton);
            _toggleButtons.Add(GpdButton);
            _toggleButtons.Add(HelpButton);

        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вернуться к форме авторизации?", "Завершение работы", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                loginWindow.Show();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                loginWindow.Close();
            }
        }

        private void offToggleButtons(ToggleButton currentButton)
        {
            foreach (ToggleButton button in _toggleButtons)
            {
                if (button != currentButton)
                {
                    button.IsChecked = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void StaffButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void StaffButton_Checked(object sender, RoutedEventArgs e)
        {
            offToggleButtons(StaffButton);
            Staffs staffs = new Staffs();
            ToolsGrid.Children.Clear();
            ToolsGrid.Children.Add(staffs);
            Grid.SetRow(staffs, 1);
            Grid.SetColumn(staffs, 1);

        }

        private void UsersButton_Checked(object sender, RoutedEventArgs e)
        {
            offToggleButtons(UsersButton);
            EditUser editUser = new EditUser(0);
            Views.Users users = new Views.Users();
            ToolsGrid.Children.Clear();
            ToolsGrid.Children.Add(users);
            Grid.SetRow(users, 1);
            Grid.SetColumn(users, 1);
            //editUser.ShowDialog();
        }

        private void HelpButton_Checked(object sender, RoutedEventArgs e)
        {
            offToggleButtons(HelpButton);
        }

        private void GpdButton_Checked(object sender, RoutedEventArgs e)
        {
            offToggleButtons(GpdButton);
        }

        private void HoursesButton_Checked(object sender, RoutedEventArgs e)
        {
            offToggleButtons(HoursesButton);
        }
    }
}