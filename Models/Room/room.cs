namespace hospital_frontend_core.Models;

public class room {
    public int room_no { get; set; }
    public int dept_id => dept.dept_id;
    public department dept { get; set; }

    public room() {
        dept = new();
    }
}