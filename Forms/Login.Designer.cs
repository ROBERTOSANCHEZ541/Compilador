namespace CompiladoNew
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PBGif = new System.Windows.Forms.PictureBox();
            this.LblUser = new System.Windows.Forms.Label();
            this.LblClave = new System.Windows.Forms.Label();
            this.UsuarioTxt = new System.Windows.Forms.TextBox();
            this.Clave = new System.Windows.Forms.TextBox();
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.LLRegistro = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PBGif)).BeginInit();
            this.SuspendLayout();
            // 
            // PBGif
            // 
            this.PBGif.BackColor = System.Drawing.Color.Transparent;
            this.PBGif.Image = global::CompiladoNew.Properties.Resources.icons8_conferencia;
            this.PBGif.Location = new System.Drawing.Point(156, 12);
            this.PBGif.Name = "PBGif";
            this.PBGif.Size = new System.Drawing.Size(120, 120);
            this.PBGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PBGif.TabIndex = 0;
            this.PBGif.TabStop = false;
            this.PBGif.Click += new System.EventHandler(this.PBGif_Click);
            // 
            // LblUser
            // 
            this.LblUser.AutoSize = true;
            this.LblUser.BackColor = System.Drawing.Color.Transparent;
            this.LblUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUser.ForeColor = System.Drawing.Color.White;
            this.LblUser.Location = new System.Drawing.Point(12, 172);
            this.LblUser.Name = "LblUser";
            this.LblUser.Size = new System.Drawing.Size(69, 19);
            this.LblUser.TabIndex = 1;
            this.LblUser.Text = "Usuario:";
            this.LblUser.Click += new System.EventHandler(this.LblUser_Click);
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.BackColor = System.Drawing.Color.Transparent;
            this.LblClave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClave.ForeColor = System.Drawing.Color.White;
            this.LblClave.Location = new System.Drawing.Point(10, 238);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(102, 19);
            this.LblClave.TabIndex = 2;
            this.LblClave.Text = "Contraseña:";
            // 
            // UsuarioTxt
            // 
            this.UsuarioTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsuarioTxt.Location = new System.Drawing.Point(118, 172);
            this.UsuarioTxt.Name = "UsuarioTxt";
            this.UsuarioTxt.Size = new System.Drawing.Size(292, 27);
            this.UsuarioTxt.TabIndex = 3;
            // 
            // Clave
            // 
            this.Clave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clave.Location = new System.Drawing.Point(118, 238);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(292, 27);
            this.Clave.TabIndex = 4;
            this.Clave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Clave_KeyPress);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnIniciar.FlatAppearance.BorderSize = 0;
            this.BtnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniciar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniciar.Location = new System.Drawing.Point(81, 331);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(270, 26);
            this.BtnIniciar.TabIndex = 5;
            this.BtnIniciar.Text = "Iniciar Sesión";
            this.BtnIniciar.UseVisualStyleBackColor = false;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            // 
            // linkLabel1
            // 
            this.LLRegistro.AutoSize = true;
            this.LLRegistro.Location = new System.Drawing.Point(191, 268);
            this.LLRegistro.Name = "linkLabel1";
            this.LLRegistro.Size = new System.Drawing.Size(60, 13);
            this.LLRegistro.TabIndex = 6;
            this.LLRegistro.TabStop = true;
            this.LLRegistro.Text = "Registrarse";
            this.LLRegistro.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLRegistro_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::CompiladoNew.Properties.Resources.istockphoto_1270261573_612x612;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(422, 406);
            this.Controls.Add(this.LLRegistro);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.Clave);
            this.Controls.Add(this.UsuarioTxt);
            this.Controls.Add(this.LblClave);
            this.Controls.Add(this.LblUser);
            this.Controls.Add(this.PBGif);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PBGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBGif;
        private System.Windows.Forms.Label LblUser;
        private System.Windows.Forms.Label LblClave;
        private System.Windows.Forms.TextBox UsuarioTxt;
        private System.Windows.Forms.TextBox Clave;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.LinkLabel LLRegistro;
    }
}

