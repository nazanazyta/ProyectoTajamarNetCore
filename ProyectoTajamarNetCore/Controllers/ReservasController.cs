using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarNetCore.Extensions;
using ProyectoTajamarNetCore.Models;
using ProyectoTajamarNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Controllers
{
    public class ReservasController : Controller
    {
        IRepositoryTheGuauHouse Repo;

        public ReservasController(IRepositoryTheGuauHouse repo)
        {
            this.Repo = repo;
        }

        public IActionResult Index()
        {
            //TRAER PERROS para el select
            return View();
        }

        [HttpPost]
        public IActionResult Index(Reserva reserva)
        {
            reserva.IdUsu = HttpContext.Session.GetObject<UsuarioSession>("usuario").Id;
            this.Repo.InsertarReserva(reserva);
            return RedirectToAction("Index", "Home");
        }
    }
}
