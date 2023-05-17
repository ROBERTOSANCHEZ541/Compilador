using CapaDatos.cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorio
{
    public class Registro : RepMaster
    {
        private int Id;
        private int Id_Lenguaje ;
        private DateTime fecha_hora;
        private string Name_archivo;

        public int ID { get { return Id; } set { Id = value; } }
        public int ID_Lenguaje { get { return Id_Lenguaje; } set { Id_Lenguaje = value; } }
        public DateTime Fecha_Hora { get { return fecha_hora; } set { fecha_hora = value; } }
        public string Name_Archivo { get { return Name_archivo; } set { Name_archivo = value; } }
        public string Nombre { get; set; }

        public Registro()
        {
            Id = ID;
            Id_Lenguaje = ID_Lenguaje;
            fecha_hora = Fecha_Hora;
            Name_archivo = Name_Archivo;        
        }
        public void AgregarRegistro()
        {
            string TransactSql = "Agg_Registro";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Id_User", Id));
            parametros.Add(new SqlParameter("@Id_Lenguaje", Id_Lenguaje));
            parametros.Add(new SqlParameter("@fecha_hora", fecha_hora));
            parametros.Add(new SqlParameter("@Name_archivo", Name_archivo));
            ExecuteNonQuery(TransactSql);
        }

        public List<Registro> VerIdUser()
        {
            List<Registro> oListLeng = new List<Registro>();
            using (var conexion = ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("VerLenguajes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oListLeng.Add(new Registro
                    {
                        Nombre = Convert.ToString(dr["Nombre"].ToString())
                    });
                }
                dr.Close();
            }
            return oListLeng;    
    }
    public string Agg_archivo()
        {
            string mensaje = null;
            try
            {
                AgregarRegistro();
                mensaje = "archivo agregado";
            }
            catch (Exception)
            {
                mensaje = "no se ha podido realizar el movimiento";
            }
            return mensaje;
        }
        public List<Registro> VerNombres()
        {
            List<Registro> oListName = new List<Registro>();
            using (var conexion = ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("VerNombres", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oListName.Add(new Registro
                    {
                        Nombre = Convert.ToString(dr["Nombre"].ToString())
                    });
                }
                dr.Close();
            }
            return oListName;
        }
    }
}

