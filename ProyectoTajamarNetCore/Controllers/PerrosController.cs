using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Controllers
{
    public class PerrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Insertar()
        //{

        //}

        //[HttpPost]
        //public IActionResult Insertar(Perro perro)
        //{

        //}
    }
}
