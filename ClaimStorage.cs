using System.Collections.Generic;
using System.Text;

public static class ClaimStorage
{
    // Example list of claims (minimum 10 claims)
    public static List<Claim> Claims = new List<Claim>
    {
        new Claim { ClaimId = 1, LecturerName = "John Doe", HoursWorked = 40, HourlyRate = 25.0m, Status = "Pending", AdditionalNotes = "Pending review" },
        new Claim { ClaimId = 2, LecturerName = "Jane Smith", HoursWorked = 35, HourlyRate = 30.0m, Status = "Approved", AdditionalNotes = "Approved by HR" },
        new Claim { ClaimId = 3, LecturerName = "Michael Johnson", HoursWorked = 20, HourlyRate = 50.0m, Status = "Rejected", AdditionalNotes = "Insufficient documentation" },
        new Claim { ClaimId = 4, LecturerName = "Mary Lee", HoursWorked = 45, HourlyRate = 20.0m, Status = "Approved", AdditionalNotes = "All documents verified" },
        new Claim { ClaimId = 5, LecturerName = "James Brown", HoursWorked = 25, HourlyRate = 15.0m, Status = "Pending", AdditionalNotes = "Pending supervisor approval" },
        new Claim { ClaimId = 6, LecturerName = "Patricia Green", HoursWorked = 30, HourlyRate = 40.0m, Status = "Approved", AdditionalNotes = "Completed extra hours" },
        new Claim { ClaimId = 7, LecturerName = "Robert White", HoursWorked = 18, HourlyRate = 35.0m, Status = "Rejected", AdditionalNotes = "Hours not matching records" },
        new Claim { ClaimId = 8, LecturerName = "Linda Taylor", HoursWorked = 50, HourlyRate = 22.0m, Status = "Approved", AdditionalNotes = "Excellent performance" },
        new Claim { ClaimId = 9, LecturerName = "William Harris", HoursWorked = 40, HourlyRate = 25.0m, Status = "Pending", AdditionalNotes = "Pending final check" },
        new Claim { ClaimId = 10, LecturerName = "Elizabeth Clark", HoursWorked = 32, HourlyRate = 28.0m, Status = "Approved", AdditionalNotes = "Verified by manager" }
    };

    // Method to get claims by ClaimId
    public static Claim GetClaimById(int claimId)
    {
        return Claims.Find(c => c.ClaimId == claimId);
    }

    // Example of generating a report
    public static string GenerateReport()
    {
        var report = new StringBuilder();
        foreach (var claim in Claims)
        {
            report.AppendLine($"Claim ID: {claim.ClaimId}, Lecturer: {claim.LecturerName}, Hours Worked: {claim.HoursWorked}, Hourly Rate: {claim.HourlyRate:C}, Status: {claim.Status}, Notes: {claim.AdditionalNotes}");
        }
        return report.ToString();
    }
}
