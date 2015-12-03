USE [GD2C2015]

GO

---------------------------------------------------------------------------
--		CREACION DEL ESQUEMA
---------------------------------------------------------------------------

IF NOT EXISTS (SELECT * 
			   FROM sys.schemas 
			   WHERE name = N'ASSASSINS') 
	BEGIN
		EXEC sys.sp_executesql N'CREATE SCHEMA [ASSASSINS] AUTHORIZATION [gd]'
		PRINT 'Esquema ASSASSINS creado'
	END

GO

---------------------------------------------------------------------------
--		DROP TABLAS
---------------------------------------------------------------------------

IF OBJECT_ID ('ASSASSINS.Canje') IS NOT NULL DROP TABLE ASSASSINS.Canje
IF OBJECT_ID ('ASSASSINS.Productos') IS NOT NULL DROP TABLE ASSASSINS.Productos
IF OBJECT_ID ('ASSASSINS.Millas') IS NOT NULL DROP TABLE ASSASSINS.Millas
IF OBJECT_ID ('ASSASSINS.Devolucion') IS NOT NULL DROP TABLE ASSASSINS.Devolucion
IF OBJECT_ID ('ASSASSINS.Pasaje') IS NOT NULL DROP TABLE ASSASSINS.Pasaje
IF OBJECT_ID ('ASSASSINS.Ruta_Aeronave') IS NOT NULL DROP TABLE ASSASSINS.Ruta_Aeronave
IF OBJECT_ID ('ASSASSINS.Viaje') IS NOT NULL DROP TABLE ASSASSINS.Viaje
IF OBJECT_ID ('ASSASSINS.Ruta_TipoServicio') IS NOT NULL DROP TABLE ASSASSINS.Ruta_TipoServicio
IF OBJECT_ID ('ASSASSINS.Ruta') IS NOT NULL DROP TABLE ASSASSINS.Ruta
IF OBJECT_ID ('ASSASSINS.Butaca') IS NOT NULL DROP TABLE ASSASSINS.Butaca
IF OBJECT_ID ('ASSASSINS.Aeronave') IS NOT NULL DROP TABLE ASSASSINS.Aeronave
IF OBJECT_ID ('ASSASSINS.Tipo_servicio') IS NOT NULL DROP TABLE ASSASSINS.Tipo_servicio
IF OBJECT_ID ('ASSASSINS.Ciudad') IS NOT NULL DROP TABLE ASSASSINS.Ciudad
IF OBJECT_ID ('ASSASSINS.Cliente') IS NOT NULL DROP TABLE ASSASSINS.Cliente
IF OBJECT_ID ('ASSASSINS.Rol_Funcionalidad') IS NOT NULL DROP TABLE ASSASSINS.Rol_Funcionalidad
IF OBJECT_ID ('ASSASSINS.Login_Historial') IS NOT NULL DROP TABLE ASSASSINS.Login_Historial
IF OBJECT_ID ('ASSASSINS.Usuario') IS NOT NULL DROP TABLE ASSASSINS.Usuario
IF OBJECT_ID ('ASSASSINS.Rol') IS NOT NULL DROP TABLE ASSASSINS.Rol
IF OBJECT_ID ('ASSASSINS.Funcionalidad') IS NOT NULL DROP TABLE ASSASSINS.Funcionalidad
IF OBJECT_ID ('ASSASSINS.Canje') IS NOT NULL DROP TABLE ASSASSINS.Canje

PRINT 'Tablas borradas'

GO

---------------------------------------------------------------------------
--		CREACION DE TABLAS
---------------------------------------------------------------------------

-----------Tabla Ciudad-----------
CREATE TABLE ASSASSINS.Ciudad ( 
	Ciudad_ID		integer IDENTITY(1,1) PRIMARY KEY,
	Ciudad_Nombre	varchar(255)
);

-----------Tabla Tipo_Servicio-----------
CREATE TABLE ASSASSINS.Tipo_Servicio ( 
	TipoServ_ID			integer IDENTITY(1,1) PRIMARY KEY,
	TipoServ_Nombre		varchar(255),
	TipoServ_Adicional	numeric(4,2)
);

-----------Tabla Ruta-----------
CREATE TABLE ASSASSINS.Ruta ( 
	Ruta_ID					integer IDENTITY(1,1) PRIMARY KEY,
	Ruta_Precio_BasePasaje	numeric(8,2),
	Ruta_Precio_BaseKG		numeric(8,2),
	Ruta_Ciudad_Origen		integer FOREIGN KEY REFERENCES ASSASSINS.Ciudad,
	Ruta_Ciudad_Destino		integer FOREIGN KEY REFERENCES ASSASSINS.Ciudad,
	Ruta_Habilitado			bit
);

-----------Tabla Ruta_TipoServicio-----------
CREATE TABLE ASSASSINS.Ruta_TipoServicio ( 
	Ruta_ID			integer FOREIGN KEY REFERENCES ASSASSINS.Ruta,
	TipoServ_ID 	integer FOREIGN KEY REFERENCES ASSASSINS.Tipo_Servicio
);

-----------Tabla Aeronave-----------
CREATE TABLE ASSASSINS.Aeronave ( 
	Aeronave_Numero						integer IDENTITY(1,1) PRIMARY KEY,
	Aeronave_Matricula					varchar(255) unique,
	Aeronave_Modelo						varchar(255),
	Aeronave_KG_Capacidad				numeric(6),
	Aeronave_Fabricante					varchar(255),
	Aeronave_Butacas_Pasillo			integer,
	Aeronave_Butacas_Ventana			integer,
	TipoServ_ID							integer FOREIGN KEY REFERENCES ASSASSINS.Tipo_Servicio,
	Aeronave_Fecha_Fuera_Servicio		datetime,
	Aeronave_Fecha_Reinicio_Servicio	datetime,
	Aeronave_Fecha_Baja_Definitiva		datetime,
	Aeronave_Fecha_Alta					datetime,
	Aeronave_Habilitado					bit
);

-----------Tabla Ruta_Aeronave-----------
CREATE TABLE ASSASSINS.Ruta_Aeronave ( 
	Ruta_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Ruta,
	Aeronave_Numero 	integer FOREIGN KEY REFERENCES ASSASSINS.Aeronave,
	RutaAeronave_Fecha	datetime
);

-----------Tabla Viaje-----------
CREATE TABLE ASSASSINS.Viaje ( 
	Viaje_ID						integer IDENTITY(1,1) PRIMARY KEY,
	Ruta_ID 						integer FOREIGN KEY REFERENCES ASSASSINS.Ruta,
	Aeronave_Numero					integer FOREIGN KEY REFERENCES ASSASSINS.Aeronave,
	Viaje_Fecha_Salida				datetime,
	Viaje_Fecha_Llegada				datetime,
	Viaje_Fecha_Llegada_Estimada	datetime
);

-----------Tabla Butaca-----------
CREATE TABLE ASSASSINS.Butaca ( 
	Butaca_ID			integer IDENTITY(1,1) PRIMARY KEY,
	Butaca_Nro			numeric(4),
	Butaca_Ventana		bit,
	Butaca_Pasillo		bit,
	Aeronave_Numero	integer FOREIGN KEY REFERENCES ASSASSINS.Aeronave,
);

-----------Tabla Cliente-----------
CREATE TABLE ASSASSINS.Cliente ( 
	Cliente_ID					integer IDENTITY(1,1) PRIMARY KEY,
	Cliente_Nombre				varchar(255) NOT NULL,
	Cliente_Apellido			varchar(255) NOT NULL,
	Cliente_DNI					numeric(18) NOT NULL,
	Cliente_Direccion			varchar(255) NOT NULL,
	Cliente_Telefono			numeric(18) NOT NULL,
	Cliente_Mail				varchar(255),
	Cliente_Fecha_Nacimiento	datetime NOT NULL
);

-----------Tabla Rol-----------
CREATE TABLE ASSASSINS.Rol ( 
	Rol_ID			integer IDENTITY(1,1) PRIMARY KEY,
	Rol_Nombre		varchar(255),
	Rol_Habilitado	bit DEFAULT 1
);

-----------Tabla Usuario-----------
CREATE TABLE ASSASSINS.Usuario ( 
	Usuario_ID			integer IDENTITY(1,1) PRIMARY KEY,
	Usuario_Username	varchar(255),
	Usuario_Password	char(64),
	Rol_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Rol,
	Usuario_Intentos	integer,
	Usuario_Habilitado	bit DEFAULT 1
);

-----------Tabla Pasaje-----------
CREATE TABLE ASSASSINS.Pasaje ( 
	Pasaje_ID				integer IDENTITY(1,1) PRIMARY KEY,
	Pasaje_Precio			numeric(8,2),
	Pasaje_Fecha_Compra		datetime,
	Cliente_ID 				integer FOREIGN KEY REFERENCES ASSASSINS.Cliente,
	Usuario_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Usuario,
	Butaca_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Butaca,
	Viaje_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Viaje,
	Cantidad_KG				numeric(6),
	PNR						varchar(8)
);

-----------Tabla Devolucion-----------
CREATE TABLE ASSASSINS.Devolucion ( 
	Devolucion_ID			integer IDENTITY(1,1) PRIMARY KEY,
	Pasaje_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Pasaje,
	PNR						varchar(8),
	Fecha_Devolucion		datetime,
	Motivo 					varchar(255)
);

-----------Tabla Millas-----------
CREATE TABLE ASSASSINS.Millas ( 
	Millas_ID				integer IDENTITY(1,1) PRIMARY KEY,
	Pasaje_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Pasaje,
	Millas					numeric(8),
	Fecha					datetime,
	Cliente_ID 				integer FOREIGN KEY REFERENCES ASSASSINS.Cliente
);

-----------Tabla Productos-----------
CREATE TABLE ASSASSINS.Productos ( 
	Productos_ID			integer IDENTITY(1,1) PRIMARY KEY,
	Stock					numeric(4),
	Descripcion				varchar(120),
	Precio_Millas			numeric(8)
);

-----------Tabla Canje-----------
CREATE TABLE ASSASSINS.Canje ( 
	Canje_ID				integer IDENTITY(1,1) PRIMARY KEY,
	Cliente_ID 				integer FOREIGN KEY REFERENCES ASSASSINS.Cliente,
	Producto_ID 			integer FOREIGN KEY REFERENCES ASSASSINS.Productos,
	Fecha				    datetime,
	Cantidad				numeric(4)
);

-----------Tabla Funcionalidad-----------
CREATE TABLE ASSASSINS.Funcionalidad ( 
	Func_ID		integer IDENTITY(1,1) PRIMARY KEY,
	Func_Nombre	varchar(255)
);

-----------Tabla Rol_Funcionalidad-----------
CREATE TABLE ASSASSINS.Rol_Funcionalidad ( 
	Func_ID	integer FOREIGN KEY REFERENCES ASSASSINS.Funcionalidad,
	Rol_ID 	integer FOREIGN KEY REFERENCES ASSASSINS.Rol
);

-----------Tabla Login_Historial-----------
CREATE TABLE ASSASSINS.Login_Historial ( 
	Login_Historial_ID 			integer IDENTITY(1,1) PRIMARY KEY,
	Usuario_ID					integer FOREIGN KEY REFERENCES ASSASSINS.Usuario,
	Login_Historial_Fecha 		datetime,
	Login_Historial_Intentos 	tinyint DEFAULT 0
);

PRINT 'Tablas creadas'

GO

---------------------------------------------------------------------------
--		CREACION DE  STORED PROCEDURES
---------------------------------------------------------------------------

-----------Crea una funcionalidad-----------
IF OBJECT_ID ('ASSASSINS.InsertFuncionalidad') IS NOT NULL DROP PROCEDURE ASSASSINS.InsertFuncionalidad
GO
CREATE PROC ASSASSINS.InsertFuncionalidad(@Nombre varchar(40)) AS
	BEGIN
		INSERT INTO ASSASSINS.Funcionalidad(Func_Nombre)
			VALUES(@Nombre)
	END;
GO

-----------Crea un rol-----------
IF OBJECT_ID ('ASSASSINS.InsertRol') IS NOT NULL DROP PROCEDURE ASSASSINS.InsertRol
GO
CREATE PROC ASSASSINS.InsertRol(@Nombre varchar(40), @Habilitado bit) AS
	BEGIN
		INSERT INTO ASSASSINS.Rol(Rol_Nombre, Rol_Habilitado)
			VALUES(@Nombre, @Habilitado)
	END;
GO

-----------Asocia rol con funcionalidad-----------
IF OBJECT_ID ('ASSASSINS.InsertRol_Funcionalidad') IS NOT NULL DROP PROCEDURE ASSASSINS.InsertRol_Funcionalidad
GO
CREATE PROCEDURE ASSASSINS.InsertRol_Funcionalidad(@Rol_Nombre varchar(255), @Func_Nombre varchar(255)) AS
	BEGIN
		INSERT INTO ASSASSINS.Rol_Funcionalidad(Func_ID, Rol_ID)
			SELECT f.Func_ID, r.Rol_ID 
			FROM ASSASSINS.Rol r JOIN ASSASSINS.Funcionalidad f ON (r.Rol_Nombre = @Rol_Nombre AND f.Func_Nombre = @Func_Nombre)
	END;
GO

-----------Crea un usuario-----------
IF OBJECT_ID ('ASSASSINS.InsertUsuario') IS NOT NULL DROP PROCEDURE ASSASSINS.InsertUsuario
GO
CREATE PROCEDURE ASSASSINS.InsertUsuario(@Username varchar(255), @Password varchar(255), @Rol_Nombre varchar(255), @Intentos integer, @Habilitado bit) AS
	BEGIN
		INSERT INTO ASSASSINS.Usuario(USuario_Username, Usuario_Password, Rol_ID, Usuario_Intentos, Usuario_Habilitado)
			SELECT @Username, HASHBYTES('SHA2_256', @Password), Rol_ID , @Intentos, @Habilitado
			FROM ASSASSINS.Rol WHERE Rol_Nombre = @Rol_Nombre
	END;
GO

-----------Busca un usuario-----------
IF OBJECT_ID ('ASSASSINS.SelectUsuario') IS NOT NULL DROP PROCEDURE ASSASSINS.SelectUsuario
GO
CREATE PROCEDURE ASSASSINS.SelectUsuario(@Username varchar(255), @Password varchar(255)) AS
	BEGIN
		SELECT *
		FROM ASSASSINS.Usuario WHERE Usuario_Username = @Username AND Usuario_Password = HASHBYTES('SHA2_256', @Password)
	END;
GO

---------------------------------------------------------------------------
--		CREACION DE DATOS
---------------------------------------------------------------------------

EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'ABM de rol'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Registro de usuario'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'ABM de ciudad'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'ABM de ruta aerea'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'ABM de aeronave'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Generacion de Viaje'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Registro de llegada a destino'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Compra de pasaje/encomienda'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Devolucion/cancelacion de pasaje y/o encomienda'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Consulta de millas de pasajero frecuente'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Canje de millas'
EXEC ASSASSINS.InsertFuncionalidad @Nombre = 'Listado estadistico'

EXEC ASSASSINS.InsertRol @Nombre = 'Administrador General', @Habilitado = 1

EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'ABM de rol'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Registro de usuario'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'ABM de ciudad'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'ABM de ruta aerea'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'ABM de aeronave'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Generacion de Viaje'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Registro de llegada a destino'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Compra de pasaje/encomienda'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Devolucion/cancelacion de pasaje y/o encomienda'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Consulta de millas de pasajero frecuente'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Canje de millas'
EXEC ASSASSINS.InsertRol_Funcionalidad @Rol_Nombre = 'Administrador General', @Func_Nombre = 'Listado estadistico'

EXEC ASSASSINS.InsertUsuario @Username = 'admin', @Password = 'w23e', @Rol_Nombre = 'Administrador General', @Intentos = 0, @Habilitado = 1

GO

PRINT 'Datos creados'

GO

---------------------------------------------------------------------------
--		MIGRACION DE DATOS
---------------------------------------------------------------------------

-----------Ciudades-----------
INSERT INTO ASSASSINS.Ciudad(Ciudad_Nombre)
	(SELECT DISTINCT Ruta_Ciudad_Origen
	  FROM gd_esquema.Maestra
	WHERE Ruta_Ciudad_Origen IS NOT NULL
	UNION
	SELECT DISTINCT Ruta_Ciudad_Destino
	  FROM gd_esquema.Maestra
	WHERE Ruta_Ciudad_Destino IS NOT NULL) 


PRINT 'Tabla ASSASSINS.Ciudad migrada'
GO

-----------Tipos de servicio-----------
INSERT INTO ASSASSINS.Tipo_Servicio(TipoServ_Nombre, TipoServ_Adicional)
	(SELECT DISTINCT Tipo_Servicio, (SUM(Pasaje_Precio) - SUM(Ruta_Precio_BasePasaje)) / SUM(Ruta_Precio_BasePasaje)
	  FROM gd_esquema.Maestra
	WHERE Pasaje_Precio > 0 AND Ruta_Precio_BasePasaje > 0 AND Tipo_Servicio IS NOT NULL GROUP BY Tipo_Servicio)


PRINT 'Tabla ASSASSINS.Tipo_Servicio migrada'
GO


-----------Rutas-----------
/*SET IDENTITY_INSERT ASSASSINS.Ruta ON

INSERT INTO ASSASSINS.Ruta(Ruta_ID, Ruta_Precio_BasePasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Habilitado)
	(SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BasePasaje, Ciudad_Origen.Ciudad_ID, Ciudad_Destino.Ciudad_ID, 1
	  FROM gd_esquema.Maestra Maestra
	  LEFT JOIN ASSASSINS.Ciudad Ciudad_Destino ON(Ciudad_Destino.Ciudad_Nombre = Maestra.Ruta_Ciudad_Destino)
	  LEFT JOIN ASSASSINS.Ciudad Ciudad_Origen ON(Ciudad_Origen.Ciudad_Nombre = Maestra.Ruta_Ciudad_Origen)
	WHERE Ruta_Codigo > 0 AND Ruta_Precio_BasePasaje > 0)

UPDATE ASSASSINS.Ruta SET Ruta_Precio_BaseKG = Ruta_Precio_BaseKG
	FROM (SELECT Ruta_Precio_BaseKG FROM gd_esquema.Maestra WHERE Ruta_Precio_BaseKG > 0) i
	WHERE ASSASSINS.Ruta.Ruta_ID = i.Ruta_Codigo

PRINT 'Tabla ASSASSINS.Ruta migrada'
GO

SET IDENTITY_INSERT ASSASSINS.Ruta OFF*/

-----------Clientes-----------
INSERT INTO ASSASSINS.Cliente(Cliente_Nombre, Cliente_Apellido, Cliente_DNI, Cliente_Direccion, Cliente_Telefono, Cliente_Mail, Cliente_Fecha_Nacimiento)
	(SELECT DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
	  FROM gd_esquema.Maestra
	WHERE Cli_Dni IS NOT NULL)

PRINT 'Tabla ASSASSINS.Cliente migrada'
GO

-----------Pasajes-----------
/*SET IDENTITY_INSERT ASSASSINS.Pasaje ON

INSERT INTO ASSASSINS.Pasaje(Pasaje_ID, Pasaje_Precio, Pasaje_Fecha_Compra, Cliente_ID)
	SELECT Pasaje_Codigo, Pasaje_Precio, Pasaje_FechaCompra, Cliente_ID
	  FROM gd_esquema.Maestra m LEFT JOIN ASSASSINS.Cliente c ON(c.Cliente_DNI = m.Cli_Dni)
	WHERE Pasaje_Codigo > 0


SET IDENTITY_INSERT ASSASSINS.Pasaje OFF

PRINT 'Tabla ASSASSINS.Pasaje migrada'
GO*/
