using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Entidades
{
    public abstract class EntidadBase
    {
        public int Id { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
    }

}
