using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionReserva.Models;

namespace SistemaGestionReserva.Repositories
{
    public interface IReservaRepository
    {
        Task<int> InsertReserva(Reserva reserva);
        Task<int> EditarReserva(Reserva reserva);
        Task<bool> EliminarReserva(int reservaId);
        Task<List<Reserva>> ConsultarReservas(int? salaId = null, DateTime? fechaInicio = null, DateTime? fechaFin = null);
    }
}
