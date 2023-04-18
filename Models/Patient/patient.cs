namespace hospital_frontend_core.Models;

public class patient {
    public int PatientID { get; set; }
    public String FName { get; set; }
    public String MInit { get; set; }
    public String LName { get; set; }
    public String Name => MInit == String.Empty ? FName + " " + MInit + LName : FName + " " + MInit + " " + LName;
    public DateTime BirthDate { get; set; }
    public char Sex { get; set; }
    public String ContactNo { get; set; }
    public IList<doctor> PatientDoctors { get; set; }

    public patient() {
        FName = String.Empty;
        MInit = String.Empty;
        LName = String.Empty;
        ContactNo = String.Empty;
        PatientDoctors = new List<doctor>();
    }

}