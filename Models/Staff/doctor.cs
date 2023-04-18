namespace hospital_frontend_core.Models;

public class doctor : staff {
    public int LicenseNo { get; set; }
    public IList<patient> DoctorPatients { get; set; }

    public doctor() {
        DoctorPatients = new List<patient>();
    }
}