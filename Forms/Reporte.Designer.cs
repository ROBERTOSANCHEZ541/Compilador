namespace CompiladoNew.Forms
{
    partial class Reporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGV = new System.Windows.Forms.DataGridView();
            this.CmbN = new System.Windows.Forms.ComboBox();
            this.CmboxLeng = new System.Windows.Forms.ComboBox();
            this.DTPFecha = new System.Windows.Forms.DateTimePicker();
            this.PbExcel = new System.Windows.Forms.PictureBox();
            this.PbClean = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PbTxt = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.PBCsv = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbClean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTxt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBCsv)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Location = new System.Drawing.Point(12, 31);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(776, 407);
            this.DGV.TabIndex = 0;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // CmbN
            // 
            this.CmbN.FormattingEnabled = true;
            this.CmbN.Location = new System.Drawing.Point(46, 4);
            this.CmbN.Name = "CmbN";
            this.CmbN.Size = new System.Drawing.Size(121, 21);
            this.CmbN.TabIndex = 1;
            this.CmbN.SelectedIndexChanged += new System.EventHandler(this.CmbN_SelectedIndexChanged);
            // 
            // CmboxLeng
            // 
            this.CmboxLeng.FormattingEnabled = true;
            this.CmboxLeng.Location = new System.Drawing.Point(211, 4);
            this.CmboxLeng.Name = "CmboxLeng";
            this.CmboxLeng.Size = new System.Drawing.Size(121, 21);
            this.CmboxLeng.TabIndex = 3;
            // 
            // DTPFecha
            // 
            this.DTPFecha.Location = new System.Drawing.Point(362, 4);
            this.DTPFecha.Name = "DTPFecha";
            this.DTPFecha.Size = new System.Drawing.Size(200, 20);
            this.DTPFecha.TabIndex = 5;
            this.DTPFecha.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // PbExcel
            // 
            this.PbExcel.BackColor = System.Drawing.Color.DarkGreen;
            this.PbExcel.Image = global::CompiladoNew.Properties.Resources.excel;
            this.PbExcel.Location = new System.Drawing.Point(680, 4);
            this.PbExcel.Name = "PbExcel";
            this.PbExcel.Size = new System.Drawing.Size(26, 21);
            this.PbExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbExcel.TabIndex = 8;
            this.PbExcel.TabStop = false;
            this.PbExcel.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // PbClean
            // 
            this.PbClean.Image = global::CompiladoNew.Properties.Resources._3792081_broom_halloween_magic_witch_109049;
            this.PbClean.Location = new System.Drawing.Point(648, 3);
            this.PbClean.Name = "PbClean";
            this.PbClean.Size = new System.Drawing.Size(26, 21);
            this.PbClean.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbClean.TabIndex = 7;
            this.PbClean.TabStop = false;
            this.PbClean.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CompiladoNew.Properties.Resources.icons8_filtrar_48;
            this.pictureBox3.Location = new System.Drawing.Point(336, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(26, 21);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CompiladoNew.Properties.Resources.search_find_lupa_21889;
            this.pictureBox2.Location = new System.Drawing.Point(179, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CompiladoNew.Properties.Resources.search_find_lupa_21889;
            this.pictureBox1.Location = new System.Drawing.Point(13, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PbTxt
            // 
            this.PbTxt.BackColor = System.Drawing.Color.DarkGreen;
            this.PbTxt.Image = global::CompiladoNew.Properties.Resources.icons8_verificar_documento_64;
            this.PbTxt.Location = new System.Drawing.Point(712, 4);
            this.PbTxt.Name = "PbTxt";
            this.PbTxt.Size = new System.Drawing.Size(26, 21);
            this.PbTxt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbTxt.TabIndex = 9;
            this.PbTxt.TabStop = false;
            this.PbTxt.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // PBCsv
            // 
            this.PBCsv.BackColor = System.Drawing.Color.DarkGreen;
            this.PBCsv.Image = global::CompiladoNew.Properties.Resources.guardar;
            this.PBCsv.Location = new System.Drawing.Point(744, 3);
            this.PBCsv.Name = "PBCsv";
            this.PBCsv.Size = new System.Drawing.Size(26, 21);
            this.PBCsv.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBCsv.TabIndex = 10;
            this.PBCsv.TabStop = false;
            this.PBCsv.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CompiladoNew.Properties.Resources.istockphoto_1270261573_612x612;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PBCsv);
            this.Controls.Add(this.PbTxt);
            this.Controls.Add(this.PbExcel);
            this.Controls.Add(this.PbClean);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.DTPFecha);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.CmboxLeng);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CmbN);
            this.Controls.Add(this.DGV);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbClean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbTxt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBCsv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.ComboBox CmbN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox CmboxLeng;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker DTPFecha;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox PbClean;
        private System.Windows.Forms.PictureBox PbExcel;
        private System.Windows.Forms.PictureBox PbTxt;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox PBCsv;
    }
}