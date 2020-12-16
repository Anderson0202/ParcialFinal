using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IpsService
    {

        private readonly ConnectionManager connectionManager;
        public readonly IpsRepository IpsRepository;
        //private PedidoRepository PedidoRepository;

        public IpsService(string connectionString)
        {
            connectionManager = new ConnectionManager(connectionString);
            IpsRepository = new IpsRepository(connectionManager);
            //PedidoRepository = new PedidoRepository(connectionManager);
        }

        

        public List<Ips> ConsultarTodo(string file)
        {

            List<Ips> Ipses = new List<Ips>();

            try
            {
                Ipses = IpsRepository.ConsultarTodaLaLista(file);
            }
            catch (Exception e)
            {

                e = null;
            }
            return Ipses;
        }

        public string Guardar(Ips Ips)
        {
            try
            {
                connectionManager.Open();
                IpsRepository.GuardarBD(Ips);
                return $"Se guardaron los datos satisfactoriamente";
            }
            catch (Exception e)
            {

                return $"Error de la aplicacion : {e.Message}";
            }
            finally { connectionManager.Close(); }
        }

     

        public List<Ips> ConsultarTodosBD()
        {

            try
            {
                connectionManager.Open();
                List<Ips> Ips = IpsRepository.ConsultarTodosBD();
                connectionManager.Close();
                return Ips;
            }
            catch (Exception e)
            {

                return null;
            }
            finally { connectionManager.Close(); }

        }

    }


    public class ConsultaIpsResponse
    {

        public List<Ips> Ips { get; set; }
        public string Message { get; set; }
        public bool IpsEncontrada { get; set; }

        public ConsultaIpsResponse(List<Ips> personas)
        {
            Ips = new List<Ips>();
            Ips = Ips;
            IpsEncontrada = true;
        }
        public ConsultaIpsResponse(string message)
        {

            Message = message;
            IpsEncontrada = false;

        }
    }


}

