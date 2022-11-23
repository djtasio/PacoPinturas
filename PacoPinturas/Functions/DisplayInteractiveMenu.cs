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
                    username = Metodos.CheckString("Introduce un username");
                    Metodos.CheckUsername(users, username);
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
                password = Metodos.CheckString("Introduce una password");
                password2 = Metodos.CheckString("Repite tu password");
                if (!String.Equals(password, password2))
                {
                    Console.WriteLine("Las password no coinciden");
                }
            } while (!String.Equals(password, password2));
            nameSurname = Metodos.CheckString("Introduce tu name y surname");
            do
            {
                try
                {
                    Console.WriteLine("Introduce tu phone");
                    string tel = Console.ReadLine();
                    phone = Metodos.CheckPhone(tel);
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
            string username = Metodos.CheckString("Introduce el username");
            string password = Metodos.CheckString("Introduce tu password");

            var usuario = Metodos.CheckLogin(usuarios, username, password);
            if (usuario == null)
            {
                throw new IncorrectUserException("Incorrect username or password");
            }
            return usuario;
        }

        public static void InitialMenu(Usuario usuario)
        {
            int numero = Metodos.CheckNumber(DisplayMenu.Menu());
            switch(numero) 
            {
                case 1:
                    {
                        usuario.Pedidos.Add(Order());
                        Console.WriteLine(Metodos.History(usuario.Pedidos));
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine(Metodos.History(usuario.Pedidos));
                        break;
                    }
                case 3:
                    {
                        Metodos.ReadColors();
                        break;
                    }
            }
        }
        public static Pedido Order()
        {
            Pedido pedido = new Pedido();
            bool check = true;
            do
            {
                int numero = Metodos.CheckNumber(DisplayMenu.Productos());
                int numProducto = 0;
                Producto producto = new Producto();
                switch (numero)
                {
                    case 1:
                        {
                            producto.productos = Productos.Spray;
                            numProducto = Metodos.CheckNumber(DisplayMenu.Spray());
                            switch (numProducto)
                            {
                                case 1:
                                    {
                                        producto.calidad = Calidad.Estandar;
                                        break;
                                    }
                                case 2:
                                    {
                                        producto.calidad = Calidad.Premium;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 2:
                        {
                            producto.productos = Productos.Cubo;
                            numProducto = Metodos.CheckNumber(DisplayMenu.Cubo());
                            switch (numProducto)
                            {
                                case 1:
                                    {
                                        producto.calidad = Calidad.Estandar;
                                        break;
                                    }
                                case 2:
                                    {
                                        producto.calidad = Calidad.Premium;
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            producto.productos = Productos.Rotulador;
                            numProducto = Metodos.CheckNumber(DisplayMenu.Rotulador());
                            switch (numProducto)
                            {
                                case 1:
                                    {
                                        producto.calidad = Calidad.Estandar;
                                        break;
                                    }
                                case 2:
                                    {
                                        producto.calidad = Calidad.Premium;
                                        break;
                                    }
                            }
                            break;
                        }
                }
                producto.cantidad = Metodos.CheckNumber(DisplayMenu.Cantidad());
                Console.WriteLine(DisplayMenu.Color());
                int numColor = Metodos.CheckNumber(Metodos.ReadColors());
                //Controlar que color no sea null
                var color = Metodos.GetColors().Find(color => color.Id.Equals(numColor.ToString()));
                producto.color = color.Code;
                int numSeguirComprando = Metodos.CheckNumber(DisplayMenu.SeguirComprando());
                if (numSeguirComprando == 2)
                {
                    check = false;
                }
                pedido.productos.Add(producto);
            } while (check);
            int numEntrega = Metodos.CheckNumber(DisplayMenu.Entrega24H());
            switch (numEntrega)
            {
                case 1:
                    {
                        pedido.Entrega24h = true;
                        break;
                    }
                case 2:
                    {
                        pedido.Entrega24h = false;
                        break;
                    }
            }
            pedido.Direccion = Metodos.CheckString(DisplayMenu.Direccion());
            pedido.Fecha = DateTime.Today;
            return pedido;
        }
    }
}
