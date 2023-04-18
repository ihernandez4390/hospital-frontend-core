namespace hospital_frontend_core.Models;

public class staff {
    public int EmployeeID { get; set; }
    public String FName { get; set; }
    public String MInit { get; set; }
    public String LName { get; set; }
    public String Name => MInit == String.Empty ? FName + " " + MInit + LName : FName + " " + MInit + " " + LName;
    public int DeptID { get; set; }
    public department Dept { get; set; }
    
    public staff() {
        FName = String.Empty;
        MInit = String.Empty;
        LName = String.Empty;
        Dept = new();
    }
}