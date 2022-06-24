using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Entities
{
    public class Lot
    {
        [Key]
        public int IdLot { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int Quantidade { get; set; }
        public int EventId { get; set; }
        public Events Event { get; set; }
    }
}
