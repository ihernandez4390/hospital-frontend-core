namespace hospital_frontend_core.Models;

public class department {
    public int DeptID { get; set; }
    public String DName { get; set; }

    public department() {
        DName = String.Empty;
    }
}
