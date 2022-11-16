using PacoPinturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Functions
{
    internal static class Metodos
    {
        public static int CheckNumber(string message)
        {
            bool check = true;
            int number = 0;
            do
            {
                try
                {
                    Console.WriteLine(message);
                    number = Convert.ToInt32(Console.ReadLine());
                    check = false;
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine($"Número incorrecto {e.Message}");
                    //Log de errores
                }

            } while (check);
            return number;
        }

        public static Usuario Registrarse()
        {
            string username = "";
            string password = "";
            string password2 = "";
            string nameSurname = "";
            int phone = 0;
            Console.WriteLine("Introduce un username");
            username = Console.ReadLine();
            do
            {
                Console.WriteLine("Introduce una password");
                password = Console.ReadLine();
                Console.WriteLine("Repite tu password");
                password2 = Console.ReadLine();
                if (!String.Equals(password, password2))
                {
                    Console.WriteLine("Las password no coinciden");
                }
            } while (!String.Equals(password, password2));
            Console.WriteLine("Introduce tu name y surname");
            nameSurname = Console.ReadLine();
            Console.WriteLine("Introduce un username");
            phone = Convert.ToInt32(Console.ReadLine());
            return new Usuario(username, password, nameSurname, phone);
        }
    }
}
