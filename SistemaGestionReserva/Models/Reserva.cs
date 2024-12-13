using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGestionReserva.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Usuario { get; set; }
    }
}