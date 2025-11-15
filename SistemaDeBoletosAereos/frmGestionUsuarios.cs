using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaBoletosAereos
{
    public partial class frmGestionUsuarios : Form
    {
      private DatabaseHelper db = new DatabaseHelper();

        public frmGestionUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        // cargamos los datos preinstalados 
        private void CargarUsuarios()
        {
            string query = "SELECT id, nombre, email, telefono, fecha_registro FROM usuarios";
            DataTable dt = db.ExecuteQuery(query);
           dgvUsuarios.DataSource = dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                string query = $@"INSERT INTO usuarios (nombre, email, password, telefono) 
                                VALUES ('{txtNombre.Text}', '{txtEmail.Text}', 
                                '{txtPassword.Text}', '{txtTelefono.Text}')";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Usuario agregado exitosamente", "Éxito");
                    LimpiarControles();
                    CargarUsuarios();
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
               // int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["id"].Value);
                string query = $@"UPDATE usuarios SET 
                                nombre = '{txtNombre.Text}',
                                email = '{txtEmail.Text}',
                                telefono = '{txtTelefono.Text}'
                                WHERE id = ";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Usuario modificado exitosamente", "Éxito");
                    CargarUsuarios();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["id"].Value);
                string query = $"DELETE FROM usuarios WHERE id = {id}";

                if (db.ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Usuario eliminado exitosamente", "Éxito");
                    CargarUsuarios();
                }
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                DataGridViewRow row = dgvUsuarios.CurrentRow;
                txtNombre.Text = row.Cells["nombre"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtTelefono.Text = row.Cells["telefono"].Value?.ToString() ?? "";
            }
        }
        // sirve para validad los datos que se ingresan
        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre", "Error");
                return false;
            }
            return true;
        }

        private void LimpiarControles()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtTelefono.Clear();
        }

        //private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
       // {

        //}
    }
}