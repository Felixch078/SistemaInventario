using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Entidades
{
    public class Categoria : EntidadBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<string> RutasFotos { get; set; } = new List<string>();
    }
}
