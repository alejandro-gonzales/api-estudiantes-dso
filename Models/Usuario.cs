using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEstudiantesV2.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public int personaId { get; set; }
        public Persona persona { get; set; }
        public int tipoUsuarioId { get; set; }
        public TipoUsuario tipoUsuario { get; set; }
        public string correo { get; set; }
        public string pass { get; set; }
        public bool estado { get; set; }
    }
}
