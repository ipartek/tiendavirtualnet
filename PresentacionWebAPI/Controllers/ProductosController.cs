using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TiendaVirtual.Entidades;
using TiendaVirtual.LogicaNegocio;

namespace PresentacionWebAPI.Controllers
{
    public class ProductosController : ApiController
    {
        private ILogicaNegocio ln = (ILogicaNegocio)HttpContext.Current.Application["logicaNegocio"];
        
        // GET: api/Productos
        public IEnumerable<IProducto> Get()
        {
            return ln.ListadoProductos();
        }

        // GET: api/Productos/5
        public Producto Get(int id)
        {
            return (Producto)ln.BuscarProductoPorId(id);
        }

        // POST: api/Productos
        public void Post([FromBody]Producto value)
        {
        }

        // PUT: api/Productos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Productos/5
        public void Delete(int id)
        {
        }
    }
}
