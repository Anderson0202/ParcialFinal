using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LiquidacionService
    {

        private ConnectionManager connectionManager;
        //public ClienteRepository ClienteRepository;
        //private PedidoRepository PedidoRepository;

        public LiquidacionService(string connectionString)
        {
            connectionManager = new ConnectionManager(connectionString);
            //ClienteRepository = new ClienteRepository(connectionManager);
            //PedidoRepository = new PedidoRepository(connectionManager);
        }

        public void Guardar()
        {

            try
            {
                if (LiquidacionRepository.BuscarRtry(persona.Identificacion) == null)
                {

                    personaRepository.Guardar(persona);
                    return " Guardamos su registro y pulsacion Exitosamente [__ U_U __]";

                }
                else
                {
                    return "*Atencion* La Identificacion [" + persona.Identificacion + "] ha sido registrada anteriormente";
                }
            }
            catch (Exception exception)
            {

                return " Error de la aplicacion : " + exception.Message;
            }

        }

    }
}
