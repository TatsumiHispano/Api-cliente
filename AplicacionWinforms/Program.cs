using System;
using System.Windows.Forms;

namespace DatagridView
{
    internal static class Program
    {
        /// <summary>
        /// El punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]  // Establece el modelo de subprocesos para la interfaz de usuario de Windows Forms
        static void Main()
        {
            // Habilita la visualización de la configuración de alta resolución de la interfaz gráfica
            ApplicationConfiguration.Initialize();

            // Lanza el formulario principal (por ejemplo, FrmMDI)
            Application.Run(new FrmMDI());
        }
    }
}
