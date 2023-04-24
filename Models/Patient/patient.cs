using System.ComponentModel;

namespace hospital_frontend_core.Models;

public class patient {
    [DisplayName("Patient ID")]
    public int PatientID { get; set; }

    [DisplayName("Patient First Name")]
    public String FName { get; set; }

    [DisplayName("Patient Middle Initial")]
    public String MInit { get; set; }

    [DisplayName("Patient Last Name")]
    public String LName { get; set; }

    [DisplayName("Patient Name")]
    public String Name => MInit == String.Empty ? FName + " " + MInit + LName : FName + " " + MInit + " " + LName;

    [DisplayName("Patient BirthDate")]
    public DateTime BirthDate { get; set; }

    [DisplayName("Patient Sex")]
    public char Sex { get; set; }

    [DisplayName("Patient Contact #")]
    public String ContactNo { get; set; }

    public IList<doctor> PatientDoctors { get; set; }
    public IList<appointment> Appointments { get; set; }
    public IList<appointment> Past_Appointments => Appointments.Where(a => a.ApptDate < DateTime.Now.Date).ToList();
    public IList<appointment> Future_Appointments => Appointments.Where(a => a.ApptDate >= DateTime.Now.Date).ToList();
    public IList<admission> Admissions { get; set; }

    public patient() {
        FName = String.Empty;
        MInit = String.Empty;
        LName = String.Empty;
        ContactNo = String.Empty;
        PatientDoctors = new List<doctor>();
        Appointments = new List<appointment>();
        Admissions = new List<admission>();
    }

}