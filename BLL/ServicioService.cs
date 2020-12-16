using DAL;
using Entity;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class ServicioService
    {

        private ConnectionManager connectionManager;
        public ServicioRepository ServicioRepository;
        public List<Servicio> ServicioIpsIncorrecto = new List<Servicio>();
        public List<Servicio> ServicioIpsCorrecto = new List<Servicio>();
        //private PedidoRepository PedidoRepository;

        public ServicioService(string connectionString)
        {
            connectionManager = new ConnectionManager(connectionString);
            ServicioRepository = new ServicioRepository(connectionManager);
            //PedidoRepository = new PedidoRepository(connectionManager);
        }

        public string Guardar(Servicio servicio)
        {
            try
            {
                connectionManager.Open();
                ServicioRepository.Guardar(servicio);
                return $"Se guardaron los datos satisfactoriamente n_n";
            }
            catch (Exception e)
            {

                return $"Error de la aplicacion : {e.Message}";
            }
            finally { connectionManager.Close(); }
        }

        public List<Servicio> ConsultarTodos(string file)
        {

            try
            {
                connectionManager.Open();
                List<Servicio> servicio = ServicioRepository.ConsultarTodos();
                connectionManager.Close();
                return servicio;
            }
            catch (Exception e)
            {

                return null;
            }
            finally { connectionManager.Close(); }

        }


        public void ValidarIps(List<Servicio> servicios, string IdIps)
        {
            foreach (Servicio servicio in servicios)
            {
                if (servicio.IdIps != IdIps)
                {
                    ServicioIpsIncorrecto.Add(servicio);
                }
            }
        }

        public List<Servicio> ConsultarTodaLaLista(string fileName)
        {
            try
            {
                List<Servicio> servicios = ServicioRepository.ConsultarTodaLaLista(fileName);
                return servicios;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public void ValidarLaboratorio(List<Laboratorio> listaLab, List<Servicio> ListaServ)
        {
            foreach (Laboratorio laboratorio in listaLab)
            {
                foreach (Servicio servicio in ListaServ)
                {

                    if (servicio.ValorLaboratorio != laboratorio.ValorLaboratorio)
                    {
                        ServicioIpsCorrecto.Add(servicio);
                    }
                }

            }
            //if
        }

    }
}
