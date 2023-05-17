using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos.Repositorio;
namespace CompiladoNew.Forms
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }
        SqlConnection CadenaConexion = new SqlConnection("server=DESKTOP-6ECTDJR\\SQLEXPRESS; database=Compilador; integrated security=true");

        private void Reporte_Load(object sender, EventArgs e)
        {

            string consulta = "select usr.Nombre 'Nombre',Leng.Nombre'Lenguaje', Reg.fecha_hora'DateTime',Reg.Name_archivo'Archivo'from Registro Reg inner join  Nuevo_Usuario usr on Reg.Id = usr.Id inner join Lenguajes Leng on Reg.Id_Lenguaje = Leng.Id ";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, CadenaConexion);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            DGV.DataSource = dt;

            CmbN.DataSource = new Registro().VerNombres();
            CmbN.DisplayMember = "Nombre";
            CmbN.ValueMember = "Nombre";

            CmboxLeng.DataSource = new Leng().VLenguaje();
            CmboxLeng.DisplayMember = "Nombre";
            CmboxLeng.ValueMember = "Nombre";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FiltrarNombre();
        }

        private void FiltrarNombre()
        {

            Usuarios obj = new Usuarios();
            obj.nombre= CmbN.SelectedValue.ToString();
            if (CmbN.SelectedValue.ToString() == obj.nombre)
            {
                string consulta = "select usr.Nombre 'Nombre',Leng.Nombre'Lenguaje', Reg.fecha_hora'DateTime',Reg.Name_archivo'Archivo'from Registro Reg inner join  Nuevo_Usuario usr on Reg.Id = usr.Id inner join Lenguajes Leng on Reg.Id_Lenguaje = Leng.Id ";

                SqlDataAdapter adapter = new SqlDataAdapter(consulta, CadenaConexion);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DGV.DataSource = dt;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (CmboxLeng.SelectedValue.ToString() == "Fortran")
            {
                string consulta = "select usr.Nombre 'Nombre',Leng.Nombre'Lenguaje', Reg.fecha_hora'DateTime',Reg.Name_archivo'Archivo'from Registro Reg inner join  Nuevo_Usuario usr on Reg.Id = usr.Id inner join Lenguajes Leng on Reg.Id_Lenguaje = Leng.Id ";

                SqlDataAdapter adapter = new SqlDataAdapter(consulta, CadenaConexion);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DGV.DataSource = dt;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
                string query = "select * from Registro WHERE fecha_hora =fecha_hora";

                SqlCommand cmd = new SqlCommand(query, CadenaConexion);
                cmd.Parameters.AddWithValue("@fecha_hora", DTPFecha.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DGV.DataSource = dt;             
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)DGV.DataSource;
            dt.Clear();
        }

        public void  ExpDatos(DataGridView DateList)
        {
            Microsoft.Office.Interop.Excel.Application exportarExcel = new Microsoft.Office.Interop.Excel.Application();
            exportarExcel.Application.Workbooks.Add(true);
            int indicecolumna = 0;
            foreach (DataGridViewColumn columna in DateList.Columns )
            {
                indicecolumna++;
                exportarExcel.Cells[1, indicecolumna] = columna.Name;

            }
            int indicefila = 0;
            foreach (DataGridViewRow fila in DateList.Rows)
            {
                indicefila++;
                indicecolumna = 0;
                foreach (DataGridViewColumn columna in DateList.Columns)
                {
                    indicecolumna++;
                    exportarExcel.Cells[indicefila + 1, indicecolumna] = fila.Cells[columna.Name].Value;

                }

            }
            exportarExcel.Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ExpDatos(DGV);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TextWriter wrider = new StreamWriter(@"C:\Users\jeff6\Downloads\FIME\8vo\CompiladoNew\DGV.txt");
            for(int i=0;i<DGV.Rows.Count-1;i++)
            {
                for (int j = 0; j < DGV.Columns.Count - 1; j++)
                {
                    wrider.Write("\t" + DGV.Rows[i].Cells[j].Value.ToString() + "\t" + "|");
                }
                wrider.WriteLine("");
                wrider.WriteLine("-----");
            }
            wrider.Close();
            MessageBox.Show("Data grid exportado");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Fichero CSV (*.csv)|*.csv";
            saveFileDialog1.FileName = "Data Grid";
            saveFileDialog1.Title = "Exportar CSV";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csvMemoria = new StringBuilder();

                //para los títulos de las columnas, encabezado
                for (int i = 0; i < DGV.Columns.Count; i++)
                {
                    if (i == DGV.Columns.Count - 1)
                    {
                        csvMemoria.Append(String.Format("\"{0}\"",
                            DGV.Columns[i].HeaderText));
                    }
                    else
                    {
                        csvMemoria.Append(String.Format("\"{0}\",",
                            DGV.Columns[i].HeaderText));
                    }
                }
                csvMemoria.AppendLine();


                for (int m = 0; m < DGV.Rows.Count; m++)
                {
                    for (int n = 0; n < DGV.Columns.Count; n++)
                    {
                        //si es la última columna no poner el ;
                        if (n == DGV.Columns.Count - 1)
                        {
                            csvMemoria.Append(String.Format("\"{0}\"",
                                 DGV.Rows[m].Cells[n].Value));
                        }
                        else
                        {
                            csvMemoria.Append(String.Format("\"{0}\",",
                                DGV.Rows[m].Cells[n].Value));
                        }
                    }
                    csvMemoria.AppendLine();
                }
                System.IO.StreamWriter sw =
                    new System.IO.StreamWriter(saveFileDialog1.FileName, false,
                       System.Text.Encoding.Default);
                sw.Write(csvMemoria.ToString());
                sw.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CmbN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

