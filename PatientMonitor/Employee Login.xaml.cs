using System.Windows;

namespace PatientMonitor
{
    public partial class Employee_login : Window
    {
        public Employee_login()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string staffID = txtID.Text;
            Login staffLogin = new Login();

            staffLogin.StaffLogin(staffID);
            this.Close();
        }
    }
}
