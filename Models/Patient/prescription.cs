namespace hospital_frontend_core.Models;

public class prescription : history {
    public int prescribing_doctor_id => prescribing_doctor.EmployeeID;
    public doctor prescribing_doctor { get; set; }
    public int fulfilled_by_id => fulfilled_by.EmployeeID;
    public pharmacist fulfilled_by { get; set; }
    public String drug_name { get; set; }
    public int quantity { get; set; }

    public prescription() {
        prescribing_doctor = new();
        fulfilled_by = new();
        drug_name = String.Empty;
    }
}