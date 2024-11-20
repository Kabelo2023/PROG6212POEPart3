using Microsoft.Win32;
using System;
using System.Windows;

namespace ClaimsManagementSystem
{
    public partial class ClaimSubmission : Window
    {
        public ClaimSubmission()
        {
            InitializeComponent();

            // Add event handlers to update the total payment when HoursWorkedTextBox or HourlyRateTextBox change
            HoursWorkedTextBox.TextChanged += CalculateTotalPayment;
            HourlyRateTextBox.TextChanged += CalculateTotalPayment;
        }

        // This method calculates and updates the total payment
        private void CalculateTotalPayment(object sender, EventArgs e)
        {
            // Try parsing the input values
            if (int.TryParse(HoursWorkedTextBox.Text, out int hoursWorked) &&
                decimal.TryParse(HourlyRateTextBox.Text, out decimal hourlyRate))
            {
                // Calculate the total payment
                decimal totalPayment = hoursWorked * hourlyRate;
                // Display the total payment in the TextBlock (formatted as currency)
                TotalPaymentTextBlock.Text = $"Total Payment: {totalPayment:C}"; // Using currency format
            }
            else
            {
                // Clear the total payment text if input is invalid
                TotalPaymentTextBlock.Text = string.Empty;
            }
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            // Open a file dialog to upload a document (supports pdf, docx, xlsx)
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Documents|*.pdf;*.docx;*.xlsx", // Filter for document types
                Title = "Select Supporting Document"
            };

            // Show the file dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == true)
            {
                // Display the file path in the UploadedFileName TextBlock
                UploadedFileName.Text = $"Uploaded: {openFileDialog.FileName}";

                // You can add logic to store the file path or perform other actions here
                // For example, saving the file path in a variable or property
            }
            else
            {
                // Optionally, handle the case where no file is selected
                MessageBox.Show("No file selected.");
            }
        }


        // Event handler for submitting a claim
        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LecturerNameTextBox.Text) ||
                string.IsNullOrEmpty(HoursWorkedTextBox.Text) ||
                string.IsNullOrEmpty(HourlyRateTextBox.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (!int.TryParse(HoursWorkedTextBox.Text, out int hoursWorked))
            {
                MessageBox.Show("Please enter a valid number for Hours Worked.");
                return;
            }

            if (!decimal.TryParse(HourlyRateTextBox.Text, out decimal hourlyRate))
            {
                MessageBox.Show("Please enter a valid number for Hourly Rate.");
                return;
            }

            if (hourlyRate <= 0 || hoursWorked <= 0)
            {
                MessageBox.Show("Hours Worked and Hourly Rate must be positive values.");
                return;
            }

            try
            {
                var claim = new Claim
                {
                    LecturerName = LecturerNameTextBox.Text,
                    HoursWorked = hoursWorked,
                    HourlyRate = hourlyRate,
                    AdditionalNotes = NotesTextBox.Text,
                    SupportingDocument = UploadedFileName.Text,
                    Status = "Pending"
                };

                // Add the claim to MainWindow's ClaimsList
                MainWindow.ClaimsList.Add(claim);

                MessageBox.Show("Claim submitted successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error");
            }
        }
    }
}
