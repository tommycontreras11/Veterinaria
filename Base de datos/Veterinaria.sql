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

------------Proc_listarUsuario----------
--CREATE PROCEDURE Proc_listarUsuario
--AS
--BEGIN
--	SELECT * FROM Usuario
--END

----------Proc_listarUsuario----------
CREATE PROCEDURE Proc_listarUsuario
AS
BEGIN
	SELECT usuario.id_Usuario, usuario.nombre_Completo, usuario.direccion, usuario.ciudad, usuario.telefono, usuario.email, usuario.password FROM Usuario as usuario INNER JOIN Rol_Usuario as rol on rol.id_Usuario = usuario.id_Usuario WHERE id_Rol = 2
END

----------Proc_listarAdmin----------
CREATE PROCEDURE Proc_listarAdmin
AS
BEGIN
	SELECT usuario.id_Usuario, usuario.nombre_Completo, usuario.direccion, usuario.ciudad, usuario.telefono, usuario.email, usuario.password FROM Usuario as usuario INNER JOIN Rol_Usuario as rol on rol.id_Usuario = usuario.id_Usuario WHERE id_Rol = 1
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

----------Proc_listarnombre_CompletoPorid_Usuario----------
CREATE PROCEDURE Proc_listarnombre_CompletoPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT nombre_Completo FROM Usuario WHERE id_Usuario = @id_Usuario
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

----------Proc_listarRol_Usuario----------
CREATE PROCEDURE Proc_listarRol_Usuario
AS
BEGIN
	SELECT * FROM Rol_Usuario
END

----------Proc_listarRol_UsuarioPorid_Usuario----------
CREATE PROCEDURE Proc_listarRol_UsuarioPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT * FROM Rol_Usuario WHERE id_Usuario = @id_Usuario
END

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

----------Proc_actualizarRol_Usuario----------
CREATE PROCEDURE Proc_actualizarRol_Usuario
	@id_Rol int,
	@id_Usuario int
AS
BEGIN
	UPDATE Rol_Usuario SET id_Rol = @id_Rol WHERE id_Usuario = @id_Usuario
END

----------Proc_eliminarRol_Usuario----------
CREATE PROCEDURE Proc_eliminarRol_Usuario
	@id_Usuario int
AS
BEGIN
	DELETE FROM Rol_Usuario WHERE id_Usuario = @id_Usuario
END

----------Fin de los procedimientos almacenados de la tabla Rol----------


----------Tabla Cita----------

CREATE TABLE Cita(
	id_Cita int primary key identity(1,1),
	id_Usuario int not null,
	id_Mascota int not null,
	id_UsuarioVeterinario int not null,
	servicio varchar(50) not null,
	fecha_Cita varchar(50) not null,
	fecha_Creacion varchar(50) not null,
	fecha_Modificacion varchar(50) null,
	comprobar_Cita bit not null,
	CONSTRAINT FK_Cita_Usuario_id_Usuario FOREIGN KEY (id_Usuario) REFERENCES Usuario (id_Usuario) ON UPDATE NO ACTION ON DELETE NO ACTION,
	CONSTRAINT FK_Cita_Mascota_id_Mascota FOREIGN KEY (id_Mascota) REFERENCES Mascota (id_Mascota) ON UPDATE NO ACTION ON DELETE NO ACTION
);


----------Procedimientos almacenados----------

----------Proc_listarCita----------
CREATE PROCEDURE Proc_listarCita
AS
BEGIN
	SELECT * FROM Cita
END

----------Proc_listarCitaPorid_Cita----------
CREATE PROCEDURE Proc_listarCitaPorid_Cita
	@id_Cita int
AS
BEGIN
	SELECT * FROM Cita WHERE id_Cita = @id_Cita
END

----------Proc_listarCitaPorfecha_Cita----------
CREATE PROCEDURE Proc_listarCitaPorfecha_Cita
	@fecha_Cita varchar(50)
AS
BEGIN
	SELECT fecha_Cita FROM Cita WHERE fecha_Cita = @fecha_Cita AND comprobar_Cita = 0
END

----------Proc_listarservicioPorid_Usuario----------
CREATE PROCEDURE Proc_listarservicioPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT servicio FROM Cita WHERE id_Usuario = @id_Usuario
END

----------Proc_listarCitaPorid_Usuario----------
CREATE PROCEDURE Proc_listarCitaPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT * FROM Cita WHERE id_Usuario = @id_Usuario
END

----------Proc_listarTodaCitaPorfecha_Cita----------
CREATE PROCEDURE Proc_listarTodaCitaPorfecha_Cita
	@fecha_Cita varchar(50)
AS
BEGIN
	SELECT * FROM Cita WHERE fecha_Cita = @fecha_Cita AND comprobar_Cita = 0 ORDER BY id_Cita ASC
END

----------Proc_crearCita----------
CREATE PROCEDURE Proc_crearCita
	@id_Usuario int,
	@id_Mascota int,
	@id_UsuarioVeterinario int,
	@servicio varchar(50),
	@fecha_Cita varchar(50),
	@fecha_Creacion varchar(50),
	@fecha_Modificacion varchar(50),
	@comprobar_Cita bit
AS
BEGIN
	INSERT INTO Cita (id_Usuario, id_Mascota, id_UsuarioVeterinario, servicio, fecha_Cita, fecha_Creacion, fecha_Modificacion, comprobar_Cita) VALUES (@id_Usuario, @id_Mascota, @id_UsuarioVeterinario, @servicio, @fecha_Cita, @fecha_Creacion, @fecha_Modificacion, @comprobar_Cita)
END

----------Proc_actualizarCita----------
CREATE PROCEDURE Proc_actualizarCita
	@id_Cita int,
	@id_Usuario int,
	@id_Mascota int,
	@id_UsuarioVeterinario int,
	@servicio varchar(50),
	@fecha_Cita varchar(50),
	@fecha_Creacion varchar(50),
	@fecha_Modificacion varchar(50),
	@comprobar_Cita bit
AS
BEGIN
	UPDATE Cita SET id_Usuario = @id_Usuario, id_Mascota = @id_Mascota, id_UsuarioVeterinario = @id_UsuarioVeterinario, servicio = @servicio, fecha_Cita = @fecha_Cita, fecha_Creacion = @fecha_Creacion, fecha_Modificacion = @fecha_Modificacion, comprobar_Cita = @comprobar_Cita WHERE id_Cita = @id_Cita
END

----------Proc_eliminarCita----------
CREATE PROCEDURE Proc_eliminarCita
	@id_Cita int
AS
BEGIN
	DELETE FROM Cita WHERE id_Cita = @id_Cita
END


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
	fecha_Modificacion varchar(50) null,
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

----------Proc_listarFotoPorid_Mascota----------
CREATE PROCEDURE Proc_listarFotoPorid_Mascota
	@id_Mascota int
AS
BEGIN
	SELECT foto FROM Mascota WHERE id_Mascota = @id_Mascota
END

----------Proc_listarMascotaPorid_Usuario----------
CREATE PROCEDURE Proc_listarMascotaPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT * FROM Mascota WHERE id_Usuario = @id_Usuario
END

----------Proc_listarNombre_MascotaPorid_Usuario----------
CREATE PROCEDURE Proc_listarNombre_MascotaPorid_Usuario
	@id_Usuario int
AS
BEGIN
	SELECT nombre_Completo FROM Mascota WHERE id_Usuario = @id_Usuario
END

----------Proc_listarid_MascotaPornombre_Completo----------
CREATE PROCEDURE Proc_listarid_MascotaPornombre_Completo
	@nombre_Completo varchar(50)
AS
BEGIN
	SELECT id_Mascota FROM Mascota WHERE nombre_Completo = @nombre_Completo
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

----------Proc_listarSoloTipoMascotaPorid_Tipo----------
CREATE PROCEDURE Proc_listarSoloTipoMascotaPorid_Tipo
	@id_Tipo int
AS
BEGIN
	SELECT tipo FROM TipoMascota WHERE id_Tipo = @id_Tipo
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


----------Tabla RazaMascota----------

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

----------Proc_listarSoloRazaMascotaPorid_Raza----------
CREATE PROCEDURE Proc_listarSoloRazaMascotaPorid_Raza
	@id_Raza int
AS
BEGIN
	SELECT raza FROM RazaMascota WHERE id_Raza = @id_Raza
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


----------Fin de los procedimientos almacenados de la tabla RazaMascota----------


----------Tabla Servicio----------

CREATE TABLE Servicio(
	id_Servicio int primary key identity(1,1),
	descripcion varchar(50) not null
);


----------Procedimientos almacenados----------

----------Proc_listarServicio----------
CREATE PROCEDURE Proc_listarServicio
AS
BEGIN
	SELECT * FROM Servicio
END

----------Proc_listarServicioPorid_Servicio----------
CREATE PROCEDURE Proc_listarServicioPorid_Servicio
	@id_Servicio int
AS
BEGIN
	SELECT * FROM Servicio WHERE id_Servicio = @id_Servicio
END

----------Proc_crearServicio----------
CREATE PROCEDURE Proc_crearServicio
	@descripcion varchar(50)
AS
BEGIN
	INSERT INTO Servicio (descripcion) VALUES (@descripcion)
END

----------Proc_actualizarServicio----------
CREATE PROCEDURE Proc_actualizarServicio
	@id_Servicio int,
	@descripcion varchar(50)
AS
BEGIN
	UPDATE Servicio SET descripcion = @descripcion WHERE id_Servicio = @id_Servicio
END

----------Proc_eliminarServicio----------
CREATE PROCEDURE Proc_eliminarServicio
	@id_Servicio int
AS
BEGIN
	DELETE FROM Servicio WHERE id_Servicio = @id_Servicio
END

----------Fin de los procedimientos almacenados de la tabla Servicio----------


----------Tabla Consejo----------

CREATE TABLE Consejo(
	id_Consejo int primary key identity(1,1),
	id_Tipo int not null,
	id_Raza int not null,
	descripcion varchar(max) not null,
	CONSTRAINT FK_Consejo_TipoMascota_id_Tipo FOREIGN KEY (id_Tipo) REFERENCES TipoMascota (id_Tipo) ON UPDATE CASCADE ON DELETE CASCADE,
	CONSTRAINT FK_Consejo_RazaMascota_id_Raza FOREIGN KEY (id_Raza) REFERENCES RazaMascota (id_Raza) ON UPDATE CASCADE ON DELETE CASCADE
);


----------Procedimientos almacenados----------

----------Proc_listarConsejo----------
CREATE PROCEDURE Proc_listarConsejo
AS
BEGIN
	SELECT * FROM Consejo
END

----------Proc_listarConsejoPorid_Consejo----------
CREATE PROCEDURE Proc_listarConsejoPorid_Consejo
	@id_Consejo int
AS
BEGIN
	SELECT * FROM Consejo WHERE id_Consejo = @id_Consejo
END

----------Proc_crearConsejo----------
CREATE PROCEDURE Proc_crearConsejo
	@id_Tipo int,
	@id_Raza int,
	@descripcion varchar(max)
AS
BEGIN
	INSERT INTO Consejo (id_Tipo, id_Raza, descripcion) VALUES (@id_Tipo, @id_Raza, @descripcion)
END

----------Proc_actualizarConsejo----------
CREATE PROCEDURE Proc_actualizarConsejo
	@id_Consejo int,
	@id_Tipo int,
	@id_Raza int,
	@descripcion varchar(max)
AS
BEGIN
	UPDATE Consejo SET id_Tipo = @id_Tipo, id_Raza = @id_Raza, descripcion = @descripcion WHERE id_Consejo = @id_Consejo
END

----------Proc_eliminarConsejo----------
CREATE PROCEDURE Proc_eliminarConsejo
	@id_Consejo int
AS
BEGIN
	DELETE FROM Consejo WHERE id_Consejo = @id_Consejo
END


----------Fin de los procedimientos almacenados de la tabla Consejo----------


----------Tabla Consejo_Mascota----------

--CREATE TABLE Consejo_Mascota(
--	id_Consejo_Mascota int primary key identity(1,1),
--	id_Consejo int not null,
--	id_Tipo int not null,
--	id_Raza int not null,
--	CONSTRAINT FK_Consejo_Mascota_Consejo_id_Consejo FOREIGN KEY (id_Consejo) REFERENCES Consejo (id_Consejo) ON UPDATE CASCADE ON DELETE CASCADE,
--	CONSTRAINT FK_Consejo_Mascota_TipoMascota_id_Tipo FOREIGN KEY (id_Tipo) REFERENCES TipoMascota (id_Tipo) ON UPDATE CASCADE ON DELETE CASCADE,
--	CONSTRAINT FK_Consejo_Mascota_RazaMascota_id_Raza FOREIGN KEY (id_Raza) REFERENCES RazaMascota (id_Raza) ON UPDATE CASCADE ON DELETE CASCADE
--);


------------Procedimientos almacenados----------

------------Proc_listarConsejo_Mascota----------
--CREATE PROCEDURE Proc_listarConsejo_Mascota
--AS
--BEGIN
--	SELECT * FROM Consejo_Mascota
--END

------------Proc_listarConsejo_MascotaPorid_Consejo_Mascota----------
--CREATE PROCEDURE Proc_listarConsejo_MascotaPorid_Consejo_Mascota
--	@id_Consejo_Mascota int
--AS
--BEGIN
--	SELECT * FROM Consejo_Mascota WHERE id_Consejo_Mascota = @id_Consejo_Mascota
--END

------------Proc_crearConsejo_Mascota----------
--CREATE PROCEDURE Proc_crearConsejo_Mascota
--	@id_Consejo int,
--	@id_Tipo int,
--	@id_Raza int
--AS
--BEGIN
--	INSERT INTO Consejo_Mascota (id_Consejo, id_Tipo, id_Raza) VALUES (@id_Consejo, @id_Tipo, @id_Raza)
--END

------------Proc_actualizarConsejo_Mascota----------
--CREATE PROCEDURE Proc_actualizarConsejo_Mascota
--	@id_Consejo_Mascota int,
--	@id_Consejo int,
--	@id_Tipo int,
--	@id_Raza int
--AS
--BEGIN
--	UPDATE Consejo_Mascota SET id_Consejo = @id_Consejo, id_Tipo = @id_Tipo, id_Raza = @id_Raza WHERE id_Consejo_Mascota = @id_Consejo_Mascota
--END

------------Proc_eliminarConsejo_Mascota----------
--CREATE PROCEDURE Proc_eliminarConsejo_Mascota
--	@id_Consejo_Mascota int
--AS
--BEGIN
--	DELETE FROM Consejo_Mascota WHERE id_Consejo_Mascota = @id_Consejo_Mascota
--END
