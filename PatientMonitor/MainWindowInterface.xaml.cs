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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace PatientMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer mutable = new SoundPlayer(PatientMonitor.Properties.Resources.Mutable);
        SoundPlayer nonMutable = new SoundPlayer(PatientMonitor.Properties.Resources.NonMutable);

        public MainWindow()
        {
            InitializeComponent();
            PatientFactory factory = new PatientFactory();
            PatientMonitoringController controller = new PatientMonitoringController(this, factory);
            controller.RunMonitor();
        }

        public void soundMutableAlarm()
        {
            mutable.Stop();
            mutable.Play();
        }

        public void soundNonMutableAlarm()
        {
            nonMutable.Stop();
            nonMutable.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails monitoringAlarmDetails = new monitoringandalarmdetails();
            monitoringAlarmDetails.Show();
            MainWindowInterface mainWindowInterface = new MainWindowInterface();
            //this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails mainInterface = new monitoringandalarmdetails();
            mainInterface.Show();
        }
    }
}
