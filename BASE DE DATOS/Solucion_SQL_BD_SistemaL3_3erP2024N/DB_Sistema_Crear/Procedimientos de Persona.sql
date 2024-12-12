------ procedimiento para listar personas
CREATE OR ALTER PROC persona_listar
AS
SELECT	idpersona		as ID, 
		tipo_persona	as TipoPersona, 
		nombre			as Nombre, 
		Tipo_documento	as TipoDocumento, 
		num_documento	as NumeroDocumento, 
		direccion		as Direccion, 
		telefono		as Telefono, 
		email			as Email
FROM	persona
ORDER BY idpersona DESC
GO

--Procedimiento Buscar
create proc persona_buscar
@valor varchar(50)
as
SELECT	idpersona		as ID, 
		tipo_persona	as TipoPersona, 
		nombre			as Nombre, 
		Tipo_documento	as TipoDocumento, 
		num_documento	as NumeroDocumento, 
		direccion		as Direccion, 
		telefono		as Telefono, 
		email			as Email
FROM	persona
where	nombre like '%' + @valor + '%' Or num_documento like '%' + @valor + '%'
		Or telefono like '%' + @valor + '%'
Order by nombre asc
go

--Procedimiento Insertar
create or alter proc persona_insertar
@tipo_persona		VARCHAR(100), 
@nombre				VARCHAR(100), 
@Tipo_documento		VARCHAR(20), 
@num_documento		VARCHAR(20), 
@direccion			VARCHAR(70), 
@telefono			VARCHAR(20), 
@email				VARCHAR(50)
as
INSERT INTO persona(tipo_persona, nombre, Tipo_documento, num_documento, direccion, telefono, email) 
VALUES             (@tipo_persona, @nombre, @Tipo_documento, @num_documento, @direccion, @telefono, @email)
go

-- Procedimiento Actualizar
create or alter proc persona_actualizar
@idpersona			INT,
@tipo_persona		VARCHAR(100), 
@nombre				VARCHAR(100), 
@Tipo_documento		VARCHAR(20), 
@num_documento		VARCHAR(20), 
@direccion			VARCHAR(70), 
@telefono			VARCHAR(20), 
@email				VARCHAR(50)
as
UPDATE persona 
	   SET	nombre=@nombre, 
			tipo_persona=@tipo_persona,
			Tipo_documento=@Tipo_documento,
			num_documento=@num_documento,
			direccion=@direccion,
			telefono=@telefono,
			email=@email
where		idpersona=@idpersona
go

--Procedimiento Eliminar
create proc persona_eliminar
@idpersona int
as
delete from persona
where idpersona=@idpersona
go

--Procedimiento Desactivar
create proc persona_desactivar
@idpersona int
as
update persona set estado=0
where idpersona=@idpersona
go

--Procedimiento Activar
create proc person_activar
@idpersona int
as
update persona set estado=1
where idpersona=@idpersona
go

--Procedimiento YA Existe
create or alter proc persona_existe
@valor varchar(100),
@existe bit output
as
if exists (select num_documento from persona where num_documento = ltrim(rtrim(@valor)))
begin
set @existe=1
end
else
begin
set @existe=0
end
go
