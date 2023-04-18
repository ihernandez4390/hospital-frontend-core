namespace hospital_frontend_core.Models;

public class history {
    public int history_id { get; set; }
    public int patient_id => this.patient.PatientID;
    public patient patient { get; set; }
    public DateTime creation_date { get; set; }

    public history() {
        patient = new();
    }
}