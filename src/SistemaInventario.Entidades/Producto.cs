using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Entidades
{
    public class Producto : EntidadBase
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int CategoriaId { get; set; }
        public int SuplidorId { get; set; }
    }
}
