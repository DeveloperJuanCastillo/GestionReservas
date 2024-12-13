using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionReserva.Models;

namespace SistemaGestionReserva.Repositories
{
    public interface ISalaRepository
    {
        Task<int> InsertarSala(Sala reserva);
        Task<int> EditarSala(Sala reserva);
        Task<bool> EliminarSala(int id);
        Task<List<Sala>> ListarSalas();
    }
}
