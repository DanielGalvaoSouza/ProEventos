using System;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.API.Models
{
    public class Auditorios
    {
        [Key]
        public int IdAuditorio { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string qdtAssentos { get; set; }
        public bool possuiOnibusParaTransporte { get; set; }
    }
}