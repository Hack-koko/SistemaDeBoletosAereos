using SistemaDeBoletosAereos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaBoletosAereos
{
    public partial class frmBuscarVuelos : Form
    {
        private DatabaseHelper db = new DatabaseHelper();

        public frmBuscarVuelos()
        {
            InitializeComponent();
            CargarAerolineas();
            CargarCiudades();

        }

        // CARGAMOS LAS AEROLINEAS YA ESTABLECIDAS 
        private void CargarAerolineas()
        {
            string query = "SELECT id, nombre FROM aerolineas";
            DataTable dt = db.ExecuteQuery(query);
            cmbAerolinea.DataSource = dt;
            cmbAerolinea.DisplayMember = "nombre";
            cmbAerolinea.ValueMember = "id";
        }
        // YA CREADAS ANTERIORMENTE
        private void CargarCiudades()
        {
            string query = "SELECT DISTINCT ciudad_origen FROM rutas UNION SELECT DISTINCT ciudad_destino FROM rutas";
            DataTable dt = db.ExecuteQuery(query);

            cmbOrigen.DataSource = dt.Copy();
            cmbOrigen.DisplayMember = "ciudad_origen";

            cmbDestino.DataSource = dt.Copy();
            cmbDestino.DisplayMember = "ciudad_origen";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = $@"SELECT v.id, a.nombre as aerolinea, 
                            r.ciudad_origen, r.ciudad_destino,
                            v.fecha_salida, v.fecha_llegada,
                            v.tarifa_base, v.asientos_disponibles
                            FROM vuelos v
                            INNER JOIN aerolineas a ON v.aerolinea_id = a.id
                            INNER JOIN rutas r ON v.ruta_id = r.id
                            WHERE r.ciudad_origen = '{cmbOrigen.Text}'
                            AND r.ciudad_destino = '{cmbDestino.Text}'
                            AND DATE(v.fecha_salida) = '{dtpFechaSalida.Value:yyyy-MM-dd}'
                            AND v.asientos_disponibles > 0";

            DataTable dt = db.ExecuteQuery(query);
            dgvVuelos.DataSource = dt;
        }
        // AQUI SE DEBE PONER UN ID EN EL DATAREVIWG 
        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (dgvVuelos.CurrentRow != null)
            {
                // Obtener el ID del vuelo seleccionado
                int vueloId = Convert.ToInt32(dgvVuelos.CurrentRow.Cells["id"].Value);

                frmReserva formulario = new frmReserva(vueloId); // ← Pasa el vueloId
                formulario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un vuelo primero");
            }
        }
    }
}