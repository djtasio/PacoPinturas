using PacoPinturas.Exceptions;
using PacoPinturas.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Functions
{
    internal static class Metodos
    {
        //Comprobar que se ha introducido un número valido y si no preguntar hasta que se introduzca
        public static int CheckNumber(string message)
        {
            bool check = true;
            int number = 0; //
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

        //Registrar usuario
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
                    checkUsername(users, username);
                    check = false;
                }
                catch(UsernameAlreadyExistException e)
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
                    phone = checkPhone(tel);
                    check = false;
                }
                catch (PhoneException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (check);
            return new Usuario(username, password, nameSurname, phone);
        }

        //Comprobar el phone number
        //Comprobar teléfono
        public static int checkPhone(string phone)
        {
            int numero = 0;
            try
            {
                if(phone.Length != 9)
                {
                    throw new PhoneException("Phone incorrecto");
                }
                numero = Convert.ToInt32(phone);
            }
            catch (System.FormatException)
            {
                throw new PhoneException("Phone incorrecto");
            }
            return numero;
        }

        public static void checkUsername(List<Usuario> users,string username)
        {
            var user = users.Find(user => user.User.Equals(username));
            if(user != null)
            {
                throw new UsernameAlreadyExistException("El nombre de usuario que has introducido ya existe");
            }
        }
    }
}
