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
        var model = await base.client.GetPatient(id);

        return View(model);
    }

    [HttpPost]
    public IActionResult PatientDetails(patient model) {
        throw new NotImplementedException();
    }

    #endregion

    #region admission
    
    public async Task<IActionResult> Admissions() {
        var model = await base.client.GetAdmissions();

        return View(model);
    }

    public async Task<IActionResult> Admissions(int patientId) {
        var model = await base.client.GetAdmissions(patientId);

        return View(model);
    }

    public IActionResult AdmissionDetails(int patientId, int id) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult AdmissionDetails(admission model) {
        throw new NotImplementedException();
    }

    #endregion

    #region appointment

    public IActionResult Appointments(int patientId) {
        throw new NotImplementedException();
    }

    public IActionResult AppointmentDetails(int patientId, int id) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult AppointmentDetails(appointment model) {
        throw new NotImplementedException();
    }

    #endregion

    #region invoice

    public IActionResult Invoices(int patientId) {
        throw new NotImplementedException();
    }

    public IActionResult InvoiceDetails(int patientId, int id) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult InvoiceDetails(invoice model) {
        throw new NotImplementedException();
    }

    #endregion

    #region payment

    public IActionResult Payments(int patientId) {
        throw new NotImplementedException();
    }

    public IActionResult PaymentDetails(int patientId, int id) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult PaymentDetails(payment model) {
        throw new NotImplementedException();
    }

    #endregion
}