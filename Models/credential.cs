namespace hospital_frontend_core.Models;

public class credential {
    public String username { get; set; }
    public String password { get; set; }

    public credential() {
        username = String.Empty;
        password = String.Empty;
    }
}