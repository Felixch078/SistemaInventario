using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    /// <summary>Este es el contrato genérico CRUD para cualquier entidad del sistema</summary>
    public interface IRepositorio<T>
    {
        List<T> ObtenerTodos();
        List<T> ObtenerActivos();
        T ObtenerPorId(int id);
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void EliminarLogico(int id);
        void Restaurar(int id);
    }
}
