using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace PruebaApi.Data.Common
{
    public static class Util
    {
        public static Database GetConnectionFichaCliente()
        {
            //Los WebConfigurationManager necesitan ser agregados como referencias en este caso system.web, de esta forma puede dejar la conexion en el webconfig y modificarlo a gusto.
            string Ambiente = WebConfigurationManager.AppSettings["TipoAmbiente"].ToString();
            var connection = new Database(Ambiente + "BD_Cliente");
            return connection;
        }
    }
}
