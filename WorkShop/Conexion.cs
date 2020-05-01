using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WorkShop
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            //funciona
            // return new SqlConnection(Properties.Settings.Default.conexion);
            //SqlConnection conexion = new SqlConnection(Properties.Settings.Default.conexion);
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-PF2MAMK;Initial Catalog=Planilla;Integrated Security=True;MultipleActiveResultSets=True");
            //abrimos la conexion
            conexion.Open();
            return conexion;
        }
    }
}
