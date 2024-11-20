using System;
using System.Linq;
using System.Windows;

namespace ClaimsManagementSystem
{
    public partial class HRWindow : Window
    {
        public HRWindow()
        {
            InitializeComponent();
        }

        // Handle the GotFocus event of the ClaimIdSearchTextBox to hide the placeholder text
        private void ClaimIdSearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ClaimIdPlaceholder.Visibility = Visibility.Collapsed; // Hide placeholder when focused
        }

        // Handle the LostFocus event of the ClaimIdSearchTextBox to show the placeholder text
        private void ClaimIdSearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ClaimIdSearchTextBox.Text))
            {
                ClaimIdPlaceholder.Visibility = Visibility.Visible; // Show placeholder if no text
            }
        }

        // Handle the Generate Report Button click
        private void GenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ClaimIdSearchTextBox.Text, out int claimId))
            {
                var claim = ClaimStorage.Claims.FirstOrDefault(c => c.ClaimId == claimId);
                if (claim != null)
                {
                    decimal totalAmount = claim.CalculateClaimAmount();
                    MessageBox.Show(
                        $"Claim ID: {claim.ClaimId}\n" +
                        $"Lecturer: {claim.LecturerName}\n" +
                        $"Hours Worked: {claim.HoursWorked}\n" +
                        $"Hourly Rate: {claim.HourlyRate:C}\n" +
                        $"Total Amount: {totalAmount:C}\n" +
                        $"Status: {claim.Status}\n" +
                        $"Notes: {claim.AdditionalNotes}",
                        "Claim Details",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information
                    );

                    // Add the claim to the ListBox
                    ClaimsListBox.Items.Clear(); // Clear any existing claims in the list
                    ClaimsListBox.Items.Add(
                        $"Claim ID: {claim.ClaimId}, Lecturer: {claim.LecturerName}, " +
                        $"Hours Worked: {claim.HoursWorked}, Hourly Rate: {claim.HourlyRate:C}, " +
                        $"Total Amount: {totalAmount:C}, Status: {claim.Status}"
                    );
                }
                else
                {
                    MessageBox.Show("Claim not found. Please check the Claim ID and try again.", "No Claim Found", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Claim ID.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Handle the View Claim Details Button click
        private void ViewClaimDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            ClaimsListBox.Items.Clear(); // Clear existing items

            foreach (var claim in ClaimStorage.Claims)
            {
                decimal totalAmount = claim.CalculateClaimAmount();
                ClaimsListBox.Items.Add(
                    $"Claim ID: {claim.ClaimId}, Lecturer: {claim.LecturerName}, " +
                    $"Hours Worked: {claim.HoursWorked}, Hourly Rate: {claim.HourlyRate:C}, " +
                    $"Total Amount: {totalAmount:C}, Status: {claim.Status}"
                );
            }
        }

        // Handle the Clear Claim Button click
        private void ClearClaimButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsListBox.SelectedItem != null)
            {
                ClaimsListBox.Items.Remove(ClaimsListBox.SelectedItem); // Remove the selected item
            }
            else
            {
                MessageBox.Show("Please select a claim to clear.", "No Claim Selected", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Handle the Clear All Claims Button click
        private void ClearAllClaimsButton_Click(object sender, RoutedEventArgs e)
        {
            ClaimsListBox.Items.Clear(); // Clears all the items in the ListBox
        }

       

        // Open Academic Manager window
        private void AcademicManagerButton_Click(object sender, RoutedEventArgs e)
        {
            var academicManagerWindow = new AcademicManagerWindow();
            academicManagerWindow.Show();
            this.Close();  // Close HRWindow when navigating
        }
    }
}
