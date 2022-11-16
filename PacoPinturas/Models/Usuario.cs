﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Models
{
    internal class Usuario
    {
        public string Id { get; }
        public string User { get; set; }
        public string Contrasenia { get; set; }
        public string NombreApellidos { get; set; }
        public int Telefono { get; set; }

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
            User = username;
            Contrasenia = password;
            NombreApellidos = nameSurname;
            Telefono = phone;
            //Listado de pedidos declarado
        }
    }
}
