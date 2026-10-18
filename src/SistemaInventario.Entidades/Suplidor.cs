using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.Entidades
{
    public class Suplidor : EntidadBase
    {
        public string NombreEmpresa { get; set; }
        public string NombreContacto { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string SitioWeb { get; set; }
    }
}
