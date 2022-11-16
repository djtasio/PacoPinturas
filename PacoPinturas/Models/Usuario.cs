using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Models
{
    internal class Usuario
    {
        public string Id { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string NameSurname { get; set; }
        public int Phone { get; set; }

        //Listado de pedidos

        private static int idNumberSeed = 1;

        public Usuario()
        {
            Id = idNumberSeed.ToString();
            idNumberSeed++;
        }

        public Usuario(string username, string password, string nameSurname, int phone)
        {
            Id = idNumberSeed.ToString();
            idNumberSeed++;
            Username = username;
            Password = password;
            NameSurname = nameSurname;
            Phone = phone;
            //Listado de pedidos declarado
        }
    }
}
