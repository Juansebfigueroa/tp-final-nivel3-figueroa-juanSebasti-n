using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace accesoDB
{
    public class AccesoDB
    {
        //Atributos. Metemos los dos using para que los tome
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        //Constructor
        public AccesoDB()
        {
            //para hacer esta conexion tenemos que agregar unas lineas en el appconfig
            conexion = new SqlConnection(ConfigurationManager.AppSettings["cadenaConexion"]);
            //Otra forma de hacer la conexion
            //conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_WEB_DB; integrated security=true");
            comando = new SqlCommand();
        }

        //Metodos
        public SqlDataReader Lector //para que solo devuelva el lector
        {
            get { return lector; }
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        //en esta app no manejamos stored procedure, si la DB tuviese usar el siguiente metodo
        //public void setearProcedimiento(string sp)
        //{
        //    comando.CommandType = System.Data.CommandType.StoredProcedure;
        //    comando.CommandText = sp;
        //}

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //usada para modificar registros en DB
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Para devolver un indice, o ID de un registro de la DB
        public int ejecutarAccionScalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                //comando.ExecuteScalar devuelve el valor de la primera columna y primera fila de la consulta
                return int.Parse(comando.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Permite pasar valores por parametros a las consultas
        public void setearParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if(lector != null)
                lector.Close();
            conexion.Close();
        }
    }
}
