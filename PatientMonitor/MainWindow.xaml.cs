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
    /// Interaction logic for MainWindowInterface.xaml
    /// </summary>
    public partial class MainWindowInterface : Window
    {
        public MainWindowInterface()
        {
            InitializeComponent();
<<<<<<< HEAD
        }

        private void btnCentralStation_Click(object sender, RoutedEventArgs e)
        {
            
            Employee_login loginScreen = new Employee_login();
            loginScreen.Show();
        }

        private void btnBedsideMonitoring_Click(object sender, RoutedEventArgs e)
=======
        }

        private void btnCentralStation_Click(object sender, RoutedEventArgs e)
>>>>>>> origin/master
        {
            MainWindow mainInterface = new MainWindow();
            mainInterface.Show();
        }
    }
}
