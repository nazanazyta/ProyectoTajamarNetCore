﻿using Microsoft.AspNetCore.Mvc;
using ProyectoTajamarNetCore.Extensions;
using ProyectoTajamarNetCore.Models;
using ProyectoTajamarNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTajamarNetCore.Controllers
{
    public class PerrosController : Controller
    {
        IRepositoryTheGuauHouse Repo;

        public PerrosController(IRepositoryTheGuauHouse repo)
        {
            this.Repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Insertar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(Perro perro)
        {
            Perro p = this.Repo.InsertarPerro
                (perro, HttpContext.Session.GetObject<UsuarioSession>("usuario").Id);
            return View(p);
        }
    }
}
