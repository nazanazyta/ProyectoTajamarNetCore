using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarNetCore.Models;
using ProyectoTajamarNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Controllers
{
    public class SesionController : Controller
    {
        IRepositoryTheGuauHouse Repo;

        public SesionController(IRepositoryTheGuauHouse repo)
        {
            this.Repo = repo;
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(String nombre, String username, String password)
        {
            if (this.Repo.GetUsuarioUsername(username) == null)
            {
                this.Repo.InsertarUsuario(nombre, username, password);
                ViewData["mensaje"] = "Datos almacenados";
            }
            else
            {
                ViewData["mensaje"] = "Ese usuario ya existe";
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(String username, String password)
        {
            Usuario user = this.Repo.Login(username, password);
            if (user == null)
            {
                ViewData["mensaje"] = "Usuario/Password no válid@";
            }
            else
            {
                ViewData["mensaje"] = "Éxito: " + user.UserName;
                //HttpContext.Session.Set("user", user.UserName);
            }
            return View();
        }
    }
}
