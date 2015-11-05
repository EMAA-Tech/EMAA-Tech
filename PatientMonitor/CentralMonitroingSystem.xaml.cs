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
    /// Interaction logic for CentralMonitroingSystem.xaml
    /// </summary>
    public partial class CentralMonitroingSystem : Window
    {
        public CentralMonitroingSystem()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails frm = new monitoringandalarmdetails();
            frm.Show();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails frm = new monitoringandalarmdetails();
            frm.Show();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            monitoringandalarmdetails frm = new monitoringandalarmdetails();
            frm.Show();
        }
    }
}
