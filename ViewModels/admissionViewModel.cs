using hospital_frontend_core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace hospital_frontend_core.ViewModels;

public class admissionViewModel {
    public admission Admission { get; set; }
    public IList<patient> AvailablePatients { get; set; }
    public List<SelectListItem> SelectAvailablePatients => AvailablePatients.Select(p => new SelectListItem() { Value = p.PatientID.ToString(), Text = p.Name }).ToList();
    public IList<room_bed> AvailableBeds { get; set; }
    public List<SelectListItem> SelectAvailableBeds => AvailableBeds.Select(b => new SelectListItem() { Value = b.BedNo.ToString(), Text = b.Name }).ToList();

    [DisplayName("Patient")]
    public String SelectedPatientId { get; set; }

    [DisplayName("Assigned Bed")]
    public String SelectedBedId { get; set; }

    public admissionViewModel() {
        Admission = new admission();
        AvailablePatients = new List<patient>();
        AvailableBeds = new List<room_bed>();
        SelectedPatientId = String.Empty;
        SelectedBedId = String.Empty;
    }
}