namespace hospital_frontend_core.Models;

public class payment {
    public int payment_no { get; set; }
    public decimal payment_amount { get; set; }
    public String payment_type { get; set; }
    public int invoice_no => this.invoice.invoice_no;
    public invoice invoice { get; set; }

    public payment() {
        payment_type = String.Empty;
        invoice = new();
    }
}