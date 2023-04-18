namespace hospital_frontend_core.Models;

public class exam {
    public int exam_id { get; set; }
    public String exam_name { get; set; }

    public exam() {
        exam_name = String.Empty;
    }
}