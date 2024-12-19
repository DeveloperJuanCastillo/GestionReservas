using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SistemaGestionReserva.Models;
using SistemaGestionReserva.Repositories;

namespace SistemaGestionReserva.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ReservaRepository _reservaRepo;
        private readonly SalaRepository _salasRepo;

        public ReservasController()
        {
            _reservaRepo = new ReservaRepository();
            _salasRepo = new SalaRepository();
        }

        public async Task<ActionResult> Inicio()
        {
            var reservas = await _reservaRepo.ConsultarReservas();
            return View(reservas);
        }

        public async Task<ActionResult> Crear()
        {
            var salas = await _salasRepo.ListarSalas();
            var salasSelectList = new SelectList(salas, "Id", "Nombre");
            ViewBag.Salas = salasSelectList;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Reserva reserva)
        {
            var id = await _reservaRepo.InsertReserva(reserva);
            return RedirectToAction("Inicio");
        }
    }
}