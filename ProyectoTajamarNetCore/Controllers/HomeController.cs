using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarNetCore.Models;
using ProyectoTajamarNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Controllers
{
    public class HomeController : Controller
    {
        //IRepositoryTheGuauHouse Repo;

        //public HomeController(IRepositoryTheGuauHouse repo)
        //{
        //    this.Repo = repo;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Link()
        {
            return View();
        }

        //public IActionResult Usuarios()
        //{
        //    List<Usuario> usuarios = this.Repo.GetUsuarios();
        //    return View(usuarios);
        //}
    }
}
