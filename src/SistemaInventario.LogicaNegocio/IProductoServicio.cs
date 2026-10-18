using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    /// <summary>
    /// Contrato de negocio para la gestión de Productos y consultas LINQ.
    /// </summary>
    public interface IProductoServicio
    {
        /// <summary>Devuelve todos los productos</summary>
        List<Producto> Listar();

        /// <summary>Devuelve solo los productos activos</summary>
        List<Producto> ListarActivos();

        /// <summary>Obtiene un producto por id</summary>
        Producto ObtenerPorId(int id);

        /// <summary>Valida y guarda un producto</summary>
        ResultadoOperacion<Producto> Guardar(Producto producto);

        /// <summary>Elimina logicamente un producto</summary>
        ResultadoOperacion<Producto> Eliminar(int id);

        /// <summary>Restaura un producto previamente eliminado</summary>
        ResultadoOperacion<Producto> Restaurar(int id);

        object ProductosPorCategoria();
        object Top5Suplidores();
        List<Producto> ProductosPorCategoriaYRango(int categoriaId, decimal min, decimal max);
        List<Producto> Buscar(string texto);
        object PromedioPorCategoria();
    }
}
