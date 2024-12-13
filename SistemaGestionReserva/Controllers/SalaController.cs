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
    public class SalaController : Controller
    {
        private readonly SalaRepository _salaRepo;

        public SalaController()
        {
            _salaRepo = new SalaRepository();
        }

        public async Task<ActionResult> Inicio()
        {
            var salas = await _salaRepo.ListarSalas();
            return View(salas);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Sala sala)
        {
            var id = await _salaRepo.InsertarSala(sala);
            return RedirectToAction("Detalles", new { id = id });
        }
        public async Task<ActionResult> Editar(int id)
        {
            var sala = await _salaRepo.ObtenerSalaPorId(id);
            return sala == null ? HttpNotFound() : (ActionResult)View(sala);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Sala sala)
        {
            await _salaRepo.EditarSala(sala);
            return RedirectToAction("Detalles", new { id = sala.Id });
        }

        public async Task<ActionResult> Eliminar(int id)
        {
            var sala = await _salaRepo.ObtenerSalaPorId(id);
            return sala == null ? HttpNotFound() : (ActionResult)View(sala);
        }

        [HttpPost]
        public async Task<ActionResult> Eliminar(Sala sala)
        {
            await _salaRepo.EliminarSala(sala.Id);
            return RedirectToAction("Inicio");
        }

        public async Task<ActionResult> Detalles(int id)
        {
            var sala = await _salaRepo.ObtenerSalaPorId(id);
            return sala == null ? HttpNotFound() : (ActionResult)View(sala);
        }

    }
}