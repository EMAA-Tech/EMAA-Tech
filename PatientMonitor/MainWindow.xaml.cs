using System.Windows;

namespace PatientMonitor
{
    /// Interaction logic for MainWindowInterface.xaml
    public partial class MainWindowInterface : Window
    {
        public MainWindowInterface()
        {
            InitializeComponent();
        }

        private void btnCentralStation_Click(object sender, RoutedEventArgs e)
        {            
            Employee_login loginScreen = new Employee_login();
            loginScreen.Show();
        }

        private void btnBedsideMonitoring_Click(object sender, RoutedEventArgs e)
        {           
            ValidateStaffOnCall validateStaffIfOnCall = new ValidateStaffOnCall();
            validateStaffIfOnCall.validateStaff();
        }
    }
}
