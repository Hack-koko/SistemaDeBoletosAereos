
namespace SistemaBoletosAereos
{
    partial class frmPrincipal
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
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnBuscarVuelos = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnProbarConexion = new System.Windows.Forms.Button();
            this.btnAcercaDe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnGestionUsuarios.Location = new System.Drawing.Point(37, 37);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(118, 50);
            this.btnGestionUsuarios.TabIndex = 0;
            this.btnGestionUsuarios.Text = "Gestion Usuarios";
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnBuscarVuelos
            // 
            this.btnBuscarVuelos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarVuelos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBuscarVuelos.Location = new System.Drawing.Point(190, 37);
            this.btnBuscarVuelos.Name = "btnBuscarVuelos";
            this.btnBuscarVuelos.Size = new System.Drawing.Size(118, 50);
            this.btnBuscarVuelos.TabIndex = 1;
            this.btnBuscarVuelos.Text = "Buscar Vuelos";
            this.btnBuscarVuelos.UseVisualStyleBackColor = true;
            this.btnBuscarVuelos.Click += new System.EventHandler(this.btnBuscarVuelos_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSalir.Location = new System.Drawing.Point(338, 37);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 50);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnProbarConexion
            // 
            this.btnProbarConexion.Location = new System.Drawing.Point(296, 192);
            this.btnProbarConexion.Name = "btnProbarConexion";
            this.btnProbarConexion.Size = new System.Drawing.Size(90, 50);
            this.btnProbarConexion.TabIndex = 3;
            this.btnProbarConexion.Text = "Prueba SQL";
            this.btnProbarConexion.UseVisualStyleBackColor = true;
            this.btnProbarConexion.Click += new System.EventHandler(this.btnProbarConexion_Click);
            // 
            // btnAcercaDe
            // 
            this.btnAcercaDe.Location = new System.Drawing.Point(444, 192);
            this.btnAcercaDe.Name = "btnAcercaDe";
            this.btnAcercaDe.Size = new System.Drawing.Size(90, 50);
            this.btnAcercaDe.TabIndex = 4;
            this.btnAcercaDe.Text = "Acerca De";
            this.btnAcercaDe.UseVisualStyleBackColor = true;
            this.btnAcercaDe.Click += new System.EventHandler(this.btnAcercaDe_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 254);
            this.Controls.Add(this.btnAcercaDe);
            this.Controls.Add(this.btnProbarConexion);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBuscarVuelos);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Button btnBuscarVuelos;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnProbarConexion;
        private System.Windows.Forms.Button btnAcercaDe;
    }
}