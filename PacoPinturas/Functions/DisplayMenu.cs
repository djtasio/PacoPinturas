using PacoPinturas.Exceptions;
using PacoPinturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Functions
{
    internal static class DisplayMenu
    {
        //Menu inicial
        public static string Initial()
        {
            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("Bienvenido a PACO EL PINTURAS");
            initialMenu.AppendLine("1- INICIAR SESÍON");
            initialMenu.AppendLine("2- REGISTRARSE");

            return initialMenu.ToString();
        }
    }
}
