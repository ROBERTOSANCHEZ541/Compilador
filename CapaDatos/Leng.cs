using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorio
{
    public class Leng:Repositorio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<Leng> VLenguaje()
            {
            List<Leng> oListLeng = new List<Leng>();
            using (var conexion = ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("VerLenguajes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    oListLeng.Add(new Leng
                    {
                        Nombre = Convert.ToString(dr["Nombre"].ToString())
                    });
                    }
                dr.Close();
                }
            return oListLeng;
            }
        }
    }

