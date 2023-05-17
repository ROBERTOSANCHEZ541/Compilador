using CapaDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompiladoNew.Forms;
using CapaDatos.cache;
using System.Data.SqlClient;

namespace CompiladoNew.Forms
{
    public partial class Compilador : Form
    {
        int estado, columna, posicion, direccion, Entero;
        string tokens, wline, wsalida;
        char caracter;
        int Renglon = 0;   
        int[,] matriz;
      

        Boolean EsPReservada;
        public Compilador()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection("server=DESKTOP-6ECTDJR\\SQLEXPRESS; database=Compilador; integrated security=true");
        public object usuario;
        public object lenguaje;

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string archivo = openFileDialog1.FileName;
                using (StreamReader fileReader = new StreamReader(archivo))
                {
                    string stringReader;
                    while ((stringReader = fileReader.ReadLine()) != null)
                    {
                        ListBox1.Items.Add(stringReader);
                    }
                }
            }
        }
        private void LimpiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            ListBox3.Items.Clear();
            ListBox4.Items.Clear();
            ListBox5.Items.Clear();
            ListBox6.Items.Clear();
            ListBox7.Items.Clear();
        }

        public string SacarIdUser(object usuario)
        {
            string idusuario;
            string query = " select Id from Nuevo_Usuario where Usuario=@Usuario";
            conexion.Open();
            SqlCommand cmd = new SqlCommand(query, conexion);
            string NameUser = Login.variableCompartida;
            cmd.Parameters.AddWithValue("@Usuario", NameUser);
            object result = cmd.ExecuteScalar();
            idusuario = result.ToString();
            conexion.Close();
            return idusuario;
        }
        public string IdLeng(object lenguaje)
        {
            string idLeng;
            string query = "select Id from Lenguajes where Nombre=@Nombre";
            conexion.Open();
            SqlCommand cmd = new SqlCommand(query, conexion);
            string name = comboBox1.Text;
            cmd.Parameters.AddWithValue("@Nombre", name);
            object result = cmd.ExecuteScalar();
            idLeng = result.ToString();
            conexion.Close();
            return idLeng;
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {  
            while (Renglon < ListBox1.Items.Count)
            {
                ListBox1.SelectedIndex = Renglon;
                wline = ListBox1.Text;
                buscaTokens();
                Renglon = Renglon + 1;
            } 
                    string NombreU =Login.variableCompartida;
                    string NombreL =comboBox1.Text;
                    string NomTxt = $"output_{NombreL}_{NombreU}_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.txt";
                string ruta =(@"C:\Users\jeff6\Downloads\FIME\8vo\CompiladoNew\");           
            StreamWriter sw = new StreamWriter(Path.Combine(ruta, NomTxt));
                   foreach (object lista in ListBox2.Items)
            {
                sw.WriteLine(lista.ToString());
            }
            sw.Close();
            MessageBox.Show("Archivo creado y guardado");
            string Idusuario = SacarIdUser(usuario);
            int ID_User = Convert.ToInt32(Idusuario);
            string IDleng = IdLeng(lenguaje);
            int ID_Leng = Convert.ToInt32(IDleng);
            
            conexion.Open();
            SqlCommand cmdReg = new SqlCommand("Agg_Registro", conexion);
            cmdReg.CommandType = CommandType.StoredProcedure;
            cmdReg.Parameters.AddWithValue("@Id_User", ID_User);
            cmdReg.Parameters.AddWithValue("@Id_Lenguaje", ID_Leng);
            cmdReg.Parameters.AddWithValue("@fecha_hora", DateTime.Now);
            cmdReg.Parameters.AddWithValue("@Name_archivo", NomTxt);
            try
            {
                MessageBox.Show("registro agregado");
                cmdReg.ExecuteNonQuery();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.ToString());
                throw;

            }
            conexion.Close();
            Form Reporte = new Reporte();
            this.Hide();
            Reporte.Show();
        }

        

        private void Compilador_Load(object sender, EventArgs e)
        {        
            comboBox1.DataSource = new Leng().VLenguaje();
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Nombre";
           
        }
        private void ListarLeng()
        {        
            if (comboBox1.SelectedValue.ToString() == "Fortran")
            {
                //carga PalabrasReserv                 
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRfortran.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz                  
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\mtzF.csv");
                matriz = new int[13, 22];
                for (int i = 0; i < 13; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 22)
                    {
                       MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {22}.");
                        continue;
                    }
                    for (int j = 0; j < 22; j++)
                    {
                        if (i < 0 || i > 13 || j < 0 || j > 22)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i,j] = int.Parse(lineData[j]);
                    }
                }
                
            }
            else if (comboBox1.SelectedValue.ToString() == "C")
            {
                //carga PalabrasReserv
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRC.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }           
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MatrizC.csv");
                int[,] matriz = new int[11, 20];
                for (int i = 0; i < 11; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 20)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {20}.");
                        continue;
                    }
                    for (int j = 0; j < 20; j++)
                    {
                        if (i < 0 || i > 11 || j < 0 || j > 20)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }
            else  if (comboBox1.Text == "Cobol")
            {    
                    string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRcobol.txt");

                    ListBox3.Items.Add(lines3);
                    foreach (string line3 in lines3)
                    {
                        ListBox3.Items.Add(line3);
                    }
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MatrizCobol.csv");
                int[,] matriz = new int[11, 20];
                for (int i = 0; i < 11; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 20)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {20}.");
                        continue;
                    }
                    for (int j = 0; j < 20; j++)
                    {
                        if (i < 0 || i > 11 || j < 0 || j > 20)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }

            }
            else if (comboBox1.Text== "Pascale")
            {
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRpascal.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MatrizPascal.csv");
                int[,] matriz = new int[12, 27];
                for (int i = 0; i < 12; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 27)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {27}.");
                        continue;
                    }
                    for (int j = 0; j < 27; j++)
                    {
                        if (i < 0 || i > 12 || j < 0 || j > 27)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }             
            else if (comboBox1.Text == "BASIC_")
            {
                //carga PalabrasReserv
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRbasic.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MtzB.csv");
                int[,] matriz = new int[9, 16];
                for (int i = 0; i < 9; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 16)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {16}.");
                        continue;
                    }
                    for (int j = 0; j < 16; j++)
                    {
                        if (i < 0 || i > 9 || j < 0 || j > 16)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }
            else if (comboBox1.Text == "V_Foxpro")
            {
                //carga PalabrasReserv
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRVF.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MtzVF.csv");
                int[,] matriz = new int[8, 19];
                for (int i = 0; i < 8; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 19)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {19}.");
                        continue;
                    }
                    for (int j = 0; j < 19; j++)
                    {
                        if (i < 0 || i > 8 || j < 0 || j > 19)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }
            else if (comboBox1.Text == "Clipper")
            {
                //carga PalabrasReserv
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRClipper.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MatrizClipper.csv");
                int[,] matriz = new int[11, 20];
                for (int i = 0; i < 11; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 20)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {20}.");
                        continue;
                    }
                    for (int j = 0; j < 20; j++)
                    {
                        if (i < 0 || i > 11 || j < 0 || j > 20)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }
            else if (comboBox1.Text == "Dbase")
            {
                //carga PalabrasReserv
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRdbase.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz                   
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MatrizDbase.csv");
                int[,] matriz = new int[15, 24];
                for (int i = 0; i < 15; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 24)
                    {
                        Console.WriteLine($"Error: Line {i + 1} contains {lineData.Length} values instead of {24}.");
                        continue;
                    }
                    for (int j = 0; j < 24; j++)
                    {
                        if (i < 0 || i > 15 || j < 0 || j > 24)
                        {
                            Console.WriteLine($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }
            else if (comboBox1.Text == "phyton")
            {
                //carga PalabrasReserv
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRP.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz                   
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MtzP.csv");
                int[,] matriz = new int[10, 14];
                for (int i = 0; i < 10; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 14)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {14}.");
                        continue;
                    }
                    for (int j = 0; j < 14; j++)
                    {
                        if (i < 0 || i > 10 || j < 0 || j > 14)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }
            else if (comboBox1.Text == "Visual Basic")
            {
                //carga PalabrasReserv
                string[] lines3 = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\Solution1\\PalabrasRes\\PRVB.txt");
                ListBox3.Items.Add(lines3);
                foreach (string line3 in lines3)
                {
                    ListBox3.Items.Add(line3);
                }
                //carga la matriz                   
                string[] lines = File.ReadAllLines("C:\\Users\\jeff6\\Downloads\\FIME\\8vo\\CompiladoNew\\CompiladoNew\\bin\\Debug\\Matrices\\MatrizVB.csv");
                int[,] matriz = new int[9,14];
                for (int i = 0; i < 9; i++)
                {
                    string[] lineData = lines[i].Split(',');
                    if (lineData.Length != 14)
                    {
                        MessageBox.Show($"Error: Line {i + 1} contains {lineData.Length} values instead of {14}.");
                        continue;
                    }
                    for (int j = 0; j < 14; j++)
                    {
                        if (i < 0 || i > 9 || j < 0 || j > 14)
                        {
                            MessageBox.Show($"Error: Index out of bounds: [{i - 1}, {j}].");
                            continue;
                        }
                        matriz[i, j] = int.Parse(lineData[j]);
                    }
                }
            }
            
        }   
        private void buscaTokens()
        {
            string apoyo;
            estado = 0;
            tokens = "";
            posicion = 1;
            while (posicion <= wline.Length)
            {
                apoyo = wline.Substring(posicion - 1, 1); 
                caracter = apoyo.FirstOrDefault();
                calculacolumna();
                estado = matriz[estado, columna];
                string eto = estado.ToString();
                 if (estado >= 100)
                {
                    if (tokens.Length >= 0)
                    {
                        ReconoceTokens();
                    }
                    estado = 0;
                    tokens = "";
                    ListBox1.Items.Add(tokens);
                }
                else
                {
                    if (estado != 0)
                    {
                        tokens = tokens + caracter;
                    }
                }
                posicion++;
            }
            if (tokens.Length > 0)
            {
                caracter = ' ';
                calculacolumna();
                estado = matriz[estado, columna];
                ReconoceTokens();
            }
        }
        private void ListBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void calculacolumna()
        {
            if (char.IsLetter(caracter))
            {
                columna = 0;
            }
            else if (caracter == '_')
            {
                columna = 1;
            }
            else if (char.IsDigit(caracter))
            {
                columna = 2;
            }
            else if (caracter == '.')
            {
                columna = 3;
            }
            else if (caracter == ' ' || caracter == '\0')
            {
                columna = 4;
            }
            else if (caracter == '*')
            {
                columna = 5;
            }
            else if (caracter == '/')
            {
                columna = 6;
            }
            else if (caracter == '-')
            {
                columna = 7;
            }
            else if (caracter == '+')
            {
                columna = 8;
            }
            else if (caracter == '=')
            {
                columna = 9;
            }
            else if (caracter == ':')
            {
                columna = 10;
            }
            else if (caracter == '±')
            {
                columna = 11;
            }
            else if (caracter == '´')
            {
                columna = 12;
            }
            else if (caracter == '"')
            {
                columna = 13;
            }
            else if (caracter == '<')
            {
                columna = 14;
            }
            else if (caracter == '>')
            {
                columna = 15;
            }
            else if (caracter == '$')
            {
                columna = 16;
            }
            else if (caracter == '!')
            {
                columna = 17;
            }
            else if (caracter == ';')
            {
                columna = 18;
            }
            else if (caracter == '&')
            {
                columna = 19;
            }
            else if (caracter == '(')
            {
                columna = 20;
            }
            else if (caracter == ')')
            {
                columna = 21;
            }
        }
        private void EXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListarLeng();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void BuscaPalReservadas()
        {
            int Renglon2 = 0;
            direccion = -1;

            while (!EsPReservada && Renglon2 < ListBox3.Items.Count)
            {
                ListBox3.SelectedIndex = Renglon2;

                if (string.Equals(tokens, ListBox3.Text, StringComparison.OrdinalIgnoreCase))
                {
                    EsPReservada = true;
                    direccion = Renglon2;
                }
                if (EsPReservada == true)
                {

                }              
                Renglon2=Renglon2+1;
            }
        }
        private void ReconoceTokens()
        {
            if (estado == 100)
            {
                EsPReservada = false;
                BuscaPalReservadas();

                if (EsPReservada)
                {
                    wsalida = tokens + " PR " + direccion.ToString();
                }
                else
                {
                    BuscaIdentificador();
                    wsalida = tokens + " ID " + direccion.ToString();
                }

                posicion--;
            }

            if (estado == 101)
            {
                BuscaEnteros();
                wsalida = tokens + " Cte.Ent " + direccion.ToString();
                posicion--;
            }

            if (estado == 102)
            {
                BuscaReales();
                wsalida = tokens + " Cte.Real " + direccion.ToString();
                posicion--;
            }

            if (estado == 114)
            {
                BuscaString();
                wsalida = tokens + " Cte.String " + direccion.ToString();
            }

            if (estado == 103)
            {
                wsalida = tokens + " Comentario ";
            }

            if (estado == 104)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 105)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 106)
            {
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 107)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 108)
            {
                wsalida = tokens + " C.Especial ";
                posicion--;
            }

            if (estado == 109)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 110)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 111)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 112)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
            }

            if (estado == 113)
            {
                wsalida = tokens + " C.Especial ";
                posicion--;
            }

            if (estado == 114)
            {
                tokens += caracter;
                wsalida = tokens + " Ctr.String ";
            }

            if (estado == 115)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
                posicion--;
            }

            if (estado == 116)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial ";
                posicion--;
            }

            if (estado == 117)
            {
                tokens += caracter;
                wsalida = tokens + " C.Especial";
                posicion--;
            } 
                if (estado == 118)
                {
                    tokens += caracter;
                    wsalida = tokens + " C.Especial ";
                    posicion--;
                }
                if (estado == 119)
                {
                    tokens += caracter;
                    wsalida = tokens + " C.Especial ";
                }
                if (estado == 120)
                {
                    tokens += caracter;
                    wsalida = tokens + " C.Especial ";
                }
                if (estado == 121)
                {
                    tokens += caracter;
                    wsalida = tokens + " C.Especial ";
                }
                if (estado == 122)
                {
                    tokens += caracter;
                    wsalida = tokens + " C.Especial ";
                }
                if (estado == 123)
                {
                    tokens += caracter;
                    wsalida = tokens + " C.Especial ";
                }
                if (estado == 124)
                {
                    tokens += caracter;
                    wsalida = tokens + " C.Especial ";
                }
            ListBox2.Items.Add(wsalida);             
            }
        private void BuscaEnteros()
        {
            bool encontro = false;
            int renglon2 = 0;
            while (!encontro && renglon2 < ListBox5.Items.Count)
            {
                ListBox5.SelectedIndex = renglon2;
                if (string.Equals(tokens, ListBox5.Text, StringComparison.OrdinalIgnoreCase))
                {
                    encontro = true;
                    direccion = renglon2;
                }

                renglon2++;
            }
            if (!encontro)
            {
                ListBox5.Items.Add(tokens);
                direccion = ListBox5.Items.Count - 1;
            }
        }
        private void BuscaReales()
        {
            bool Encontro = false;
            int Renglon2 = 0;
            while (!Encontro && Renglon2 < ListBox6.Items.Count)
            {
                ListBox6.SelectedIndex = Renglon2;
                if (tokens.ToUpper() == ListBox6.Text.ToUpper())
                {
                    Encontro = true;
                    direccion = Renglon2;
                }
                Renglon2++;
            }

            if (!Encontro)
            {
                ListBox6.Items.Add(tokens);
                direccion = ListBox6.Items.Count - 1;
            }
        }
        private void BuscaString()
        {
            bool encontro = false;
            int renglon2 = 0;

            while (!encontro && renglon2 < ListBox7.Items.Count)
            {
                ListBox7.SelectedIndex = renglon2;
                if (string.Equals(tokens.ToUpper(), ListBox7.Text.ToUpper()))
                {
                    encontro = true;
                    direccion = renglon2;
                }
                renglon2++;
            }

            if (!encontro)
            {
                ListBox7.Items.Add(tokens);
                direccion = ListBox7.Items.Count - 1;
            }
        }
        private void BuscaIdentificador()
        {
            bool Encontro = false;
            int Renglon2 = 0;

            while (!Encontro && Renglon2 < ListBox4.Items.Count)
            {
                ListBox4.SelectedIndex = Renglon2;
                if (tokens.ToUpper() == ListBox4.Text.ToUpper())
                {
                    Encontro = true;
                    direccion = Renglon2;
                }
                Renglon2++;
            }

            if (!Encontro)
            {
                ListBox4.Items.Add(tokens);
                direccion = ListBox4.Items.Count - 1;
            }
        }

    }
}
        
