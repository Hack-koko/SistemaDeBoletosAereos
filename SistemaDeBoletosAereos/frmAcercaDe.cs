using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaBoletosAereos
{
    public partial class frmAcercaDe : Form
    {
        public frmAcercaDe()
        {
            InitializeComponent();
        }

        private void frmAcercaDe_Load(object sender, EventArgs e)
        { 
            // Configurar los controles con la información
            lblTitulo.Text = "Sistema de Boletos Aéreos";
            lblVersion.Text = $"Versión {Application.ProductVersion}";
            lblCopyright.Text = "Copyright © 2025";
            lblDesarrollador.Text = "Desarrollado por: DJ David Vasquez VM23050";
        }

    private void btnAceptar_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
}