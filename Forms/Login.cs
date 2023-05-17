using CompiladoNew.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Repositorio;
namespace CompiladoNew
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        internal static string variableCompartida;

        private void Login_Load(object sender, EventArgs e)
        {
        }

        private void LblUser_Click(object sender, EventArgs e)
        {

        }

        private void LLRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form registrarse = new Registrarse();
            this.Hide();
            registrarse.Show();
            
            
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            Usuarios obj = new Usuarios();
            bool Valido=obj.Login(UsuarioTxt.Text, Clave.Text);
            variableCompartida = UsuarioTxt.Text;
            if (Valido)
            {
                Form compilador = new Compilador();
                this.Hide();
                compilador.Show();
             
            }
            else
            {
                MessageBox.Show("Usuario /contraseña incorrecto");
            }
            
        }

        private void Clave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                BtnIniciar_Click(sender, e);//llama al evento click del boton
            }
        }

        private void PBGif_Click(object sender, EventArgs e)
        {

        }
    }
}
