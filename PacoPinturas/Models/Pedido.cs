﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PacoPinturas.Models
{
    class Pedido
    {
        public string Id { get; set; }

        //Date de hoy
        public DateTime Fecha { get; set; }
        //thisDay.ToString("g");
   

        //Lista de productos
        public List<Producto> productos;

        public bool Entrega24h;

        public string Direccion { get; set; }

        private static int idNumberSeed = 1;
        public Pedido()
        {
            this.Id = idNumberSeed.ToString();
            idNumberSeed++;
            //this.Fecha = DateTime.Today;
            this.productos = new List<Producto>();
        }
        public Pedido(List<Producto> productos, Boolean entrega, string direccion)
        {
            this.Id = idNumberSeed.ToString();
            idNumberSeed++;
            this.productos = productos;
            this.Entrega24h = entrega;
            this.Direccion = direccion;
            this.Fecha = DateTime.Today;
        }
    }
}