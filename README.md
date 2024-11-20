Claims Management System 
ReadMe.File

The Claims Management System is a WPF-based desktop application designed to streamline the submission, 
verification, approval, and management of claims submitted by lecturers. The application provides an intuitive 
user interface, role-specific functionalities, and analytical tools to efficiently handle claims.

Features:

1. Claim Submission
Lecturers can submit claims with details such as:
Hours worked
Hourly rate
Additional notes
The system calculates the total payment based on the entered details.

2. Claim Verification
Academic managers can view, approve, or reject pending claims.
Approved claims are updated in real-time, and rejected claims are flagged.

3. HR Tools
Search claims by Claim ID.
Generate detailed claim reports.
View, clear, or delete claims.

4. Visualization
Analytical tools using OxyPlot to visualize claims by total payment or lecturer-wise breakdown.
Bar chart displays claims data for better insights.
Prerequisites
Before running the application, ensure the following are installed on your system:

.NET Framework 4.8+
Visual Studio (with WPF Desktop Development workload)
OxyPlot Library
Add OxyPlot to your project via NuGet:
mathematica

Install-Package OxyPlot.Wpf
How to Run the Application
Clone the repository or download the project files.


git clone https://github.com/your-repo/claims-management-system.git
Open the solution file (ClaimsManagementSystem.sln) in Visual Studio.
Restore NuGet packages if prompted.
Build the solution using Ctrl + Shift + B.
Start the application by pressing F5 or using the "Start Debugging" option in Visual Studio.

Navigation and Usage:

1. Main Window
Select one of the following:
Submit Lecturer Claim: Opens the claim submission form.
Verify Claims: Opens the claims verification dashboard.

2. Claim Submission
Fill in the lecturer details, hours worked, and hourly rate.
Add any relevant notes.
Submit the claim to add it to the claims database.

3. Academic Manager Window
View all submitted claims.
Approve pending claims with a single click.
Analyze claims using the Claims Overview bar chart.

4. HR Window
Search claims using Claim ID.
View claim details or generate reports for specific claims.
Clear single or all claims from the list.
Navigate to the Academic Manager Window.

File Structure:

Main Application Files

MainWindow.xaml: Main navigation window.

ClaimSubmission.xaml: UI for claim submission.

AcademicManagerWindow.xaml: Manager dashboard.

HRWindow.xaml: HR tools and claim search.

Logic Files:

Claim.cs: Defines the Claim model and calculation logic.
MainWindow.xaml.cs: Handles navigation logic.

ClaimSubmission.xaml.cs: Processes claim submissions.
AcademicManagerWindow.xaml.cs: Manages claim approvals and analytics.

HRWindow.xaml.cs: Provides HR functionalities like claim search and report generation.

Unit Tests:
ClaimTests.cs: Unit tests for claim calculation logic.

Future Enhancements:
Role-based authentication for different user types (Lecturer, Manager, HR).
Add filtering and sorting in the claims list.
Export claims data to CSV or PDF.
Integration with a database for persistent data storage.
