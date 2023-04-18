namespace hospital_frontend_core.Models;

public class admission : history {
    public DateTime admission_date { get; set; }
    public DateTime discharge_date { get; set; }
    public int bed_no => bed.bed_no;
    public room_bed bed { get; set; }

    public admission() {
        bed = new();
    }
}