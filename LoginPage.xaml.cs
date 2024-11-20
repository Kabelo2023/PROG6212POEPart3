using System.Windows;

namespace ClaimsManagementSystem
{
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Simple example: Assume the username/password combination is checked here
            if (username == "hruser" && password == "password123")
            {
                // HR User logged in, navigate to HRWindow
                HRWindow hrWindow = new HRWindow();
                hrWindow.Show();
                this.Close(); // Close the current login window
            }
            else if (username == "admin" && password == "admin123")
            {
                // Admin User logged in, navigate to MainWindow or another window
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close(); // Close the current login window
            }
            else
            {
                // Invalid credentials, show error
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UsernameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "Username")
            {
                UsernameTextBox.Text = ""; // Clear watermark when focused
            }
        }

        private void UsernameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                UsernameTextBox.Text = "Username"; // Show watermark again if empty
            }
        }

        private void PasswordWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordWatermark.Visibility = Visibility.Collapsed; // Hide watermark when focused
        }

        private void PasswordWatermark_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                PasswordWatermark.Visibility = Visibility.Visible; // Show watermark if empty
            }
        }

    }
}
