CREATE DATABASE Veterinaria;
USE Veterinaria;

----------Tabla Usuario----------

CREATE TABLE Usuario(
	id_Usuario int primary key identity(1,1),
	nombre_Completo varchar(150) not null,
	direccion varchar(150) not null,
	ciudad varchar(150) not null,
	telefono varchar(10) not null,
	email varchar(100) not null,
	password varchar(100) not null
);


----------Procedimientos almacenados----------

----------Proc_loguearse----------
CREATE PROCEDURE Proc_loguearse
	@email varchar(100),
	@password varchar(100)
AS
BEGIN
	SELECT email, password FROM Usuario WHERE email = @email AND password = @password
END

----------Proc_listarUsuario----------
CREATE PROCEDURE Proc_listarUsuario
AS
BEGIN
	SELECT * FROM Usuario
END

----------Proc_listarUsuarioPorid_Usuario----------
CREATE PROCEDURE Proc_listarUsuarioPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT * FROM Usuario WHERE id_Usuario = @id_Usuario
END

----------Proc_listarid_UsuarioPorEmail----------
CREATE PROCEDURE Proc_listarid_UsuarioPorEmail
	@email varchar(100)
AS
BEGIN
	SELECT id_Usuario FROM Usuario WHERE email = @email
END

----------Proc_crearUsuario----------
CREATE PROCEDURE Proc_crearUsuario
	@nombre_Completo varchar(150),
	@direccion varchar(150),
	@ciudad varchar(150),
	@telefono varchar(10),
	@email varchar(100),
	@password varchar(100)

AS
BEGIN
	INSERT INTO Usuario (nombre_Completo, direccion, ciudad, telefono, email, password) VALUES (@nombre_Completo, @direccion, @ciudad, @telefono, @email, @password)  
END

----------Proc_actualizarUsuario----------
CREATE PROCEDURE Proc_actualizarUsuario
	@id_Usuario int,
	@nombre_Completo varchar(150),
	@direccion varchar(150),
	@ciudad varchar(150),
	@telefono varchar(10),
	@email varchar(100),
	@password varchar(100)

AS
BEGIN
	UPDATE Usuario SET nombre_Completo = @nombre_Completo, direccion = @direccion, ciudad = @ciudad, telefono = @telefono, email = @email, password = @password WHERE id_Usuario = @id_Usuario  
END

----------Proc_eliminarUsuario----------
CREATE PROCEDURE Proc_eliminarUsuario
	@id_Uusuario int
AS
BEGIN
	DELETE FROM Usuario WHERE id_Usuario = @id_Uusuario
END


----------Fin de los procedimientos almacenados de la tabla Usuario----------


----------Tabla Rol----------

CREATE TABLE Rol(
	id_Rol int primary key identity(1,1),
	nombre varchar(30) not null
);

----------Procedimientos almacenados----------

----------Proc_crearRol----------
CREATE PROCEDURE Proc_crearRol
	@nombre varchar(30)
AS
BEGIN
	INSERT INTO Rol (nombre) VALUES (@nombre)
END


----------Fin de los procedimientos almacenados de la tabla Rol----------


----------Tabla Rol_Usuario----------

CREATE TABLE Rol_Usuario(
	id_Rol int not null,
	id_Usuario int not null,
	CONSTRAINT FK_Rol_Usuario_Rol_id_Rol FOREIGN KEY (id_Rol) REFERENCES Rol (id_Rol) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_Rol_Usuario_Usuario_id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario) ON UPDATE CASCADE ON DELETE CASCADE
);


----------Procedimientos almacenados----------

----------Proc_listarid_RolPorid_Usuario----------
CREATE PROCEDURE Proc_listarid_RolPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT id_Rol FROM Rol_Usuario WHERE id_Usuario = @id_Usuario
END

----------Proc_crearRol_Usuario----------
CREATE PROCEDURE Proc_crearRol_Usuario
	@id_Rol int,
	@id_Usuario int
AS
BEGIN
	INSERT INTO Rol_Usuario (id_Rol, id_Usuario) VALUES (@id_Rol, @id_Usuario)
END


----------Fin de los procedimientos almacenados de la tabla Rol----------


----------Tabla Cita----------

--CREATE TABLE Cita(
--	id_Cita int primary key identity(1,1),
--	nombreCompleto_Usuario varchar(50) not null,
--	nombreCompleto_Animal varchar(50) not null,
--	nombreCompleto_Doctor varchar(50) not null,
--	fecha_Cita varchar(50) not null,
--	fecha_Creacion varchar(50) not null
--);


----------Procedimientos almacenados----------


----------Fin de los procedimientos almacenados de la tabla Cita----------


----------Tabla Rol----------

--CREATE TABLE Cita_Usuario(
--	id_Cita int,
--	id_Usuario int,
--	id_Animal int,
--	CONSTRAINT FK_Cita_Usuario_Cita_id_Cita FOREIGN KEY (id_Cita) REFERENCES Cita (id_Cita) ON UPDATE CASCADE ON DELETE CASCADE,
--	CONSTRAINT FK_Cita_Usuario_Usuario_id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario) ON UPDATE CASCADE ON DELETE CASCADE,
--	CONSTRAINT FK_Cita_Usuario_Animal_id_Animal FOREIGN KEY (id_Animal) REFERENCES Animal (id_Animal) ON UPDATE CASCADE ON DELETE CASCADE,
--);


----------Tabla Mascota----------

CREATE TABLE Mascota(
	id_Mascota int primary key identity(1,1),
	id_Usuario int not null,
	id_Tipo int not null,
	id_Raza int not null,
	nombre_Completo varchar(50) not null,
	sexo varchar(9) not null,
	peso varchar(50) not null,
	foto varbinary(max) not null,
	fecha_Ingreso varchar(50) not null,
	fecha_Modificacion varchar(50),
	CONSTRAINT FK_Mascota_Usuario_id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_Mascota_TipoMascota_id_Tipo FOREIGN KEY (id_Tipo) REFERENCES TipoMascota (id_Tipo) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_Mascota_RazaMascota_id_Raza FOREIGN KEY (id_Raza) REFERENCES RazaMascota (id_Raza) ON UPDATE CASCADE ON DELETE CASCADE
);


----------Procedimientos almacenados----------

----------Proc_listarMascota----------
CREATE PROCEDURE Proc_listarMascota
AS
BEGIN
	SELECT * FROM Mascota
END

----------Proc_listarMascotaPorid_Mascota----------
CREATE PROCEDURE Proc_listarMascotaPorid_Mascota
	@id_Mascota int
AS
BEGIN
	SELECT * FROM Mascota WHERE id_Mascota = @id_Mascota
END

----------Proc_crearMascota----------
CREATE PROCEDURE Proc_crearMascota
	@id_Usuario int,
	@id_Tipo int,
	@id_Raza int,
	@nombre_Completo varchar(50),
	@sexo varchar(9),
	@peso varchar(50),
	@foto varbinary(max),
	@fecha_Ingreso varchar(50),
	@fecha_Modificacion varchar(50)
AS
BEGIN
	INSERT INTO Mascota (id_Usuario, id_Tipo, id_Raza, nombre_Completo, sexo, peso, foto, fecha_Ingreso, fecha_Modificacion) VALUES (@id_Usuario, @id_Tipo, @id_Raza, @nombre_Completo, @sexo, @peso, @foto, @fecha_Ingreso, @fecha_Modificacion)
END

----------Proc_actualizarMascota----------
CREATE PROCEDURE Proc_actualizarMascota
	@id_Mascota int,
	@id_Usuario int,
	@id_Tipo int,
	@id_Raza int,
	@nombre_Completo varchar(50),
	@sexo varchar(9),
	@peso varchar(50),
	@foto varbinary(max),
	@fecha_Ingreso varchar(50),
	@fecha_Modificacion varchar(50)
AS
BEGIN
	UPDATE Mascota SET id_Usuario = @id_Usuario, id_Tipo = @id_Tipo, id_Raza = @id_Raza, nombre_Completo = @nombre_Completo, sexo = @sexo, peso = @peso, foto = @foto, fecha_Ingreso = @fecha_Ingreso, fecha_Modificacion = @fecha_Modificacion WHERE id_Mascota = @id_Mascota
END

----------Proc_eliminarMascota----------
CREATE PROCEDURE Proc_eliminarMascota
	@id_Mascota int
AS
BEGIN
	DELETE FROM Mascota WHERE id_Mascota = @id_Mascota
END

----------Fin de los procedimientos almacenados de la tabla Mascota----------


----------Tabla TipoMascota----------

CREATE TABLE TipoMascota(
	id_Tipo int primary key identity(1,1),
	tipo varchar(50) not null
);


----------Procedimientos almacenados----------

----------Proc_listarTipoMascota----------
CREATE PROCEDURE Proc_listarTipoMascota
AS
BEGIN
	SELECT * FROM TipoMascota
END

----------Proc_listarTipoMascotaPorid_Tipo----------
CREATE PROCEDURE Proc_listarTipoMascotaPorid_Tipo
	@id_Tipo int
AS
BEGIN
	SELECT * FROM TipoMascota WHERE id_Tipo = @id_Tipo
END

----------Proc_crearTipoMascota----------
CREATE PROCEDURE Proc_crearTipoMascota
	@tipo varchar(50)
AS
BEGIN
	INSERT INTO TipoMascota (tipo) VALUES (@tipo)
END

----------Proc_actualizarTipoMascota----------
CREATE PROCEDURE Proc_actualizarTipoMascota
	@id_Tipo int,
	@tipo varchar(50)
AS
BEGIN
	UPDATE TipoMascota SET tipo = @tipo WHERE id_Tipo = @id_Tipo
END

----------Proc_eliminarTipoMascota----------
CREATE PROCEDURE Proc_eliminarTipoMascota
	@id_Tipo int
AS
BEGIN
	DELETE FROM TipoMascota WHERE id_Tipo = @id_Tipo
END


----------Fin de los procedimientos almacenados de la tabla TipoAnimal----------


----------Tabla Raza----------

CREATE TABLE RazaMascota(
	id_Raza int primary key identity(1,1),
	raza varchar(50) not null
);

----------Procedimientos almacenados----------

----------Proc_listarRazaMascota----------
CREATE PROCEDURE Proc_listarRazaMascota
AS
BEGIN
	SELECT * FROM RazaMascota
END

----------Proc_listarRazaMascotaPorid_Raza----------
CREATE PROCEDURE Proc_listarRazaMascotaPorid_Raza
	@id_Raza int
AS
BEGIN
	SELECT * FROM RazaMascota WHERE id_Raza = @id_Raza
END

----------Proc_crearRazaMascota----------
CREATE PROCEDURE Proc_crearRazaMascota
	@raza varchar(50)
AS
BEGIN
	INSERT INTO RazaMascota (raza) VALUES (@raza)
END

----------Proc_actualizarRazaMascota----------
CREATE PROCEDURE Proc_actualizarRazaMascota
	@id_raza int,
	@raza varchar(50)
AS
BEGIN
	UPDATE RazaMascota SET raza = @raza WHERE id_Raza = @id_raza
END

----------Proc_eliminarRazaMascota----------
CREATE PROCEDURE Proc_eliminarRazaMascota
	@id_raza int
AS
BEGIN
	DELETE FROM RazaMascota WHERE id_Raza = @id_raza
END


----------Fin de los procedimientos almacenados de la tabla Raza----------
