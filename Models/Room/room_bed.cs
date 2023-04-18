namespace hospital_frontend_core.Models;

public class room_bed {
    public int bed_no { get; set; }
    public int room_no => this.room.room_no;
    public room room { get; set; }

    public room_bed() {
        this.room = new();
    }
}