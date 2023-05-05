using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login_herramientas_2
{
    /// <summary>
    /// Creado por : Juliana Herrera
    /// Fecha : 04/mayo/2023
    /// Genere en VC# una pantalla el registro y la validación de usuario, 
    /// teniendo en cuenta los 3 intentos permitidos
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_1());
        }
    }
}
