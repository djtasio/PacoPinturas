using PacoPinturas.Exceptions;
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
            Usuario usuario = new Usuario();

            Console.WriteLine(Metodos.ReadColors());

            do
            {
                int number = Metodos.CheckNumber();
                switch (number)
                {
                    case 1:
                        try
                        {
                            usuario = DisplayInteractiveMenu.login(users);
                            Console.WriteLine($"Bienvenido {usuario.NombreApellidos}");
                        }
                        catch(IncorrectUserException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2:
                        usuario = DisplayInteractiveMenu.Registrarse(users);
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
