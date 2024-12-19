DROP DATABASE IF EXISTS pokedex;

CREATE DATABASE pokedex;

USE pokedex;

CREATE TABLE Rol_G7(
	id_rol INT NOT NULL PRIMARY KEY,
    rol VARCHAR(20) NOT NULL
);

CREATE TABLE Usuario_G7(
	id_usuario INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(300) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    estado boolean NOT NULL
);

CREATE TABLE Usuario_Rol_G7(
	id_usuario_rol INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_usuario INT NOT NULL,
    id_rol INT NOT NULL,
    FOREIGN KEY (id_usuario) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_rol) REFERENCES Rol_G7(id_rol)
);

CREATE TABLE Reto_G7(
	id_reto INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_retador INT NOT NULL,
    id_contendiente INT NOT NULL,
    Estado VARCHAR(25) NOT NULL,
    ganador VARCHAR(25),
    lugar VARCHAR(500),
    fecha DATE,
    FOREIGN KEY (id_retador) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_contendiente) REFERENCES Usuario_G7(id_usuario)
);

CREATE TABLE Chat_G7(
	id_chat INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_usuario1 INT NOT NULL,
    id_usuario2 INT NOT NULL,
    FOREIGN KEY (id_usuario1) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_usuario2) REFERENCES Usuario_G7(id_usuario)
);

CREATE TABLE Mensaje_G7(
	id_mensaje INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_chat INT NOT NULL,
    id_envia INT NOT NULL,
    mensaje TEXT NOT NULL,
    FOREIGN KEY (id_envia) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_chat) REFERENCES Chat_G7(id_chat)
);

CREATE TABLE Pokemon_G7(
	id_pokemon INT NOT NULL PRIMARY KEY,
	nombre VARCHAR(50) NOT NULL,
    altura INT NOT NULL,
    peso INT NOT NULL,
    foto  VARCHAR(1000)
);

CREATE TABLE Tipo_G7(
	id_tipo INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Habilidad_G7(
	id_habilidad INT NOT NULL PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL
);

CREATE TABLE Pokemon_Tipo_G7(
	id_pokemon_tipo INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_pokemon INT NOT NULL,
	id_tipo INT NOT NULL, 
    FOREIGN KEY (id_pokemon) REFERENCES Pokemon_G7(id_pokemon),
    FOREIGN KEY (id_tipo) REFERENCES Tipo_G7(id_tipo)
);

CREATE TABLE Pokemon_Habilidad_G7(
	id_pokemon_habilidad INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_pokemon INT NOT NULL,
	id_habilidad INT NOT NULL, 
    FOREIGN KEY (id_pokemon) REFERENCES Pokemon_G7(id_pokemon),
    FOREIGN KEY (id_habilidad) REFERENCES Habilidad_G7(id_habilidad)
);

CREATE TABLE Detalle_Enfermeria_G7(
	id_detalle_enfermeria INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_entrenador INT NOT NULL,
    id_pokemon INT NOT NULL,
    id_enfermero INT,
    fecha DATE NOT NULL DEFAULT( CURDATE()),
    Estado VARCHAR(25) NOT NULL,
    FOREIGN KEY (id_entrenador) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_pokemon) REFERENCES Pokemon_G7(id_pokemon),
    FOREIGN KEY (id_enfermero) REFERENCES Usuario_G7(id_usuario)
);

CREATE TABLE Usuario_Pokemon_G7(
	id_usuario_pokemon INT NOT NULL PRIMARY  KEY AUTO_INCREMENT,
    id_usuario INT NOT NULL,
	id_pokemon INT NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    enfermeria bool,
    FOREIGN KEY (id_usuario) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_pokemon) REFERENCES Pokemon_G7(id_pokemon)
);

INSERT INTO Usuario_G7(username, password, estado, nombre)
VALUES	('aledenro@gmail.com', '1234', true, 'Alejandro Denver'),
('test@test.com', '1234', true, 'test');

INSERT  INTO Rol_G7(id_rol, rol)
VALUES(1, 'Entrenador'),
(3, 'Admin'),
(2, 'Enfermero');

INSERT INTO Usuario_Rol_G7(id_usuario, id_rol)
VALUES (1, 1),
(1, 3),
(2, 1),
(2, 3);

