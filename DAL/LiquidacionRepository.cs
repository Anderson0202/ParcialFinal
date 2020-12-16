using Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class LiquidacionRepository
    {

        private string fileName = @"Persona.txt";

        private ConnectionManager connectionManager { get; }

        private SqlConnection connection;

        public LiquidacionRepository(ConnectionManager _connectionManager)
        {
            connectionManager = _connectionManager;
            connection = connectionManager._conexion;
        }

        public Ips BuscarRtry(string id)
        {

            List<Ips> personas = ConsultarTodaLaLista();
            foreach (var item in personas)
            {

                if (SeEncuentra(item.Identificacion, id))
                {
                    return item;
                }

            }
            return null;
        }

        private bool SeEncuentra(string idAlmacenada, string idBuscada)
        {

            return idAlmacenada == idBuscada;

        }

        public List<Ips> ConsultarTodaLaLista()
        {

            List<Ips> ListaDeIps = new List<Ips>();
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            String linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {

                Persona persona = Map(linea);
                ListaDePersonas.Add(persona);

            }

            reader.Close();
            file.Close();
            return ListaDePersonas;

        }

        private Persona Map(string linea)
        {

            Persona persona = new Persona();
            char delimiter = ';';
            string[] sacaMatrizPersona = linea.Split(delimiter);
            persona.Identificacion = sacaMatrizPersona[0];
            persona.Nombre = sacaMatrizPersona[1];
            persona.Edad = int.Parse(sacaMatrizPersona[2]);
            persona.Sexo = sacaMatrizPersona[3];
            persona.Pulsacion = int.Parse(sacaMatrizPersona[4]);

            return persona;

        }

    }
}
