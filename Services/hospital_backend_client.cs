using hospital_frontend_core.Models;

namespace hospital_frontend_core.Services;

public class hospital_backend_client {
    private String hospital_backend_endpoint;
    private HttpClient _client = new HttpClient();

    public hospital_backend_client(IConfiguration config) {
        hospital_backend_endpoint = config["hospital_backend_endpoint"];
        _client.BaseAddress = new Uri(hospital_backend_endpoint);
    }

    public async Task<Boolean> Login(credential credential) {
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/login", credential);
        
        return response.IsSuccessStatusCode;
    }

    public async Task<Boolean> Logout() {
        HttpResponseMessage response = await _client.PostAsync("api/login/logout", null);

        return response.IsSuccessStatusCode;
    }

    public async Task<Boolean> CreatePatient(patient model) {
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/patients/create", model);

        return response.IsSuccessStatusCode;
    }

    public async Task<Boolean> UpdatePatient(patient model) {
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/patients/update", model);

        return response.IsSuccessStatusCode;
    }

    public async Task<Boolean> DeletePatient(patient model) {
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/patients/delete", model);

        return response.IsSuccessStatusCode;
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

        return _patient;
    }

    public async Task<patient?> GetPatientWithDetails(int id) {
        var _patient = await GetPatient(id);

        if (_patient is not null) {
            _patient.PatientDoctors = await GetPatientDoctors(_patient.PatientID);
            _patient.Admissions = await GetAdmissions(_patient.PatientID);
            _patient.Appointments = await GetAppointments(_patient.PatientID);
        }
        
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

    public async Task<List<admission>> GetAdmissions() {
        var admissions = new List<admission>();

        HttpResponseMessage response = await _client.GetAsync("api/history/admissions");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<admission[]>();

            if (content is not null) {
                foreach (var admission in content) {
                    var patient = await GetPatient(admission.PatientID);

                    if (patient is not null) {
                        admission.Patient = patient;
                        admissions.Add(admission);
                    }
                }
            }
        }

        return admissions;
    }

    public async Task<List<admission>> GetCurrentAdmissions() {
        var admissions = new List<admission>();

        HttpResponseMessage response = await _client.GetAsync("api/history/currentadmissions");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<admission[]>();

            if (content is not null) {
                foreach (var admission in content) {
                    var patient = await GetPatient(admission.PatientID);

                    if (patient is not null) {
                        admission.Patient = patient;
                        admissions.Add(admission);
                    }
                }
            }
        }

        return admissions;
    }

    public async Task<List<admission>> GetAdmissions(int patientId) {
        var admissions = new List<admission>();

        HttpResponseMessage response = await _client.GetAsync($"api/patients/{patientId}/admissions");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<admission[]>();

            if (content is not null) {
                foreach (var admission in content)
                    admissions.Add(admission);
            }
        }

        return admissions;
    }

    public async Task<admission?> GetAdmission(int id) {
        var _admission = (await GetAdmissions()).SingleOrDefault(a => a.HistoryID == id);

        return _admission;
    }

    public async Task<Boolean> Admit(admission model) {
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/history/admit", model);

        return response.IsSuccessStatusCode;
    }

    public async Task<Boolean> Discharge(admission model) {
        HttpResponseMessage response = await _client.PostAsJsonAsync("api/history/discharge", model);

        return response.IsSuccessStatusCode;
    }

    public async Task<List<appointment>> GetAppointments() {
        var appointments = new List<appointment>();

        HttpResponseMessage response = await _client.GetAsync($"api/history/appointments");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<appointment[]>();

            if (content is not null) {
                foreach (var appointment in content)
                {
                    var patient = await GetPatient(appointment.PatientID);

                    if (patient is not null) {
                        appointment.Patient = patient;
                        appointments.Add(appointment);
                    }
                }
            }
        }

        return appointments;
    }

    public async Task<List<appointment>> GetAppointments(int patientId) {
        var appointments = new List<appointment>();

        HttpResponseMessage response = await _client.GetAsync($"api/patients/{patientId}/appointments");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<appointment[]>();

            if (content is not null) {
                foreach (var appointment in content)
                    appointments.Add(appointment);
            }
        }

        return appointments;
    }

    public async Task<List<invoice>> GetInvoices() {
        var invoices = new List<invoice>();

        HttpResponseMessage response = await _client.GetAsync($"api/patients/invoices");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<invoice[]>();

            if (content is not null) {
                foreach (var invoice in content)
                    invoices.Add(invoice);
            }
        }

        return invoices;
    }

    public async Task<List<invoice>> GetInvoices(int patientId) {
        var invoices = new List<invoice>();

        HttpResponseMessage response = await _client.GetAsync($"api/patients/{patientId}/invoices");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<invoice[]>();

            if (content is not null) {
                foreach (var invoice in content)
                    invoices.Add(invoice);
            }
        }

        return invoices;
    }

    public async Task<List<department>> GetDepartments() {
        var departments = new List<department>();

        HttpResponseMessage response = await _client.GetAsync($"api/departments/");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<department[]>();

            if (content is not null) {
                foreach (var dept in content)
                    departments.Add(dept);
            }
        }

        return departments;
    }

    public async Task<department?> GetDepartment(int id) {
        var _dept = (await GetDepartments()).SingleOrDefault(d => d.DeptID == id);

        return _dept;
    }

    public async Task<List<room>> GetRooms() {
        var rooms = new List<room>();

        HttpResponseMessage response = await _client.GetAsync($"api/departments/rooms");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<room[]>();

            if (content is not null) {
                foreach (var room in content) {
                    var dept = await GetDepartment(room.DeptID);

                    if (dept is not null) {
                        room.Dept = dept;
                        rooms.Add(room);
                    }
                }
            }
        }

        return rooms;
    }

    public async Task<room?> GetRoom(int id) {
        var _room = (await GetRooms()).SingleOrDefault(r => r.RoomNo == id);

        return _room;
    }

    public async Task<List<room_bed>> GetBeds() {
        var beds = new List<room_bed>();

        HttpResponseMessage response = await _client.GetAsync("api/departments/beds");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<room_bed[]>();

            if (content is not null) {
                foreach (var bed in content) {
                    var room = await GetRoom(bed.RoomNo);

                    if (room is not null) {
                        bed.Room = room;
                        beds.Add(bed);
                    }
                }
            }
        }

        return beds;
    }

    public async Task<List<room_bed>> GetAvailableBeds() {
        var beds = new List<room_bed>();

        HttpResponseMessage response = await _client.GetAsync("api/departments/availablebeds");

        if (response.IsSuccessStatusCode) {
            var content = await response.Content.ReadFromJsonAsync<room_bed[]>();

            if (content is not null) {
                foreach (var bed in content) {
                    var room = await GetRoom(bed.RoomNo);

                    if (room is not null) {
                        bed.Room = room;
                        beds.Add(bed);
                    }
                }
            }
        }

        return beds;
    }
}