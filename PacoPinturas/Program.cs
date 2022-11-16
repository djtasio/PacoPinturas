using PacoPinturas.Functions;
using PacoPinturas.Models;
using System;
using System.Linq.Expressions;
using System.Text;

namespace PacoPinturas
{
    class Program
    {
        static void Main(string[] args)
        {

            var initialMenu = new StringBuilder();
            initialMenu.AppendLine("Bienvenido a PACO EL PINTURAS");
            initialMenu.AppendLine("1- INICIAR SESÍON");
            initialMenu.AppendLine("2- REGISTRARSE");

            int number = Metodos.CheckNumber(initialMenu.ToString());
            switch (number)
            {
                case 1:
                    Console.WriteLine("Has iniciado sesión");
                    break;
                case 2:
                    var usuario = Metodos.Registrarse();
                    Console.WriteLine(usuario.ToString());
                    break;
                default:
                    Console.WriteLine("Has introducido otro número");
                    break;
            }

        }
    }
}
