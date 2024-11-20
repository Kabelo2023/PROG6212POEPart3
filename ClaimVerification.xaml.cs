using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace ClaimsManagementSystem
{
    public partial class ClaimVerification : Window
    {
        public ClaimVerification()
        {
            InitializeComponent();
            LoadClaims(); // Load claims from the static ClaimsList in MainWindow
        }

        private void LoadClaims()
        {
            // Assuming ClaimsList is a static property in MainWindow that holds all claims
            if (MainWindow.ClaimsList != null)
            {
                ClaimsListView.ItemsSource = MainWindow.ClaimsList; // Bind the ListView to the ClaimsList
            }
            else
            {
                MessageBox.Show("No claims available to display.");
            }
        }

        // Event handler for the Open Document button click
        private void OpenDocument_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            string documentPath = button.Tag.ToString();  // Assuming the document path is stored in the Tag property

            if (string.IsNullOrEmpty(documentPath))
            {
                MessageBox.Show("Document path is not available.");
                return;
            }

            try
            {
                // Open the document using the default application associated with the file type
                Process.Start(new ProcessStartInfo(documentPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening document: {ex.Message}");
            }
        }

        // Approve button handler
        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((Button)sender).DataContext;
            if (claim.Status == "Pending")
            {
                claim.Status = "Approved";
                ClaimsListView.Items.Refresh(); // Refresh the ListView to update the status
            }
            else
            {
                MessageBox.Show("Claim has already been processed.");
            }
        }

        // Reject button handler
        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((Button)sender).DataContext;
            if (claim.Status == "Pending")
            {
                claim.Status = "Rejected";
                ClaimsListView.Items.Refresh(); // Refresh the ListView to update the status
            }
            else
            {
                MessageBox.Show("Claim has already been processed.");
            }
        }

        // Remove button handler
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            var claim = (Claim)((Button)sender).DataContext;
            var result = MessageBox.Show($"Are you sure you want to remove the claim for {claim.LecturerName}?",
                                         "Remove Claim", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Remove the claim from MainWindow's ClaimsList
                MainWindow.ClaimsList.Remove(claim);
                ClaimsListView.Items.Refresh(); // Refresh the ListView to reflect the removal
            }
        }

        private void ClaimsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle item selection changes if necessary
        }
    }
}
