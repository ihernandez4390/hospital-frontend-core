using System.ComponentModel;

namespace hospital_frontend_core.Models;

public class history {
    [DisplayName("History ID")]
    public int HistoryID { get; set; }

    [DisplayName("Patient ID")]
    public int PatientID {get; set; }

    [DisplayName("History Creation Date")]
    public DateTime CreationDate { get; set; }

    public patient Patient { get; set; }

    public history() {
        Patient = new patient();
    }
}