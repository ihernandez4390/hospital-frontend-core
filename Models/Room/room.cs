namespace hospital_frontend_core.Models;

public class room {
    public int RoomNo { get; set; }
    public int DeptID { get; set; }
    public department Dept { get; set; }

    public room() {
        Dept = new();
    }
}