using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PatientMonitor
{
    /// <summary>
    /// Interaction logic for Employee_login.xaml
    /// </summary>
    public partial class Employee_login : Window
    {
        public Employee_login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (txtID.Text == "admin" && passwordBox.Password == "12345")
            //{
            //    monitoringandalarmdetails CentralStation = new monitoringandalarmdetails();
            //    CentralStation.Show();
            //    this.Close();
            //}
            //else
            //{
            //    txtID.Text = string.Empty;
            //    passwordBox.Password = string.Empty;
            //    MessageBox.Show("Wrong Username/Password!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            monitoringandalarmdetails CentralStation = new monitoringandalarmdetails();
            CentralStation.Show();
            this.Close();

        }
    }
}
