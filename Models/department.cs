namespace hospital_frontend_core.Models;

public class department {
    public int dept_id { get; set; }
    public String dept_name { get; set; }

    public department() {
        dept_name = String.Empty;
    }
}
