﻿using PresentacionWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionWebAPI.Controllers
{
    public class FacturasController : ApiController
    {
        private static LogicaNegocio ln = new LogicaNegocio();

        //// GET: api/Facturas
        //public IEnumerable<IFactura> Get()
        //{
        //    return null;
        //}

        // GET: api/Facturas/5
        public IFactura Get(int id)
        {
            return null;
        }

        [Route("api/CarritoDTO")]
        public CarritoDTO Get()
        {
            CarritoDTO carritoDTO = new CarritoDTO();

            carritoDTO.IdUsuario = 1;
            carritoDTO.IdsProductos = new int[] { 1, 2, 3, 4 };
            carritoDTO.CantidadesProductos = new int[] { 10, 20, 30, 40 };

            return carritoDTO;
        }

        // POST: api/Facturas
        public IFactura Post([FromBody]CarritoDTO carritoDTO)
        {
            IUsuario usuario = ln.BuscarUsuarioPorId(carritoDTO.IdUsuario);

            Carrito carrito = new Carrito(usuario);

            IProducto producto;
            int cantidad;

            for (int i = 0; i < carritoDTO.IdsProductos.Length; i++) {
                producto = ln.BuscarProductoPorId(carritoDTO.IdsProductos[i]);
                cantidad = carritoDTO.CantidadesProductos[i];

                ln.AgregarProductoACarrito(producto, cantidad, carrito);
            }

            return ln.FacturarCarrito(carrito);
        }

        //// PUT: api/Facturas/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Facturas/5
        //public void Delete(int id)
        //{
        //}
    }
}
