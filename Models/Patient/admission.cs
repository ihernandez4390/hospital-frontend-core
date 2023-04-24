namespace hospital_frontend_core.Models;

public class admission : history {
    public DateTime AdmissionDate { get; set; }
    public DateTime? DischargeDate { get; set; }
    public int AssignedBed { get; set; }

    public admission() {
    }
}