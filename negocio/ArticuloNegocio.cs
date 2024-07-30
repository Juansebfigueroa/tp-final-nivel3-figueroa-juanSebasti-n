﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDB;

namespace negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> listar()
        {
            List<Articulo> listaArticulos = new List<Articulo>();
            AccesoDB accesoDB = new AccesoDB();
            try
            {
                string consulta = "select Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio from articulos";
                accesoDB.setearConsulta(consulta);
                accesoDB.ejecutarLectura();
                while(accesoDB.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    
                    aux.Id = (int)accesoDB.Lector["Id"];
                    aux.Codigo = (string)accesoDB.Lector["Codigo"];
                    aux.Nombre = (string)accesoDB.Lector["Nombre"];
                    aux.Descripcion = (string)accesoDB.Lector["Descripcion"];
                    
                    aux.Categoria = new Categoria();
                    aux.Categoria.Id = (int)accesoDB.Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)accesoDB.Lector["Categoria"];

                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)accesoDB.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)accesoDB.Lector["Marca"];

                    aux.ImagenUrl = (string)accesoDB.Lector["ImagenUrl"];
                    aux.Precio = (decimal)accesoDB.Lector["Precio"];

                    //añadir el aux a la lista de articulos
                    listaArticulos.Add(aux);
                }
                return listaArticulos;
            }
            catch (Exception)
            {

                throw;
            }

        }



    }
}
