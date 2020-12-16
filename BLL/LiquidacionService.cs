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

    }
}
