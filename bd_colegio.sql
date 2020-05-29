CREATE DATABASE crudColegio
GO
USE crudColegio
GO

CREATE TABLE Alumnos(
	idAlumnos int IDENTITY(1,1) PRIMARY KEY,
	nombre varchar(50) NOT NULL,
	apellidos varchar(50) NOT NULL,
	sexo char(1),
	numero varchar(9) NOT NULL,
	email varchar(40) NOT NULL,
);

CREATE TABLE Asignatura(
	idAsignatura int IDENTITY(1,1) PRIMARY KEY,
	nombreA varchar(50) NOT NULL,
	numAula int NOT NULL,
);

CREATE TABLE Nota(
	idNota int IDENTITY(1,1) PRIMARY KEY,
	id_Asig int NOT NULL,
	calificacion float NOT NULL,
	fecha_examen DATE NOT NULL,
	id_Alum int NOT NULL,
);

ALTER TABLE Nota  WITH CHECK ADD  CONSTRAINT FK_Nota_Alumno FOREIGN KEY(id_Alum)
REFERENCES Alumnos (idAlumnos)
GO

ALTER TABLE Nota  WITH CHECK ADD  CONSTRAINT FK_Nota_Asignatura FOREIGN KEY(id_Asig)
REFERENCES Asignatura (idAsignatura)
GO


--PROCEDIMIENTO ALMACENADO DE REGISTRAR ALUMNOS

CREATE PROCEDURE pa_registrar_alumnos
	@nombre varchar(50),
	@apellidos varchar(50),
	@sexo char(1),
	@numero varchar(9),
	@email varchar(40)
AS
BEGIN
		INSERT INTO Alumnos(
		nombre,apellidos,sexo,numero,email)
		VALUES( 
		@nombre,@apellidos,@sexo,@numero,@email)
END

GO

--------------------------------------

--PROCEDIMIENTO ALMACENADO DE MODIFICAR ALUMNOS

CREATE PROCEDURE pa_modificar_alumnos
	@idAlum int,
	@nombre varchar(50),
	@apellidos varchar(50),
	@sexo char(1),
	@numero varchar(9),
	@email varchar(40)
AS
BEGIN
	update Alumnos 
	set nombre=@nombre,apellidos=@apellidos,sexo=@sexo,numero=@numero,email=@email
	where idAlumnos=@idAlum
END

GO
--------------------------------------------

--PROCEDIMIENTO ALMACENADO DE ELIMINAR ALUMNOS
CREATE PROCEDURE pa_eliminar_alumnos
	@idAlum int
AS
BEGIN
	delete from Alumnos where idAlumnos=@idAlum
END

GO

----------------------------------------------
--PROCEDIMIENTO ALMACENADO DE LISTAR ALUMNO
CREATE PROCEDURE pa_liAlumno 
AS
BEGIN
	select * from Alumnos
	ORDER BY nombre
END
GO

----------------------------------------------
--PROCEDIMIENTO ALMACENADO DE LISTAR ALUMNO CON PARAMETROS
CREATE PROCEDURE pa_liAlumnoList 
AS
BEGIN
	select idAlumnos,nombre,apellidos from Alumnos
	ORDER BY nombre
END
GO
----------------------------------------------
--PROCEDIMIENTO ALMACENADO DE REGISTRAR ASIGNATURA
CREATE PROCEDURE pa_registrar_asignatura
	@nombre varchar(50),
	@numAula int
AS
BEGIN
		INSERT INTO Asignatura(
		nombreA,numAula)
		VALUES( 
		@nombre,@numAula)
END

GO

------------------------------------------

--PROCEDIMIENTO ALMACENADO DE MODIFICAR ASIGNATURA

CREATE PROCEDURE pa_modificar_asignatura
	@idAsig int,
	@nomAsig varchar(50),
	@numAula int
AS
BEGIN
	update Asignatura 
	set nombreA=@nomAsig,numAula=@numAula
	where idAsignatura=@idAsig
END

GO

-----------------------------------

--PROCEDIMIENTO ALMACENADO DE ELIMINAR ASIGNATURA
CREATE PROCEDURE pa_eliminar_asignatura
	@idAsig int
AS
BEGIN
	delete from Asignatura where idAsignatura=@idAsig
END

GO

-----------------------------------
--PROCEDIMIENTO ALMACENADO DE LISTAR ASIGNATURA
CREATE PROCEDURE pa_liAsignatura 
AS
BEGIN
	select * from Asignatura
	ORDER BY nombreA
END
GO

-----------------------------------
--PROCEDIMIENTO ALMACENADO DE LISTAR ASIGNATURA CON PARAMETROS
CREATE PROCEDURE pa_liAsignaturaList
AS
BEGIN
	select idAsignatura,nombreA from Asignatura 
	ORDER BY nombreA
END
GO


------------------------------------
--PROCEDIMIENTO ALMACENADO DE REGISTRAR NOTA
CREATE PROCEDURE pa_registrar_notas
	@id_Asig int,
	@calificacion float,
	@fecha_examen DATE,
	@id_Alum int
AS
BEGIN
		INSERT INTO Nota(
		id_Asig,calificacion,fecha_examen,id_Alum)
		VALUES( 
		@id_Asig,@calificacion,@fecha_examen,@id_Alum)
END

GO

------------------------------------
--PROCEDIMIENTO ALMACENADO DE LISTAR NOTAS
CREATE PROCEDURE pa_liNotas 
AS
BEGIN
	select N.idNota as 'ID Nota',Al.nombre as 'Nombre', Al.apellidos as 'Apellidos',Asig.nombreA as 'Nombre Asignatura',
	N.calificacion,N.fecha_examen from Nota N
	inner join Alumnos Al
	on N.id_Alum = AL.idAlumnos
	inner join Asignatura Asig
	ON N.id_Asig = Asig.idAsignatura
	ORDER BY Al.nombre
END

Go

-------------------------------------
--PROCEDIMIENTO ALMACENADO DE EDITAR NOTAS
CREATE PROCEDURE pa_modificarNota
	@idNota int,
	@cali float,
	@fechaexam Date
AS
BEGIN
	update Nota
	set calificacion=@cali,fecha_examen=@fechaexam
	where idNota=@idNota
END

GO

-------------------------------------
--PROCEDIMIENTO ALMACENADO DE ELIMINAR NOTA DE ALUMNO
CREATE PROCEDURE pa_eliminar_Nota_Alumno
	@idNot int
AS
BEGIN
	delete from Nota where idNota= @idNot 
END

GO
