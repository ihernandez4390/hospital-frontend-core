namespace hospital_frontend_core.Models;

public class exam_result : history {
    public int exam_id => this.exam.exam_id;
    public exam exam { get; set; }
    public int doctor_id => this.doctor.EmployeeID;
    public doctor doctor { get; set; }
    public String notes { get; set; }

    public exam_result() {
        exam = new();
        doctor = new();
        notes = String.Empty;
    }
}