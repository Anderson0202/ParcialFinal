using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class IpsRepository
    {

        //private string fileName = @"Ips.txt";

        private ConnectionManager connectionManager { get; }

        private SqlConnection connection;

       

        public IpsRepository(ConnectionManager _connectionManager)
        {
            connectionManager = _connectionManager;
            connection = connectionManager._conexion;
        }


        public void GuardarBD(Ips ips)
        {

            using (var command = connection.CreateCommand())
            {

                command.CommandText = "Insert Into IPS (IdIPS, NombreIPS)" +
                                      " VALUES (@IdIps, @NombreIPS)";
                command.Parameters.AddWithValue("@IdIps", ips.IdIps);
                command.Parameters.AddWithValue("@NombreIPS", ips.NombreIps);

                command.ExecuteNonQuery();

            }

        }

        //public void Guardar(Ips ips)
        //{

        //    FileStream file = new FileStream(fileName, FileMode.Append);
        //    StreamWriter writer = new StreamWriter(file);
        //    writer.WriteLine($"{ips.IdIps};{ips.NombreIps}");
        //    writer.Close();
        //    file.Close();

        //}

        public List<Ips> ConsultarTodosBD()
        {
            List<Ips> ListaDeIps = new List<Ips>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select * from IPS";
                var dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Ips Ips = DataReaderMapIps(dataReader);
                        ListaDeIps.Add(Ips);
                    }
                }
            }
            return ListaDeIps;
        }

        private Ips DataReaderMapIps(SqlDataReader dataReader)
        {
            if (!dataReader.HasRows) return null;
            Ips Ips = new Ips();
            Ips.IdIps = (string)dataReader["IdIps"];
            Ips.NombreIps = (string)dataReader["NombreIps"];
            
            return Ips;
        }

        //public Ips BuscarRtry(string id)
        //{

        //    List<Ips> Ipses = ConsultarTodaLaLista();
        //    foreach (var item in Ipses)
        //    {

        //        if (SeEncuentra(item.IdIps, id))
        //        {
        //            return item;
        //        }

        //    }
        //    return null;
        //}

        private bool SeEncuentra(string idAlmacenada, string idBuscada)
        {

            return idAlmacenada == idBuscada;

        }

        public List<Ips> ConsultarTodaLaLista(string fileName)
        {
            List<Ips> ListaDeIps = new List<Ips>();
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {

                Ips ips = Map(linea);
                ListaDeIps.Add(ips);

            }
            reader.Close();
            file.Close();
            return ListaDeIps;
        }

        

        private Ips Map(string linea)
        {

            Ips ips = new Ips();
            char delimiter = ';';
            string[] sacaMatrizLab = linea.Split(delimiter);
            ips.IdIps = sacaMatrizLab[0];
            ips.NombreIps = sacaMatrizLab[1];
            return ips;

        }



    }
}
