using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace SistemaBoletosAereos
{
    public class DatabaseHelper
    {
        private string connectionStringWithoutDB = "Server=localhost;Uid=root;Pwd=;Port=3306;";
        private string connectionStringWithDB = "Server=localhost;Database=sistema_aerolinea;Uid=root;Pwd=;Port=3306;";

        public DatabaseHelper()
        {
            // Verificar y crear la base de datos automáticamente
            if (!VerificarBaseDatosExiste())
            {
                CrearBaseDatosCompleta();
            }
        }


        private bool VerificarBaseDatosExiste()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionStringWithDB))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void CrearBaseDatosCompleta()
        {
            try
            {
                MessageBox.Show("🔧 Creando base de datos automáticamente...", "Configurando Sistema",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Paso 1: Crear la base de datos
                using (var connection = new MySqlConnection(connectionStringWithoutDB))
                {
                    connection.Open();
                    var command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS sistema_aerolinea", connection);
                    command.ExecuteNonQuery();
                }

                // Paso 2: Crear todas las tablas
                using (var connection = new MySqlConnection(connectionStringWithDB))
                {
                    connection.Open();

                    // Crear tabla de usuarios (VACÍA)
                    string crearUsuarios = @"
                        CREATE TABLE IF NOT EXISTS usuarios (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            nombre VARCHAR(100) NOT NULL,
                            email VARCHAR(100) UNIQUE NOT NULL,
                            password VARCHAR(255) NOT NULL,
                            telefono VARCHAR(15),
                            fecha_registro DATETIME DEFAULT CURRENT_TIMESTAMP
                        )";
                    new MySqlCommand(crearUsuarios, connection).ExecuteNonQuery();

                    // Crear tabla de aerolíneas (VACÍA)
                    string crearAerolineas = @"
                        CREATE TABLE IF NOT EXISTS aerolineas (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            nombre VARCHAR(100) NOT NULL,
                            codigo VARCHAR(5) NOT NULL
                        )";
                    new MySqlCommand(crearAerolineas, connection).ExecuteNonQuery();

                    // Crear tabla de rutas (VACÍA)
                    string crearRutas = @"
                        CREATE TABLE IF NOT EXISTS rutas (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            ciudad_origen VARCHAR(100) NOT NULL,
                            ciudad_destino VARCHAR(100) NOT NULL,
                            distancia_km DECIMAL(10,2)
                        )";
                    new MySqlCommand(crearRutas, connection).ExecuteNonQuery();

                    // Crear tabla de vuelos (VACÍA)
                    string crearVuelos = @"
                        CREATE TABLE IF NOT EXISTS vuelos (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            aerolinea_id INT,
                            ruta_id INT,
                            fecha_salida DATETIME NOT NULL,
                            fecha_llegada DATETIME NOT NULL,
                            duracion_minutos INT,
                            tarifa_base DECIMAL(10,2) NOT NULL,
                            asientos_disponibles INT,
                            FOREIGN KEY (aerolinea_id) REFERENCES aerolineas(id),
                            FOREIGN KEY (ruta_id) REFERENCES rutas(id)
                        )";
                    new MySqlCommand(crearVuelos, connection).ExecuteNonQuery();

                    // Crear tabla de reservas (VACÍA)
                    string crearReservas = @"
                        CREATE TABLE IF NOT EXISTS reservas (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            usuario_id INT,
                            vuelo_id INT,
                            fecha_reserva DATETIME DEFAULT CURRENT_TIMESTAMP,
                            nombre_pasajero VARCHAR(100) NOT NULL,
                            fecha_nacimiento DATE,
                            numero_pasaporte VARCHAR(50),
                            asiento VARCHAR(10),
                            equipaje_mano BOOLEAN DEFAULT FALSE,
                            equipaje_bodega BOOLEAN DEFAULT FALSE,
                            total_pago DECIMAL(10,2),
                            estado ENUM('pendiente', 'confirmada', 'cancelada') DEFAULT 'pendiente',
                            FOREIGN KEY (usuario_id) REFERENCES usuarios(id),
                            FOREIGN KEY (vuelo_id) REFERENCES vuelos(id)
                        )";
                    new MySqlCommand(crearReservas, connection).ExecuteNonQuery();

                    MessageBox.Show("✅ ¡BASE DE DATOS CREADA EXITOSAMENTE!\n\n" +
                                  "• Base de datos: sistema_aerolinea\n" +
                                  "• Tablas: usuarios, aerolineas, rutas, vuelos, reservas\n" +
                                  "Puedes agregar tus propios datos manualmente.",
                                  "Configuración Completada",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error creando base de datos: {ex.Message}",
                              "Error de Configuración",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionStringWithDB))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error de conexión: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var connection = new MySqlConnection(connectionStringWithDB))
                using (var command = new MySqlCommand(query, connection))
                using (var adapter = new MySqlDataAdapter(command))
                {
                    connection.Open();
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en consulta: {ex.Message}\n\nConsulta: {query}", "Error");
            }
            return dt;
        }

        public int ExecuteNonQuery(string query)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionStringWithDB))
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en ejecución: {ex.Message}", "Error");
                return -1;
            }
        }
    }
}