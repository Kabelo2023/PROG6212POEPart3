using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Linq;
using System.Windows;

namespace ClaimsManagementSystem
{
    public partial class AcademicManagerWindow : Window
    {
        public AcademicManagerWindow()
        {
            InitializeComponent();
        }

        // Handle the Approve Claims Button click
        private void ApproveClaimsButton_Click(object sender, RoutedEventArgs e)
        {
            // Filter and approve pending claims
            var pendingClaims = ClaimStorage.Claims.Where(c => c.Status == "Pending").ToList();
            if (pendingClaims.Count > 0)
            {
                // For each pending claim, change its status to "Approved"
                foreach (var claim in pendingClaims)
                {
                    claim.Status = "Approved";
                }

                MessageBox.Show("All pending claims have been approved.", "Claims Approved", MessageBoxButton.OK, MessageBoxImage.Information);

                // Refresh the claims display
                RefreshClaimsList();

                // After approval, update the chart
                UpdateClaimsChart();
            }
            else
            {
                MessageBox.Show("No pending claims to approve.", "No Pending Claims", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Refresh the claims list
        private void RefreshClaimsList()
        {
            ClaimsListBox.Items.Clear();

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

        // Update the chart after claims are approved
        private void UpdateClaimsChart()
        {
            // Create a new PlotModel for the chart
            var plotModel = new PlotModel { Title = "Claims Overview" };

            // Create a BarSeries to represent claim data
            var barSeries = new BarSeries
            {
                ItemsSource = ClaimStorage.Claims.Select(c => new BarItem { Value = (double)c.CalculateClaimAmount() }).ToList(),
                LabelPlacement = LabelPlacement.Outside,
                LabelFormatString = "{0:C}" // Format labels as currency
            };

            // Add the series to the PlotModel
            plotModel.Series.Add(barSeries);

            // Set the PlotModel as the DataContext for the PlotView
            ClaimsChart.Model = plotModel;

            // Add X-Axis (Lecturer names)
            var xAxis = new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Key = "LecturerAxis",
                ItemsSource = ClaimStorage.Claims.Select(c => c.LecturerName).ToArray()
            };

            plotModel.Axes.Add(xAxis);

            // Add Y-Axis (Total Claim Amount)
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Total Claim Amount",
                Minimum = 0, // Set minimum to 0 for clarity
                MajorStep = 100 // Step interval for Y-Axis labels
            };

            plotModel.Axes.Add(yAxis);
        }
    }
}
