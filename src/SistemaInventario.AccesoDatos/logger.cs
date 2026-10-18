using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SistemaInventario.AccesoDatos
{
    /// <summary>
    /// El logger se encarga de registra los errores de la aplicación en un archivo errores.log.
    /// </summary>
    public static class Logger
    {
        private const string NombreArchivo = "errores.log";
        private static readonly object _candado = new object();

        public static void Log(Exception ex)
        {
            if (ex == null) return;

            var texto = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {ex.GetType().Name}: {ex.Message}" +
                        Environment.NewLine + ex.StackTrace +
                        Environment.NewLine + new string('-', 60) + Environment.NewLine;
            Escribir(texto);
        }

        public static void Log(string mensaje)
        {
            var texto = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] INFO: {mensaje}" + Environment.NewLine;
            Escribir(texto);
        }

        private static void Escribir(string texto)
        {
            try
            {
                var ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NombreArchivo);
                lock (_candado)
                {
                    File.AppendAllText(ruta, texto);
                }
            }
            catch (Exception exSecundaria)
            {
                // Si el log principal falla, se notifica al menos en la salida de depuración.
                Debug.WriteLine("[Logger] No se pudo escribir en errores.log: " + exSecundaria.Message);
                Trace.WriteLine("[Logger] No se pudo escribir en errores.log: " + exSecundaria.Message);

                try
                {

                    var rutaAlterna = Path.Combine(Path.GetTempPath(), NombreArchivo);
                    lock (_candado)
                    {
                        File.AppendAllText(rutaAlterna, texto);
                    }
                }
                catch (Exception exFinal)
                {
                    Debug.WriteLine("[Logger] Fallback también fallo: " + exFinal.Message);
                    Trace.WriteLine("[Logger] Fallback también fallo: " + exFinal.Message);
                }
            }
        }
    }

}
