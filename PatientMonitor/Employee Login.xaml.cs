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
    /// Interaction logic for Employee_Login.xaml
    /// </summary>
    public partial class Employee_Login : Window
    {
        public Employee_Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }
    }
}
