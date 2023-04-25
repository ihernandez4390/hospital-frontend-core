namespace hospital_frontend_core.Models;

public class room_bed {
    public String Name => $"Room #{RoomNo} - Bed #{BedNo}";
    public int BedNo { get; set; }
    public int RoomNo { get; set; }
    public room Room { get; set; }

    public room_bed() {
        this.Room = new();
    }
}