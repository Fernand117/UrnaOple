using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Urna.COMMON.DTOS.Autenticacion
{
    public class UsuarioRequest
    {
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
