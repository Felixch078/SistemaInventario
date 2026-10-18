using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    /// <summary>
    /// Contrato de negocio para la gestión de Suplidores.
    /// </summary>
    public interface ISuplidorServicio
    {
        /// <summary>Devuelve todos los suplidores.</summary>
        List<Suplidor> Listar();

        /// <summary>Devuelve solo los suplidores activos.</summary>
        List<Suplidor> ListarActivos();

        /// <summary>Obtiene un suplidor por id.</summary>
        Suplidor ObtenerPorId(int id);

        /// <summary>Valida y guarda un suplidor.</summary>
        ResultadoOperacion<Suplidor> Guardar(Suplidor suplidor);

        /// <summary>Elimina logicamente un suplidor</summary>
        ResultadoOperacion<Suplidor> Eliminar(int id);

        /// <summary>Restaura un suplidor previamente eliminado</summary>
        ResultadoOperacion<Suplidor> Restaurar(int id);
    }
}
