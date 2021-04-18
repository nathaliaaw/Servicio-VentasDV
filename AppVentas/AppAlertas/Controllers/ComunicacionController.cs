using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppVentas.Controllers
{
    public class ComunicacionController : ApiController
    {

        public class objetoinsertClientes
        {
            public string numeroDocumento;
            public string completosNombre;
            public string direccion;
            public string telefono;

        }
        public class objetoinsertProductos
        {
            public string nombre;
            public string precioActual;
            public int stock;
            public int proveedor;

        }
        public class objetoDelClientes
        {
            public string numeroDocumento;

        }
        public class objetoinsertrProvedores
        {
            public string RUT;
            public string nombre;
            public string direccion;
            public string paginaWeb;
        }

        public class objetoinsertaVentas
        {
            public int idcliente;
            public int descuento;
            public float montoFinal;
            public string paginaWeb;
        }
        public class objetoinsertaVentaDetalles
        {
            public int idVenta;
            public int idproducto;
        }
        public class objetoUpdVentas
        {       
            public string numeroDocumento;
            public string nombre;
            public string direccion;
            public string telefono;
            public int idusuario;
        }



       
        [Route("insertarClientes")]
        [HttpPost]
        public IHttpActionResult insertarClientes([FromBody]objetoinsertClientes dato)
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec SVentas.Add_cliente  @numeroDocumento=N'" + dato.numeroDocumento + "',@completosNombre=N'" + dato.completosNombre + "',@direccion=N'" + dato.direccion + "',@telefono=N'" + dato.telefono + "'  "));
        }
        [Route("insertarProductos")]
        [HttpPost]
        public IHttpActionResult insertarProductos([FromBody]objetoinsertProductos dato)
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec SVentas.Add_Productos  @nombre=N'" + dato.nombre + "',@precioActual=N'" + dato.precioActual + "',@stock=N'" + dato.stock + "',@proveedor=N'" + dato.proveedor + "'  "));
        }
        [Route("insertarProvedores")]
        [HttpPost]
        public IHttpActionResult insertarProvedores([FromBody]objetoinsertrProvedores dato)
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec SVentas.Add_Provedores  @RUT=N'" + dato.RUT + "',@nombre=N'" + dato.nombre + "',@direccion=N'" + dato.direccion + "',@paginaWeb=N'" + dato.paginaWeb + "'  "));
        }
        [Route("insertarVentas")]
        [HttpPost]
        public IHttpActionResult insertarVentas([FromBody]objetoinsertaVentas dato)
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec SVentas.Add_Ventas  @idcliente=N'" + dato.idcliente + "',@descuento=N'" + dato.descuento + "',@montoFinal=N'" + dato.montoFinal + "'"));
        }

        [Route("insertarVentasDetalle")]
        [HttpPost]
        public IHttpActionResult insertarVentasDetalle([FromBody]objetoinsertaVentaDetalles dato)
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec SVentas.Add_VentasDetalle  @idVenta=N'" + dato.idVenta + "',@idproducto=N'" + dato.idproducto + "'"));
        }

        [Route("ActualizaClientes")]
        [HttpPost]
        public IHttpActionResult ActualizaClientes([FromBody]objetoUpdVentas dato)
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec SVentas.Upd_cliente  @numeroDocumento=N'" + dato.numeroDocumento + "',@nombre=N'" + dato.nombre + "',@direccion=N'" + dato.direccion + "',@telefono=N'" + dato.telefono + "',@idusuario=N'" + dato.idusuario + "'   "));
        }

        [Route("EliminaClientes")]
        [HttpPost]
        public IHttpActionResult EliminaClientes([FromBody]objetoDelClientes dato)
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec SVentas.Del_cliente  @numeroDocumento=N'" + dato.numeroDocumento + "' "));
        }

        [Route("listaVentas")]
        [HttpGet]
        public IHttpActionResult listaVentas()
        {
            return Ok(lnVentas.Conexion.ConexionBD("exec  SVentas.Lst_Ventas "));
        }

    }
}
