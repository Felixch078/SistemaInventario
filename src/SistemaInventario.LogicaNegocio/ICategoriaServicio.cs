using SistemaInventario.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    public interface ICategoriaServicio
    {
        /// <summary>Devuelve todas las categorias</summary>
        List<Categoria> Listar();

        /// <summary>Devuelve solo las categorías activas</summary>
        List<Categoria> ListarActivos();

        /// <summary>Obtiene una categoria por id</summary>
        Categoria ObtenerPorId(int id);

        /// <summary>Valida y guarda una categoria</summary>
        ResultadoOperacion<Categoria> Guardar(Categoria categoria);

        /// <summary>Elimina lógicamente una categoria</summary>
        ResultadoOperacion<Categoria> Eliminar(int id);

        /// <summary>Restaura una categoria previamente eliminada</summary>
        ResultadoOperacion<Categoria> Restaurar(int id);
    }
}
