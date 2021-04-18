using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lnVentas
{
    public class Conexion
    {
        public static DataTable ConexionBD(string sentencia )
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
            "Data Source=localhost;" +
            "Initial Catalog=ventasComercio;" +
            "User id=Natalia;" +
            "Password=123456789;";
            using (SqlConnection con = new SqlConnection(conn.ConnectionString))
            {
                if (con.State == ConnectionState.Closed)
                {
                    conn.Open();
                   
                }
            }
            SqlCommand comando = new SqlCommand(sentencia, conn);
            SqlDataReader registro = comando.ExecuteReader();

            var tb = new DataTable();
            tb.Load(registro);

            conn.Close();
            return tb;
        }
    }
}
