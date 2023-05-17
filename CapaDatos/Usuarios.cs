using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.cache;
namespace CapaDatos.Repositorio
{
    public class Usuarios:RepMaster
    {
        private int Id;
        private string Nombre;
        private string Usuario;
        private string correo;
        private string clave;
        private string telefono;
        
        public int ID { get { return Id; } set { Id = value; } }
        public string nombre { get { return Nombre; } set { Nombre = value; } }
        public string usuario { get { return Usuario; } set { Usuario = value; } }
        public string Correo { get { return correo; } set { correo = value; } }
        public string Clave { get { return clave; } set { clave = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }

        public Usuarios()
        {
            Id = ID;
            Nombre = nombre;
            Usuario =usuario;
            clave = Clave;
            correo = Correo;          
            telefono = Telefono;
        }
        private void AgregarUsuario()
        {
            string TransactSql = "RegistrarUser";
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@Nombre",Nombre));
            parametros.Add(new SqlParameter("@Usuario", Usuario));
            parametros.Add(new SqlParameter("@clave", clave));
            parametros.Add(new SqlParameter("@correo", correo));
            parametros.Add(new SqlParameter("@telefono", Telefono));
            ExecuteNonQuery(TransactSql);

        }

        public string GuardarCambios()
        {
            string mensaje = null;
            try
            {
                AgregarUsuario();
                mensaje = "usuario agregado";
            }
            catch (Exception)
            {
                mensaje = "no se ha podido realizar el movimiento";
            }
            return mensaje;
        }
        public bool Login(string Usuario,string clave)
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = @"select * from Nuevo_Usuario where Usuario=@Usuario and CONVERT(nvarchar(max),DECRYPTBYPASSPHRASE('Password',clave))=@clave";
                    comando.CommandType = CommandType.Text;
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@clave", clave);
                    SqlDataReader lector = comando.ExecuteReader();
                    if (lector.HasRows)
                    {
                        while(lector.Read())
                        {
                            cacheSoft.Id_Usuario = lector.GetInt32(0);

                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
