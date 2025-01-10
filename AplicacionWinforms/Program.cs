using System;
using System.Windows.Forms;

namespace DatagridView
{
    internal static class Program
    {
        /// <summary>
        /// El punto de entrada principal para la aplicaci�n.
        /// </summary>
        [STAThread]  // Establece el modelo de subprocesos para la interfaz de usuario de Windows Forms
        static void Main()
        {
            // Habilita la visualizaci�n de la configuraci�n de alta resoluci�n de la interfaz gr�fica
            ApplicationConfiguration.Initialize();

            // Lanza el formulario principal (por ejemplo, FrmMDI)
            Application.Run(new FrmMDI());
        }
    }
}
