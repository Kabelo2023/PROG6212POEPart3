using System.Collections.Generic;
using System.Windows;

namespace ClaimsManagementSystem
{
    public partial class MainWindow : Window
    {
        // Static list to store all claims
        public static List<Claim> ClaimsList { get; set; } = new List<Claim>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler to open the Claim Submission window
        private void SubmitClaimButton_Click(object sender, RoutedEventArgs e)
        {
            var claimSubmissionWindow = new ClaimSubmission();
            claimSubmissionWindow.ShowDialog();
        }                                 

        // Event handler to open the Verify Claims window (implementation of ClaimVerification window is separate)
        private void VerifyClaimsButton_Click(object sender, RoutedEventArgs e)
        {
            var claimVerificationWindow = new ClaimVerification();
            claimVerificationWindow.ShowDialog();
        }
    }
}
