using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaInventario.LogicaNegocio
{
    /// <summary>
    /// Envoltorio generico para el resultado de una operación de negocio.
    /// Evita lanzar excepciones para errores esperados.
    /// </summary>
    public class ResultadoOperacion<T>
    {
       
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }

        /// <summary>Crea un resultado exitoso.</summary>
        public static ResultadoOperacion<T> Ok(T datos, string mensaje = "Operación exitosa")
            => new ResultadoOperacion<T> { Exito = true, Mensaje = mensaje, Datos = datos };

        /// <summary>Crea un resultado de error.</summary>
        public static ResultadoOperacion<T> Error(string mensaje)
            => new ResultadoOperacion<T> { Exito = false, Mensaje = mensaje, Datos = default(T) };
    }
}
