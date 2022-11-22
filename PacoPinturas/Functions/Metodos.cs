using PacoPinturas.Exceptions;
using PacoPinturas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Transactions;

namespace PacoPinturas.Functions
{
    internal static class Metodos
    {
        //Comprobar que se ha introducido un número valido y si no preguntar hasta que se introduzca
        public static int CheckNumber()
        {
            bool check = true;
            int number = 0; 
            do
            {
                try
                {
                    Console.WriteLine(DisplayMenu.Initial());
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

        //Comprobar el phone number
        //Comprobar teléfono
        public static int CheckPhone(string phone)
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

        //Comprobar si existe ese nombre de usuario
        public static void CheckUsername(List<Usuario> users,string username)
        {
            var user = users.Find(user => user.User.Equals(username));
            if(user != null)
            {
                throw new UsernameAlreadyExistException("El nombre de usuario que has introducido ya existe");
            }
        }
        //Comprobar si el nombre de usuario y la contraseña pertenecen a un usuario
        public static Usuario CheckLogin(List<Usuario> users,string username, string password)
        {
            var user = users.Find(user => user.User.Equals(username) && user.Contrasenia.Equals(password));
            return user;
        }

    }
}
