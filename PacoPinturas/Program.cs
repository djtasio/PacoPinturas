using PacoPinturas.Functions;
using PacoPinturas.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Transactions;

namespace PacoPinturas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Usuario> users = new List<Usuario>();

            do
            {
                int number = Metodos.CheckNumber(initialMenu.ToString());
                switch (number)
                {
                    case 1:
                        Console.WriteLine("Has iniciado sesión");
                        break;
                    case 2:
                        var usuario = Metodos.Registrarse(users);
                        Console.WriteLine("¡Usuario registrado con éxito!");
                        users.Add(usuario);
                        break;
                    default:
                        Console.WriteLine("Has introducido otro número");
                        break;
                }
            } while (true);
        }
    }
}
