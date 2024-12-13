using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Dapper;
using SistemaGestionReserva.Models;

namespace SistemaGestionReserva.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly IDbConnection _connection;

        public ReservaRepository() => _connection = DbConnectionFactory.GetConnection();

        public async Task<List<Reserva>> ConsultarReservas(int? salaId = null, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            var parameters = new
            {
                SalaId = salaId,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin
            };

            return (await _connection.QueryAsync<Reserva>("sp_ConsultarReservas", parameters, commandType: CommandType.StoredProcedure)).ToList();
        }

        public async Task<int> EditarReserva(Reserva reserva)
        {
            var parameters = new
            {
                ReservaId = reserva.Id,
                SalaId = reserva.SalaId,
                FechaReserva = reserva.FechaReserva,
                Usuario = reserva.Usuario,
            };

            return await _connection.ExecuteScalarAsync<int>("sp_EditarReserva", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> EliminarReserva(int reservaId)
        {
            var parameters = new { ReservaId = reservaId };
            var result = await _connection.ExecuteAsync("sp_EliminarReserva", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<int> InsertReserva(Reserva reserva)
        {
            var parameters = new
            {
                SalaId = reserva.SalaId,
                FechaReserva = reserva.FechaReserva,
                usuario = reserva.Usuario
            };

            return await _connection.ExecuteScalarAsync<int>("sp_InsertarReserva", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}