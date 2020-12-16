using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServicioRepository
    {

        //private string fileName = @"Ips.txt";

        private ConnectionManager connectionManager { get; }

        private SqlConnection connection;

        public ServicioRepository(ConnectionManager _connectionManager)
        {
            connectionManager = _connectionManager;
            connection = connectionManager._conexion;
        }

        public void Guardar(Servicio servicio)
        {

            using (var command = connection.CreateCommand())
            {

                command.CommandText = "Insert Into Servicio (IdIps, IdentificacionPaciente, NombrePaciente, IdLaboratorio, ValorLaboratorio )" +
                                      " VALUES (@IdIps, @IdentificacionPaciente, @NombrePaciente, @IdLaboratorio, @ValorLaboratorio )";
                command.Parameters.AddWithValue("@IdIps", servicio.IdIps);
                command.Parameters.AddWithValue("@IdentificacionPaciente", servicio.IdentificacionPaciente);
                command.Parameters.AddWithValue("@NombrePaciente", servicio.NombrePaciente);
                command.Parameters.AddWithValue("@IdLaboratorio", servicio.IdLaboratorio);
                command.Parameters.AddWithValue("@ValorLaboratorio", servicio.ValorLaboratorio);
                 
                command.ExecuteNonQuery();

            }

        }

        public List<Servicio> ConsultarTodos()
        {
            List<Servicio> ListaDeServicios = new List<Servicio>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select * from Servicios";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Servicio servicio = DataReaderMapProducto(dataReader);
                        ListaDeServicios.Add(servicio);
                    }
                }
            }
            return ListaDeServicios;
        }

        private Servicio DataReaderMapProducto(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Servicio servicio = new Servicio();
            servicio.IdIps = (string)dataReader["IdIps"];
            servicio.IdentificacionPaciente = (string)dataReader["IdentificacionPaciente"];
            servicio.NombrePaciente = (string)dataReader["NombrePaciente"];
            servicio.IdLaboratorio = (string)dataReader["IdLaboratorio"];
            servicio.ValorLaboratorio = (double)dataReader["ValorLaboratorio"];
 
            return servicio;
        }


        public List<Servicio> ConsultarTodaLaLista(string fileName)
        {
            List<Servicio> ListaDeServicio = new List<Servicio>();
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {

                Servicio Servicio = Map(linea);
                ListaDeServicio.Add(Servicio);

            }
            reader.Close();
            file.Close();
            return ListaDeServicio;
        }



        private Servicio Map(string linea)
        {

            Servicio Servicio = new Servicio();
            char delimiter = ';';
            string[] sacaMatrizLab = linea.Split(delimiter);
            Servicio.IdIps = sacaMatrizLab[0];
            Servicio.IdentificacionPaciente = sacaMatrizLab[1];
            Servicio.NombrePaciente = sacaMatrizLab[2];
            Servicio.IdLaboratorio = sacaMatrizLab[3];
            Servicio.ValorLaboratorio = double.Parse(sacaMatrizLab[4]);
            return Servicio;
        }

    }
}
