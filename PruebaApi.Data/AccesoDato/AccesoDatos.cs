using PetaPoco;
using PruebaApi.Data.Common;
using PruebaApi.Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaApi.Data.AccesoDato
{
    public class AccesoDatos
    {
        private readonly Database bdcliente;

        public AccesoDatos()
        {
            //De esta forma llamamos las conexiones y quedan separadas 
            bdcliente = Util.GetConnectionFichaCliente();
        }

        public IEnumerable<ReporteClienteResponse> ObtieneReporteCliente()
        {
            //Generamos lista vacia
            var respuesta = new List<ReporteClienteResponse>();
            try
            {
                //Aquí utilizamos PETAPOCO ya dependera de la conexion que usted quiera realizar pero es practicamente las mismas.
                //Con esto obtenemos una lista desde un procedimiento. Tambien se puede mandar una consulta directa con o sin parametros.
                respuesta = bdcliente.Fetch<ReporteClienteResponse>(";exec sp_ReporteCliente");
                return respuesta;

                //Misma consulta con parametro necesario
                //respuesta = bdcliente.Fetch<ReporteClienteResponse>(";exec sp_ReporteCliente @cliente", new { cliente = cliente });
                
            }
            catch (Exception)
            {
                //Si por algun motivo la consulta se cae devolvera la lista vacia, podria devolverse el error o alguna otra cosa pero ya seria cosa de configurar mejor la captura de error
                return respuesta;
            }
        }
    }
}
