using System;

public class Claim
{
    public int ClaimId { get; set; }
    public string LecturerName { get; set; }

    private int _hoursWorked;
    public int HoursWorked
    {
        get { return _hoursWorked; }
        set
        {
            if (value < 0) throw new ArgumentException("Hours worked cannot be negative.");
            _hoursWorked = value;
        }
    }

    private decimal _hourlyRate;
    public decimal HourlyRate
    {
        get { return _hourlyRate; }
        set
        {
            if (value < 0) throw new ArgumentException("Hourly rate cannot be negative.");
            _hourlyRate = value;
        }
    }

    public string AdditionalNotes { get; set; }

    public string Status { get; set; }

    public string SupportingDocument { get; set; }

    // Method for calculating total claim amount
    public decimal CalculateClaimAmount()
    {
        return HoursWorked * HourlyRate;
    }
}
