using System;
using System.Windows.Forms;

namespace SistemaBoletosAereos
{
    public partial class frmPrincipal : Form
    {
        // ESTA LINEA DE CODIGO ES DE MI BASE DE DATOS 
        private DatabaseHelper db = new DatabaseHelper();

        public frmPrincipal()
        {
            InitializeComponent();
            
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
           if (!db.TestConnection())
            {
                MessageBox.Show("Error al conectar con la base de datos", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionUsuarios_Click(object sender, EventArgs e)
        {
            frmGestionUsuarios formUsuarios = new frmGestionUsuarios();
            formUsuarios.ShowDialog(); // Abre como ventana 
        }

        //ABRE EL FORMULARIO DE BUSCAR VUELOS 
        private void btnBuscarVuelos_Click(object sender, EventArgs e)
        {
            frmBuscarVuelos frm = new frmBuscarVuelos();
            frm.ShowDialog();

           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        // DATOS DE LA PERSONA CREADORA DJ
        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            frmAcercaDe acercaDe = new frmAcercaDe();
            acercaDe.ShowDialog();
        }
         
        // AQUI PROBAMOS QUE LA BASE DE DATOS ESTE CORRIENDO ADECUADAMENTE
        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
                try
                {
                    DatabaseHelper db = new DatabaseHelper();
                    if (db.TestConnection())
                    {
                        MessageBox.Show("✅ ¡Conexión a la base de datos EXITOSA!\n\nTu aplicación lista para usar.",
                                      "Conexión Exitosa",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("❌ No se pudo conectar a la base de datos.\n\nRevisa la configuración en DatabaseHelper.cs",
                                      "Error de Conexión",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Error: {ex.Message}", "Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            
        }
    }
}