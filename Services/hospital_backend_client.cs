using hospital_frontend_core.Models;

namespace hospital_frontend_core.Services;

public class hospital_backend_client {
    private String hospital_backend_endpoint;
    private HttpClient _client = new HttpClient();

    public hospital_backend_client(IConfiguration config) {
        hospital_backend_endpoint = config["hospital_backend_endpoint"];
        _client.BaseAddress = new Uri(hospital_backend_endpoint);
    }

    public async Task<IList<patient>> GetPatients() {
        var patients = new List<patient>();

        HttpResponseMessage response = await _client.GetAsync("api/patients");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<patient[]>();

            if (content is not null) {
                foreach (var patient in content) 
                    patients.Add(patient);
            }
        }
            
        return patients;
    }

    public async Task<patient?> GetPatient(int id) {
        var _patient = (await GetPatients()).SingleOrDefault(p => p.PatientID == id);

        if (_patient is not null)
            _patient.PatientDoctors = await GetPatientDoctors(_patient.PatientID);

        return _patient;       
    }

    public async Task<List<doctor>> GetDoctors() {
        var doctors = new List<doctor>();

        HttpResponseMessage response = await _client.GetAsync("api/staff/doctors");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<doctor[]>();

            if (content is not null) {
                foreach (var doctor in content)
                    doctors.Add(doctor);
            }
        }

        return doctors;
    }

    public async Task<doctor?> GetDoctor(int id) {
        var _doctor = (await GetDoctors()).SingleOrDefault(d => d.EmployeeID == id);

        if (_doctor is not null)
            _doctor.DoctorPatients = await GetDoctorPatients(_doctor.EmployeeID);

        return _doctor;
    }

    public async Task<List<doctor>> GetPatientDoctors(int id) {
        var doctors = new List<doctor>();

        HttpResponseMessage response = await _client.GetAsync($"api/patients/{id}/doctors");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<doctor[]>();

            if (content is not null) {
                foreach (var doctor in content) {
                    doctors.Add(doctor);
                }
            } 
        }

        return doctors;
    }

    public async Task<List<patient>> GetDoctorPatients(int id) {
        var patients = new List<patient>();

        HttpResponseMessage response = await _client.GetAsync($"api/staff/doctors/{id}/patients");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<patient[]>();

            if (content is not null) {
                foreach (var patient in content) 
                    patients.Add(patient);
            }
        }
            
        return patients;
    }
}