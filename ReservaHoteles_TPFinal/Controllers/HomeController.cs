﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservaHoteles_TPFinal.Context;
using ReservaHoteles_TPFinal.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace ReservaHoteles_TPFinal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Hotel_context context = new Hotel_context();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ObtenerHabitaciones(FiltroReserva datos)
        {

            DatosReserva_aux aux = new DatosReserva_aux();
            aux.habitacionesDisponibles = context.Habitaciones.Where(h => h.capacidad >= datos.cantidadPersonas).ToList();

            aux.reservaAux.fechaIngreso = datos.fechaInicio;
            aux.reservaAux.fechaEgreso = datos.fechaFinal;

            return View("Reservar", aux);
        }

        [HttpPost]
        public bool AgregarReserva(DatosReserva_aux datos)
        {
            return false;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}