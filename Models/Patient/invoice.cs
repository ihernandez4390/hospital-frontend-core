namespace hospital_frontend_core.Models;

public class invoice {
    public int invoice_no { get; set; }
    public DateTime invoice_date { get; set; }
    public decimal balance { get; set; }
    public int patient_id => this.patient.PatientID;
    public patient patient { get; set; }
    public int generated_by_id => generated_by.EmployeeID;
    public staff generated_by { get; set; }

    public invoice() {
        patient = new();
        generated_by = new();
    }
}