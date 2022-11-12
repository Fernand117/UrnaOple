using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Urna.COMMON.DTOS.Autenticacion
{
    public class AutenticacionDTO
    {
        public string Token { get; set; }
        public DateTime Expiracion { get; set; }
    }
}
