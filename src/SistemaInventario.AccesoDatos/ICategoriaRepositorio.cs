using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    public interface ICategoriaRepositorio : IRepositorio<Categoria> { }
}

/// <summary>Dejo todas las interfaces solas en su propio archivo porque la clase menciona un archivo por clase
/// no estoy seguro si aplica tambien para las clases pero por si acaso</summary>