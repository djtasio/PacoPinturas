using PacoPinturas.Exceptions;
using PacoPinturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Functions
{
    internal static class DisplayInteractiveMenu
    {
        //Menu registro
        public static Usuario Registrarse(List<Usuario> users)
        {
            string username = "";
            string password = "";
            string password2 = "";
            string nameSurname = "";
            bool check = true;
            int phone = 0;
            do
            {
                try
                {
                    Console.WriteLine("Introduce un username");
                    username = Console.ReadLine();
                    Metodos.checkUsername(users, username);
                    check = false;
                }
                catch (UsernameAlreadyExistException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (check);
            check = true;
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
            do
            {
                try
                {
                    Console.WriteLine("Introduce tu phone");
                    string tel = Console.ReadLine();
                    phone = Metodos.checkPhone(tel);
                    check = false;
                }
                catch (PhoneException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (check);
            return new Usuario(username, password, nameSurname, phone);
        }

        //Menu login
        public static Usuario login(List<Usuario> usuarios)
        {
            Console.WriteLine("Introduce el username");
            string username = Console.ReadLine();
            Console.WriteLine("Introduce la password");
            string password = Console.ReadLine();

            var usuario = Metodos.checkLogin(usuarios, username, password);
            if (usuario == null)
            {
                throw (new IncorrectUserException("Incorrect username or password"));
            }
            return usuario;
        }
    }
}
