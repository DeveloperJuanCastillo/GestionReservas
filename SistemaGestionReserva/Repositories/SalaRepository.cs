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
    public class SalaRepository : ISalaRepository
    {
        private readonly IDbConnection _connection;

        public SalaRepository() => _connection = DbConnectionFactory.GetConnection();

        public async Task<int> EditarSala(Sala sala)
        {
            return await _connection.ExecuteScalarAsync<int>("sp_EditarSala", sala, commandType: CommandType.StoredProcedure);
        }

        public async Task<bool> EliminarSala(int id)
        {
            var parameters = new { Id = id };
            var result = await _connection.ExecuteAsync("sp_EliminarSala", parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<int> InsertarSala(Sala sala)
        {
            var parameters = new
            {
                Nombre = sala.Nombre,
                Capacidad = sala.Capacidad,
                Disponibilidad = sala.Disponibilidad
            };

            return await _connection.ExecuteScalarAsync<int>("sp_InsertarSala", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Sala>> ListarSalas()
        {
            return (await _connection.QueryAsync<Sala>("sp_ListarSalas", commandType: CommandType.StoredProcedure)).ToList();
        }

        public async Task<Sala> ObtenerSalaPorId(int id)
        {
            var parameters = new { Id = id };
            return await _connection.QueryFirstAsync<Sala>("sp_ObtenerSalaPorId", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}