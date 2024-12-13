DROP DATABASE IF EXISTS pokedex;

CREATE DATABASE pokedex;

USE pokedex;

CREATE TABLE Rol_G7(
	id_rol INT NOT NULL PRIMARY KEY  AUTO_INCREMENT,
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
    FOREIGN KEY (id_retador) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_contendiente) REFERENCES Usuario_G7(id_usuario)
);

CREATE TABLE Mensaje_G7(
	id_mensaje INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    id_envia INT NOT NULL,
    id_receptor INT NOT NULL,
    Estado TEXT NOT NULL,
    FOREIGN KEY (id_envia) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_receptor) REFERENCES Usuario_G7(id_usuario)
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
    fecha DATE NOT NULL,
    Estado VARCHAR(25) NOT NULL,
    FOREIGN KEY (id_entrenador) REFERENCES Usuario_G7(id_usuario),
    FOREIGN KEY (id_pokemon) REFERENCES Pokemon_G7(id_pokemon),
    FOREIGN KEY (id_enfermero) REFERENCES Usuario_G7(id_usuario)
);

INSERT  INTO Rol_G7(rol)
VALUES('Entrenador'),
('Admin'),
('Enfermero');

