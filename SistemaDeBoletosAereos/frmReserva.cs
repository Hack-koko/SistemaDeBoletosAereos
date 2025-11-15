using SistemaDeBoletosAereos;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaBoletosAereos
{
    public partial class frmReserva : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int vueloId;
        private decimal tarifaBase;

        public frmReserva(int vueloId)
        {
            InitializeComponent();
            this.vueloId = vueloId;
            CargarDatosVuelo();
        }
        
        private void CargarDatosVuelo()
        {
            string query = $@"SELECT v.*, a.nombre as aerolinea, 
                            r.ciudad_origen, r.ciudad_destino
                            FROM vuelos v
                            INNER JOIN aerolineas a ON v.aerolinea_id = a.id
                            INNER JOIN rutas r ON v.ruta_id = r.id
                            WHERE v.id = {vueloId}";

            DataTable dt = db.ExecuteQuery(query);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                lblAerolinea.Text = row["aerolinea"].ToString();
                lblRuta.Text = $"{row["ciudad_origen"]} - {row["ciudad_destino"]}";
                lblFechaSalida.Text = Convert.ToDateTime(row["fecha_salida"]).ToString("dd/MM/yyyy HH:mm");
                tarifaBase = Convert.ToDecimal(row["tarifa_base"]);
                lblTarifaBase.Text = tarifaBase.ToString("C");
                CalcularTotal();
            }
        }
        // CALCULAR EL TOTAL 

        private void CalcularTotal()
        {
            decimal total = tarifaBase;

            if (chkEquipajeMano.Checked)
            {
                total += tarifaBase * 0.10m;
            }

            if (chkEquipajeBodega.Checked)
            {
                total += tarifaBase * 0.20m;
            }

            lblTotal.Text = total.ToString("C");
        }

        private decimal CalcularTotalFinal()
        {
            decimal total = tarifaBase;

            if (chkEquipajeMano.Checked)
            {
                total += tarifaBase * 0.10m;
            }

            if (chkEquipajeBodega.Checked)
            {
                total += tarifaBase * 0.20m;
            }

            return total;
        }

        private void chkEquipajeMano_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void chkEquipajeBodega_CheckedChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void btnConfirmarReserva_Click(object sender, EventArgs e)
        {
            try
            {
                //  1. PRIMERO validar los datos
                if (!ValidarDatosReserva())
                {
                    return; // Si la validación falla, se detiene aquí
                }

                //  2. Calcular el total final
                decimal total = CalcularTotalFinal();

                // 3. Insertar la reserva en la base de datos
                string queryReserva = $@"INSERT INTO reservas 
                                (vuelo_id, nombre_pasajero, equipaje_mano, equipaje_bodega, total_pago, estado) 
                                VALUES 
                                ({vueloId}, '{txtNombrePasajero.Text.Trim()}', 
                                {(chkEquipajeMano.Checked ? 1 : 0)}, 
                                {(chkEquipajeBodega.Checked ? 1 : 0)}, 
                                {total}, 'confirmada')";

                int resultado = db.ExecuteNonQuery(queryReserva);

                if (resultado > 0)
                {
                    //  4. Actualizar asientos disponibles
                    string actualizarAsientos = $@"UPDATE vuelos 
                                         SET asientos_disponibles = asientos_disponibles - 1 
                                         WHERE id = {vueloId}";
                    db.ExecuteNonQuery(actualizarAsientos);

                    //  5. Mostrar confirmación
                    MessageBox.Show($"✅ RESERVA CONFIRMADA EXITOSAMENTE!\n\n" +
                                  $"Pasajero: {txtNombrePasajero.Text}\n" +
                                  $"Vuelo: {lblRuta.Text}\n" +
                                  $"Aerolínea: {lblAerolinea.Text}\n" +
                                  $"Fecha: {lblFechaSalida.Text}\n" +
                                  $"Total Pagado: {total.ToString("C")}",
                                  "Reserva Confirmada",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);

                    // 6. Cerrar formulario
                    this.Close();
                }
                else
                {
                    MessageBox.Show("❌ Error al guardar la reserva en la base de datos", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al confirmar reserva: {ex.Message}", "Error");
            }
        }
        private bool ValidarDatosReserva()
        {
            if (string.IsNullOrWhiteSpace(txtNombrePasajero.Text))
            {
                MessageBox.Show("❌ Ingrese el nombre del pasajero", "Error");
                txtNombrePasajero.Focus();
                return false;
            }

            if (txtNombrePasajero.Text.Trim().Length < 3)
            {
                MessageBox.Show("❌ El nombre debe tener al menos 3 caracteres", "Error");
                txtNombrePasajero.Focus();
                return false;
            }

            if (vueloId <= 9)
            {
                MessageBox.Show("❌ No hay un vuelo seleccionado", "Error");
                return false;
            }

            return true;
        }
    }
}