﻿using PacoPinturas.Exceptions;
using PacoPinturas.Models;
using System;
using System.Collections;
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
        public static int CheckNumber(string menu)
        {
            bool check = true;
            int number = 0;
            do
            {
                try
                {
                    Console.WriteLine(menu);
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

        public static string CheckString(string messge)
        {
            bool check = true;
            string characters = "";
            do
            {
                try
                {
                    Console.WriteLine(messge);
                    characters = Console.ReadLine().Trim();
                    CheckEmptyCharacter(characters);
                    check = false;
                }
                catch(EmptyCharacterExceptions e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (check);
            return characters;
        }

        //Comprobar el phone number
        //Comprobar teléfono
        public static int CheckPhone(string phone)
        {
            int numero = 0;
            try
            {
                if (phone.Length != 9)
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
        public static bool CheckUsername(List<Usuario> users, string username)
        {
            var user = users.Find(user => user.User.Equals(username));
            if (user != null)
            {
                throw new UsernameAlreadyExistException("El nombre de usuario que has introducido ya existe");
            }
            return true;
        }
        //Comprobar si el nombre de usuario y la contraseña pertenecen a un usuario
        public static Usuario CheckLogin(List<Usuario> users, string username, string password)
        {
            var user = users.Find(user => user.User.Equals(username) && user.Contrasenia.Equals(password));
            return user;
        }

        public static List<Color> GetColors()
        {
            string fileName = $@"../../../jsons/colores.json";
            string jsonString = File.ReadAllText(fileName);
            List<Color>? lista = JsonSerializer.Deserialize<List<Color>>(jsonString)!;
            return lista;
        }
        public static string ReadColors()
        {
                List<Color>? lista = GetColors();
                var colores = new System.Text.StringBuilder();
                int i = 0;
                foreach(var color in lista)
            {
                colores.AppendLine($"{i}- {color.Name} {color.Code}");
                i++;
            }
            return colores.ToString();
        }

        public static string History(List<Pedido> pedidos) {
            var historial = new System.Text.StringBuilder();
            foreach (var pedido in pedidos)
            {
                historial.AppendLine($"--------------------------------------");
                historial.AppendLine($"PRECIO: {pedido.precio}€");
                historial.AppendLine($"FECHA: {pedido.Fecha}");
                historial.AppendLine($"DIRECCIÓN: {pedido.Direccion}");
                historial.AppendLine("PRODUCTOS:");
                foreach (var producto in pedido.productos)
                {
                    historial.AppendLine($"x{producto.cantidad} {producto.productos}" +
                        $"{producto.calidad} {producto.color} {producto.precio}€");
                }
            }
            historial.AppendLine($"--------------------------------------");
            return historial.ToString();
        }

        public static bool CheckEmptyCharacter(string text)
        {
            if (text.Length == 0)
            {
                throw new EmptyCharacterExceptions("No puedes dejar campos vacíos");
            }
            return true;
        }

        public static List<Pedido> FetchFilter(List<Pedido> pedidos, String fecha)
        {
            //thisDate1.ToString("MM/dd/yyyy") + ".");
            var pedidosFiltro = pedidos.flatMap(pedido => 
                pedido.Fecha.ToString("dd/MM/yyyy").Equals(fecha)
                );
            return pedidosFiltro;
        }
    }
}
