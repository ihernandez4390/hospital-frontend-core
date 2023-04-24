using Microsoft.AspNetCore.Mvc;
using hospital_frontend_core.Models;
using hospital_frontend_core.Services;

namespace hospital_frontend_core.Controllers;

public class PatientController : BaseController {
    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger, hospital_backend_client _client) : base(_client) {
        _logger = logger;
    }

    #region patient

    public async Task<IActionResult> Patients() {
        var model = await base.client.GetPatients();

        return View(model);
    }

    public async Task<IActionResult> PatientDetails(int id) {
        var model = await base.client.GetPatientWithDetails(id);

        return View(model);
    }

    public async Task<IActionResult> EditPatient(int id) {
        var model = await base.client.GetPatientWithDetails(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> EditPatient(patient model)
    {
        var result = await base.client.UpdatePatient(model);
        
        return RedirectToAction("Patients");
    }

    public IActionResult AddPatient() {
        var model = new patient();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddPatient(patient model)
    {
        var result = await base.client.CreatePatient(model);
        
        return RedirectToAction("Patients");
    }

    public async Task<IActionResult> DeletePatient(int id) 
    {
        var model = await base.client.GetPatientWithDetails(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeletePatient(patient model) 
    {
        var result = await base.client.DeletePatient(model);

        return RedirectToAction("Patients");
    }

    #endregion

    #region admission
    
    public async Task<IActionResult> Admissions() {
        var model = await base.client.GetCurrentAdmissions();

        return View(model);
    }

    public async Task<IActionResult> AdmissionDetails(int id) {
        var model = await base.client.GetAdmission(id);

        return View(model);
    }

    public async Task<IActionResult> DischargePatient(int id) {
        var model = await base.client.GetAdmission(id);

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DischargePatient(admission model) {
        model.DischargeDate = DateTime.Now;
        
        var result = await base.client.Discharge(model);

        return RedirectToAction("Admissions");
    }

    #endregion

    #region appointment

    public async Task<IActionResult> Appointments() {
        var model = await base.client.GetAppointments();

        return View(model);
    }

    public IActionResult AppointmentDetails(int id) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult AppointmentDetails(appointment model) {
        throw new NotImplementedException();
    }

    #endregion

    #region invoice

    public IActionResult Invoices() {
        throw new NotImplementedException();
    }

    public IActionResult InvoiceDetails(int id) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult InvoiceDetails(invoice model) {
        throw new NotImplementedException();
    }

    #endregion

    #region payment

    public IActionResult Payments() {
        throw new NotImplementedException();
    }

    public IActionResult PaymentDetails(int id) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult PaymentDetails(payment model) {
        throw new NotImplementedException();
    }

    #endregion
}