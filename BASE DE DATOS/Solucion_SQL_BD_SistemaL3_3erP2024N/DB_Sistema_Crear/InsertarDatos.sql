use L3_Sistema3erP2024N
--Insertar datos en la tabla categoria 
Insert into categoria (nombre, descripcion) values
('Electronica','Articulos electronicos como tv, computadoras, etc.'),
('Ropa','Prendas de vestir para hombres, mujeres y niños.'),
('Hogar','Articulos para el hogar como muebles , electrodomesticos, etc.'),
('Juguetes','Jugetes para niños de todas las edades.'),
('Deportes','Articulos deportivos como pelotas,raquetas,guantes, etc.'),
('Libros','Libros de diferentes generos y autores.'),
('Musica','Instrumentos musicales y accesorios.'),
('Videojuegos','Videojuegos para diferentes edades'),
('Comida','	Alimentos y bebidas '),
('Belleza','Productos de belleza y cuidado personal');

select * from categoria

INSERT INTO persona(tipo_persona, nombre, Tipo_documento, num_documento, direccion, telefono, email) 
VALUES 
    ('Femenino', 'Paola María Medina Perez',		'DNI',					'0511200110025', 'Col. Satelite, Cortés','98523659', 'paom2001@gmail.com'),
    ('Masculino', 'Carlos Alberto López Reyes',		'Pasaporte',			'0512200210034', 'Col. Los Narnajos, 8va Calle, Cortés','98456321', 'carloslopez23@gmail.com'),
    ('Femenino', 'María Fernanda Rodríguez Cruz',	'Partida Nacimiento',	'0513200310041', 'Parque Central, San Pedro Sula', '99321785', 'mariaf.rodriguez@gmail.com'),
    ('Masculino', 'José Manuel Torres Díaz',		'Pasaporte',			'0514200410052', 'Av. Flores, 9 calle', '97123456', 'josetdiaz2000@gmail.com'),
    ('Femenino', 'Laura Vanessa Molina Rojas',		'DNI',					'0515200510063', 'Col. San Juan, Cortés', '98874521', 'lauramolina21@gmail.com'),
    ('Masculino', 'Ricardo Andrés Gómez Salazar',	'Partida Nacimiento',	'0516200610074', 'Res. Río Tinto, La Lima, Cortés', '99912345', 'ricardo.gomez@gmail.com'),
    ('Femenino', 'Ana Sofía Hernández Ramos',		'Pasaporte',			'0517200710085', 'Col. Pineada, La Lima', '98365412', 'anasofia.hramos@gmail.com'),
    ('Masculino', 'Samuel Ernesto Flores Martínez', 'DNI',					'0518200810096', 'Col. Los Rosales, Cortés', '97543128', 'samuel_flores@gmail.com'),
    ('Femenino', 'Beatriz Cristina Castro Núñez',	'Partida Nacimiento',	'0519200910107', 'San Pedro Sula, Cortés', '98765431', 'beatriz.castro@gmail.com'),
    ('Masculino', 'David Alejandro Ramos Soto',		'Pasaporte',			'0520201010118', 'Col. Los Pinos, Cortés','98612347', 'david.ramos2000@gmail.com');

select * from persona