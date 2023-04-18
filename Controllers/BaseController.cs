using hospital_frontend_core.Services;
using Microsoft.AspNetCore.Mvc;

namespace hospital_frontend_core.Controllers;

public class BaseController : Controller {
    public hospital_backend_client client;

    public BaseController(hospital_backend_client backend_client) { 
        client = backend_client;
    }
}