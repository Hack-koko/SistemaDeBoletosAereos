-- script_base_datos.sql
CREATE DATABASE IF NOT EXISTS sistema_aerolinea;

USE sistema_aerolinea;

-- Tabla de usuarios
CREATE TABLE usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    telefono VARCHAR(15),
    fecha_registro DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Tabla de aerolíneas
CREATE TABLE aerolineas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    codigo VARCHAR(5) NOT NULL
);

-- Tabla de rutas
CREATE TABLE rutas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    ciudad_origen VARCHAR(100) NOT NULL,
    ciudad_destino VARCHAR(100) NOT NULL,
    distancia_km DECIMAL(10,2)
);

-- Tabla de vuelos
CREATE TABLE vuelos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    aerolinea_id INT,
    ruta_id INT,
    fecha_salida DATETIME NOT NULL,
    fecha_llegada DATETIME NOT NULL,
    tarifa_base DECIMAL(10,2) NOT NULL,
    asientos_disponibles INT,
    FOREIGN KEY (aerolinea_id) REFERENCES aerolineas(id),
    FOREIGN KEY (ruta_id) REFERENCES rutas(id)
);

-- Tabla de reservas
CREATE TABLE reservas (
    id INT AUTO_INCREMENT PRIMARY KEY,
    vuelo_id INT,
    nombre_pasajero VARCHAR(100) NOT NULL,
    equipaje_mano BOOLEAN DEFAULT FALSE,
    equipaje_bodega BOOLEAN DEFAULT FALSE,
    total_pago DECIMAL(10,2),
    estado ENUM('pendiente','confirmada','cancelada') DEFAULT 'confirmada',
    fecha_reserva DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (vuelo_id) REFERENCES vuelos(id)
);

-- Datos de ejemplo (opcional)
INSERT INTO aerolineas (nombre, codigo) VALUES 
('American Airlines', 'AA'),
('Avianca', 'AV'),
('Delta Air Lines', 'DL');

INSERT INTO rutas (ciudad_origen, ciudad_destino) VALUES 
('Ciudad de México', 'Madrid'),
('New York', 'Los Angeles'),
('Bogotá', 'Lima');
('Ciudad de México', 'Bogota'),

INSERT INTO vuelos (aerolinea_id, ruta_id, fecha_salida, fecha_llegada, tarifa_base, asientos_disponibles) VALUES 
(1, 1, '2024-12-20 08:00:00', '2024-12-20 20:00:00', 500.00, 150),
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120);
(2, 2, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(4, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(5, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 480.00, 120)
(2, 1, '2024-12-20 14:00:00', '2024-12-21 02:00:00', 40.00, 120)