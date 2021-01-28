using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Controllers
{
    public class SesionController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
