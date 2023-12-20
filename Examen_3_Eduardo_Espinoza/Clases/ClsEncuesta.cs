using EDUARDO_ESPINOZA_EX2.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Examen_3_Eduardo_Espinoza.Clases
{
    public class ClsEncuesta
    {
        public string nombre { get; set; }
        public DateTime nacimiento { get; set; }
        public string correo { get; set; }

        public int npartido { get; set; }

        public ClsEncuesta(string Nombre, DateTime Nacimiento, string Correo, int Npartido)
        {
            nombre = Nombre;
            nacimiento = Nacimiento;
            correo = Correo;
            npartido = Npartido;
        }
        public ClsEncuesta() { }

        public static int AgregarEncuesta(string nombre, DateTime nacimiento, string correo, int npartido)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("agregar_encuesta", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                    cmd.Parameters.Add(new SqlParameter("@fecha_nacimiento", nacimiento));
                    cmd.Parameters.Add(new SqlParameter("@correo", correo));
                    cmd.Parameters.Add(new SqlParameter("@npartido", npartido));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }
    }
}