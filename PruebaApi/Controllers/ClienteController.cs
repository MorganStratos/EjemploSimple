using PruebaApi.Data.AccesoDato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PruebaApi.Controllers
{
    public class ClienteController : ApiController
    {
        //Esta seccion es para la inyeccion de dependencia, en donde utilizamos ninject
        private AccesoDatos _acceso { get; set; }
        public ClienteController(AccesoDatos acceso)
        {
            _acceso = acceso;
        }

        //Obtener reporte cliente
        [HttpPost]
        [Route("api/clientes/")]//Le da el nombre al cual quiere que llegue
        public HttpResponseMessage GetClientes()
        {
            try
            {
                var respuesta = _acceso.ObtieneReporteCliente();//Llama al metodo y devuelve la informacion, esta podria llevar un servicio entremedio para mapear otras cosas,
                //hacer calculos, cambiar propiedades etc

                return Request.CreateResponse(HttpStatusCode.OK, respuesta); // devuelve la respuesta 
            }
            catch (Exception e)
            {
                //Esto ya es configurable de acuerdo al error devuelto o simplemente se deja un tipo de error
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
            
        }

        //Obtener reporte cliente
        [HttpPost]
        [Route("api/clientes/detalle/{id}")]//Le da el nombre al cual quiere que llegue
        public HttpResponseMessage GetClientesConParametro(int id)
        {
            try
            {
                var respuesta = _acceso.ObtieneReportePorCliente(id);//Llama al metodo y devuelve la informacion, esta podria llevar un servicio entremedio para mapear otras cosas,
                //hacer calculos, cambiar propiedades etc

                return Request.CreateResponse(HttpStatusCode.OK, respuesta); // devuelve la respuesta 
            }
            catch (Exception e)
            {
                //Esto ya es configurable de acuerdo al error devuelto o simplemente se deja un tipo de error
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }


    }
}
