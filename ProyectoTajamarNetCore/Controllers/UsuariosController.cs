using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarNetCore.Extensions;
using ProyectoTajamarNetCore.Models;
using ProyectoTajamarNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProyectoTajamarNetCore.Helpers.Enumerations;

namespace ProyectoTajamarNetCore.Controllers
{
    public class UsuariosController : Controller
    {
        ISession Session => HttpContext.Session;
        IRepositoryTheGuauHouse Repo;

        public UsuariosController(IRepositoryTheGuauHouse repo)
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
                UsuarioSession usersession = new UsuarioSession();
                usersession.Rol = Roles.Usuario;
                usersession.UserName = username;
                Session.SetObject("usuario", usersession);
            }
            else
            {
                ViewData["mensaje"] = "Ese usuario ya existe";
            }
            return RedirectToAction("Index", "Home");
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
                UsuarioSession usersession = new UsuarioSession();
                usersession.Rol = (Roles)user.Rol;
                usersession.UserName = user.UserName;
                Session.SetObject("usuario", usersession);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
