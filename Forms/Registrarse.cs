using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.cache;
using CapaDatos.Repositorio;
namespace CompiladoNew.Forms
{
    public partial class Registrarse : Form
    {
        public Registrarse()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios obj = new Usuarios();
            obj.nombre=  TxtN.Text;
            obj.usuario = TxtU.Text;
            obj.Clave =TxtClave.Text;
            obj.Correo = TxtCorreo.Text;
            obj.Telefono = TxtTel.Text;
            obj.ID = cacheSoft.Id_Usuario;
            MessageBox.Show( obj.GuardarCambios());
            Form compilador = new Compilador();
            this.Hide();
            compilador.Show();
        }
      
        private void Registrarse_Load(object sender, EventArgs e)
        {

        }
    }
}
