namespace hospital_frontend_core.Models;

public class patient_room : room {
    public int nurse_id => this.nurse.EmployeeID;
    public nurse nurse { get; set; }

    public patient_room() {
        this.nurse = new();
    }
}