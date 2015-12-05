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

IF OBJECT_ID ('ASSASSINS.Millas') IS NOT NULL DROP TABLE ASSASSINS.Millas
IF OBJECT_ID ('ASSASSINS.Canje') IS NOT NULL DROP TABLE ASSASSINS.Canje
IF OBJECT_ID ('ASSASSINS.Productos') IS NOT NULL DROP TABLE ASSASSINS.Productos
IF OBJECT_ID ('ASSASSINS.Devolucion_Pasaje') IS NOT NULL DROP TABLE ASSASSINS.Devolucion_Pasaje
IF OBJECT_ID ('ASSASSINS.Devolucion_Encomienda') IS NOT NULL DROP TABLE ASSASSINS.Devolucion_Encomienda
IF OBJECT_ID ('ASSASSINS.Pasaje') IS NOT NULL DROP TABLE ASSASSINS.Pasaje
IF OBJECT_ID ('ASSASSINS.Encomienda') IS NOT NULL DROP TABLE ASSASSINS.Encomienda
IF OBJECT_ID ('ASSASSINS.Ruta_Aeronave') IS NOT NULL DROP TABLE ASSASSINS.Ruta_Aeronave
IF OBJECT_ID ('ASSASSINS.Viaje') IS NOT NULL DROP TABLE ASSASSINS.Viaje
IF OBJECT_ID ('ASSASSINS.Ruta_TipoServicio') IS NOT NULL DROP TABLE ASSASSINS.Ruta_TipoServicio
IF OBJECT_ID ('ASSASSINS.Ruta') IS NOT NULL DROP TABLE ASSASSINS.Ruta
IF OBJECT_ID ('ASSASSINS.Butaca') IS NOT NULL DROP TABLE ASSASSINS.Butaca
IF OBJECT_ID ('ASSASSINS.Baja_Servicio') IS NOT NULL DROP TABLE ASSASSINS.Baja_Servicio
IF OBJECT_ID ('ASSASSINS.Aeronave') IS NOT NULL DROP TABLE ASSASSINS.Aeronave
IF OBJECT_ID ('ASSASSINS.Fabricante') IS NOT NULL DROP TABLE ASSASSINS.Fabricante
IF OBJECT_ID ('ASSASSINS.Modelo') IS NOT NULL DROP TABLE ASSASSINS.Modelo
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
	Ruta_Codigo				integer,
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

-----------Tabla Fabricante-----------
CREATE TABLE ASSASSINS.Fabricante ( 
	Fabricante_ID		integer IDENTITY(1,1) PRIMARY KEY,
	Fabricante_Nombre 	varchar(255)
);

-----------Tabla Modelo-----------
CREATE TABLE ASSASSINS.Modelo ( 
	Modelo_ID		integer IDENTITY(1,1) PRIMARY KEY,
	Modelo_Nombre 	varchar(255)
);

-----------Tabla Aeronave-----------
CREATE TABLE ASSASSINS.Aeronave ( 
	Aeronave_Numero						integer IDENTITY(1,1) PRIMARY KEY,
	Aeronave_Matricula					varchar(255) unique,
	Modelo_ID							integer FOREIGN KEY REFERENCES ASSASSINS.Modelo,
	Aeronave_KG_Capacidad				numeric(6),
	Fabricante_ID						integer FOREIGN KEY REFERENCES ASSASSINS.Fabricante,
	Aeronave_Butacas_Pasillo			integer,
	Aeronave_Butacas_Ventana			integer,
	TipoServ_ID							integer FOREIGN KEY REFERENCES ASSASSINS.Tipo_Servicio,
	Aeronave_Fecha_Baja_Definitiva		datetime,
	Aeronave_Fecha_Alta					datetime,
	Aeronave_Habilitado					bit
);

-----------Tabla Butaca-----------
CREATE TABLE ASSASSINS.Butaca ( 
	Butaca_ID			integer IDENTITY(1,1) PRIMARY KEY,
	Butaca_Nro			numeric(4),
	Butaca_Ventana		bit,
	Butaca_Pasillo		bit,
	Butaca_Piso			numeric(1),
	Aeronave_Numero		integer FOREIGN KEY REFERENCES ASSASSINS.Aeronave,
);

-----------Tabla Baja_Servicio-----------
CREATE TABLE ASSASSINS.Baja_Servicio ( 
	Baja_Servicio_ID					integer IDENTITY(1,1) PRIMARY KEY,
	Aeronave_Fecha_Fuera_Servicio		datetime,
	Aeronave_Fecha_Reinicio_Servicio	datetime,
	Aeronave_Numero 					integer FOREIGN KEY REFERENCES ASSASSINS.Aeronave
);

-----------Tabla Ruta_Aeronave-----------
CREATE TABLE ASSASSINS.Ruta_Aeronave ( 
	Ruta_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Ruta,
	Aeronave_Numero 	integer FOREIGN KEY REFERENCES ASSASSINS.Aeronave
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
	PNR						varchar(8)
);

-----------Tabla Encomienda-----------
CREATE TABLE ASSASSINS.Encomienda ( 
	Encomienda_ID				integer IDENTITY(1,1) PRIMARY KEY,
	Encomienda_Precio			numeric(8,2),
	Encomienda_Fecha_Compra		datetime,
	Cliente_ID 					integer FOREIGN KEY REFERENCES ASSASSINS.Cliente,
	Usuario_ID					integer FOREIGN KEY REFERENCES ASSASSINS.Usuario,
	Viaje_ID					integer FOREIGN KEY REFERENCES ASSASSINS.Viaje,
	Cantidad_KG					numeric(6),
	PNR							varchar(8)
);

-----------Tabla Devolucion_Pasaje-----------
CREATE TABLE ASSASSINS.Devolucion_Pasaje ( 
	Devolucion_Pasaje_ID		integer IDENTITY(1,1) PRIMARY KEY,
	Pasaje_ID					integer FOREIGN KEY REFERENCES ASSASSINS.Pasaje,
	PNR							varchar(8),
	Fecha_Devolucion			datetime,
	Motivo 						varchar(255)
);

-----------Tabla Devolucion_Encomienda-----------
CREATE TABLE ASSASSINS.Devolucion_Encomienda ( 
	Devolucion_Encomienda_ID	integer IDENTITY(1,1) PRIMARY KEY,
	Encomienda_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Encomienda,
	PNR							varchar(8),
	Fecha_Devolucion			datetime,
	Motivo 						varchar(255)
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

-----------Tabla Millas-----------
CREATE TABLE ASSASSINS.Millas ( 
	Millas_ID				integer IDENTITY(1,1) PRIMARY KEY,
	Pasaje_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Pasaje,
	Canje_ID				integer FOREIGN KEY REFERENCES ASSASSINS.Canje,
	Millas					numeric(8),
	Fecha					datetime,
	Cliente_ID 				integer FOREIGN KEY REFERENCES ASSASSINS.Cliente
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

--------Inserta una aeronave y las butacas----------
IF OBJECT_ID ('ASSASSINS.InsertAeronave') IS NOT NULL DROP PROCEDURE ASSASSINS.InsertAeronave
GO
CREATE PROCEDURE ASSASSINS.InsertAeronave(@aeroMat varchar(255), @aeroMod varchar(255), @aeroKG numeric(6,0),
@aeroFab varchar(255), @aeroButPas int, @aeroButVen int, @tipoServ varchar(255), @aeroFechaAlta datetime, @aeroHab bit)
    AS BEGIN
        DECLARE @Contador int
        SET @Contador = 0
        INSERT INTO ASSASSINS.Aeronave(Aeronave_Matricula, Modelo_ID, Aeronave_KG_Capacidad,
        Fabricante_ID, Aeronave_Butacas_Pasillo, Aeronave_Butacas_Ventana, TipoServ_ID,
        Aeronave_Fecha_Alta, Aeronave_Habilitado)
        VALUES(@aeroMat, (SELECT Modelo_ID FROM ASSASSINS.Modelo WHERE Modelo_Nombre=@aeroMod),
        @aeroKG, (SELECT Fabricante_ID FROM ASSASSINS.Fabricante WHERE Fabricante_Nombre=@aeroFab),
        @aeroButPas, @aeroButVen, (SELECT TipoServ_ID FROM ASSASSINS.Tipo_Servicio WHERE
        TipoServ_Nombre=@tipoServ), @aeroFechaAlta, @aeroHab);
        WHILE @Contador < (@aeroButPas)
        BEGIN
            INSERT INTO ASSASSINS.Butaca(Butaca_Nro, Butaca_Pasillo, Butaca_Ventana, Aeronave_Numero)
            VALUES (@Contador,1,0,(SELECT Modelo_ID FROM ASSASSINS.Modelo WHERE Modelo_Nombre=@aeroMod))
        END
        SET @Contador = 0
        WHILE @Contador < (@aeroButVen)
        BEGIN
            INSERT INTO ASSASSINS.Butaca(Butaca_Nro, Butaca_Pasillo, Butaca_Ventana, Aeronave_Numero)
            VALUES (@Contador+@aeroButPas,0,1,(SELECT Modelo_ID FROM ASSASSINS.Modelo WHERE Modelo_Nombre=@aeroMod))
        END
    END;
GO

IF OBJECT_ID ('ASSASSINS.UpdateAeronave') IS NOT NULL DROP PROCEDURE ASSASSINS.UpdateAeronave
GO
CREATE PROCEDURE ASSASSINS.UpdateAeronave(@aeroNum int, @aeroMat varchar(255), @aeroMod varchar(255), @aeroKG numeric(6,0),
@aeroFab varchar(255), @tipoServ varchar(255), @aeroHab bit)
    AS BEGIN

        UPDATE ASSASSINS.Aeronave SET Aeronave_Matricula=@aeroMat, Modelo_ID=(SELECT Modelo_ID FROM ASSASSINS.Modelo
        WHERE Modelo_Nombre=@aeroMod), Aeronave_KG_Capacidad=@aeroKG, Fabricante_ID=(SELECT Fabricante_ID FROM ASSASSINS.Fabricante
        WHERE Fabricante_Nombre=@aeroFab), TipoServ_ID=(SELECT TipoServ_ID FROM ASSASSINS.Tipo_Servicio WHERE
        TipoServ_Nombre=@tipoServ), Aeronave_Habilitado=@aeroHab WHERE Aeronave_Numero=@aeroNum

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

INSERT INTO ASSASSINS.Ruta(Ruta_Codigo, Ruta_Precio_BasePasaje, Ruta_Ciudad_Origen, Ruta_Ciudad_Destino, Ruta_Habilitado)
	(SELECT DISTINCT Ruta_Codigo, Ruta_Precio_BasePasaje, Ciudad_Origen.Ciudad_ID, Ciudad_Destino.Ciudad_ID, 1
	  FROM gd_esquema.Maestra Maestra
	  LEFT JOIN ASSASSINS.Ciudad Ciudad_Destino ON(Ciudad_Destino.Ciudad_Nombre = Maestra.Ruta_Ciudad_Destino)
	  LEFT JOIN ASSASSINS.Ciudad Ciudad_Origen ON(Ciudad_Origen.Ciudad_Nombre = Maestra.Ruta_Ciudad_Origen)
	WHERE Ruta_Codigo > 0 AND Ruta_Precio_BasePasaje > 0)
	
UPDATE ASSASSINS.Ruta SET Ruta_Precio_BaseKG = i.Ruta_Precio_BaseKG
	FROM (SELECT Ruta_Codigo, o.Ciudad_ID Origen, d.Ciudad_ID Destino, Ruta_Precio_BaseKG 
			FROM gd_esquema.Maestra m 
			LEFT JOIN ASSASSINS.Ciudad o ON(o.Ciudad_Nombre = m.Ruta_Ciudad_Origen) 
			LEFT JOIN ASSASSINS.Ciudad d ON(d.Ciudad_Nombre = m.Ruta_Ciudad_Destino) 
			WHERE Ruta_Precio_BaseKG > 0 
			GROUP BY Ruta_Codigo, o.Ciudad_ID, d.Ciudad_ID, Ruta_Precio_BaseKG) i
	WHERE ASSASSINS.Ruta.Ruta_Codigo = i.Ruta_Codigo AND ASSASSINS.Ruta.Ruta_Ciudad_Origen = i.Origen AND ASSASSINS.Ruta.Ruta_Ciudad_Destino = i.Destino
	
PRINT 'Tabla ASSASSINS.Ruta migrada'
GO

-----------Rutas con Tipos de Servicio-----------
INSERT INTO ASSASSINS.Ruta_TipoServicio(Ruta_ID, TipoServ_ID)
	(SELECT Ruta_ID, TipoServ_ID 
	FROM gd_esquema.Maestra m 
	LEFT JOIN ASSASSINS.Ciudad o ON(o.Ciudad_Nombre = m.Ruta_Ciudad_Origen) 
	LEFT JOIN ASSASSINS.Ciudad d ON(d.Ciudad_Nombre = m.Ruta_Ciudad_Destino) 
	LEFT JOIN ASSASSINS.Ruta r ON(r.Ruta_Codigo = m.Ruta_Codigo AND o.Ciudad_ID = r.Ruta_Ciudad_Origen AND d.Ciudad_ID = r.Ruta_Ciudad_Destino) 
	LEFT JOIN ASSASSINS.Tipo_Servicio ts ON(ts.TipoServ_Nombre = m.Tipo_Servicio) 
	WHERE Ruta_ID IS NOT NULL AND TipoServ_ID IS NOT NULL 
	GROUP BY Ruta_ID, TipoServ_ID)

PRINT 'Tabla ASSASSINS.Ruta_TipoServicio migrada'
GO

-----------Fabricantes-----------
INSERT INTO ASSASSINS.Fabricante(Fabricante_Nombre)
	(SELECT DISTINCT Aeronave_Fabricante
	  FROM gd_esquema.Maestra
	WHERE Aeronave_Fabricante IS NOT NULL) 


PRINT 'Tabla ASSASSINS.Fabricante migrada'
GO

-----------Modelos-----------
INSERT INTO ASSASSINS.Modelo(Modelo_Nombre)
	(SELECT DISTINCT Aeronave_Modelo
	  FROM gd_esquema.Maestra
	WHERE Aeronave_Modelo IS NOT NULL) 


PRINT 'Tabla ASSASSINS.Modelo migrada'
GO

-----------Aeronaves-----------
INSERT INTO ASSASSINS.Aeronave(Aeronave_Matricula, Modelo_ID, Aeronave_KG_Capacidad, Fabricante_ID, TipoServ_ID, Aeronave_Habilitado)
	(SELECT Aeronave_Matricula, Modelo_ID, (SELECT MAX(Aeronave_KG_Disponibles + Paquete_KG) FROM gd_esquema.Maestra WHERE Aeronave_Matricula = m.Aeronave_Matricula), Fabricante_ID, TipoServ_ID, 1
		FROM gd_esquema.Maestra m
		LEFT JOIN ASSASSINS.Modelo mo ON(m.Aeronave_Modelo = mo.Modelo_Nombre)
		LEFT JOIN ASSASSINS.Fabricante fa ON(m.Aeronave_Fabricante = fa.Fabricante_Nombre)
		LEFT JOIN ASSASSINS.Tipo_Servicio serv ON(m.Tipo_Servicio = serv.TipoServ_Nombre)
		WHERE Aeronave_Matricula IS NOT NULL
		GROUP BY Aeronave_Matricula, Modelo_ID, Fabricante_ID, TipoServ_ID) 


PRINT 'Tabla ASSASSINS.Aeronave migrada'
GO

-----------Butacas-----------

INSERT INTO ASSASSINS.Butaca(Butaca_Nro, Butaca_Ventana, Butaca_Piso, Aeronave_Numero)
	(SELECT Butaca_Nro, 1, Butaca_Piso, Aeronave_Numero 
		FROM gd_esquema.Maestra m
		LEFT JOIN ASSASSINS.Aeronave a ON(a.Aeronave_Matricula = m.Aeronave_Matricula)
		WHERE Butaca_Piso > 0 AND Butaca_Tipo = 'Ventanilla' 
		GROUP BY a.Aeronave_Numero, Butaca_Nro, Butaca_Piso) 

UPDATE ASSASSINS.Aeronave SET Aeronave_Butacas_Ventana = b.Cantidad_Butacas
	FROM (SELECT Aeronave_Numero, COUNT(*) Cantidad_Butacas 
			FROM ASSASSINS.Butaca 
			WHERE Butaca_Ventana = 1 
			GROUP BY Aeronave_Numero) b
	WHERE ASSASSINS.Aeronave.Aeronave_Numero = b.Aeronave_Numero

INSERT INTO ASSASSINS.Butaca(Butaca_Nro, Butaca_Pasillo, Butaca_Piso, Aeronave_Numero)
	(SELECT Butaca_Nro, 1, Butaca_Piso, Aeronave_Numero 
		FROM gd_esquema.Maestra m
		LEFT JOIN ASSASSINS.Aeronave a ON(a.Aeronave_Matricula = m.Aeronave_Matricula)
		WHERE Butaca_Piso > 0 AND Butaca_Tipo = 'Pasillo' 
		GROUP BY a.Aeronave_Numero, Butaca_Nro, Butaca_Piso) 

UPDATE ASSASSINS.Aeronave SET Aeronave_Butacas_Pasillo = b.Cantidad_Butacas
	FROM (SELECT Aeronave_Numero, COUNT(*) Cantidad_Butacas 
			FROM ASSASSINS.Butaca 
			WHERE Butaca_Pasillo = 1 
			GROUP BY Aeronave_Numero) b
	WHERE ASSASSINS.Aeronave.Aeronave_Numero = b.Aeronave_Numero	
PRINT 'Tabla ASSASSINS.Butacas migrada'
GO

-----------Ruta_Aeronave-----------

INSERT INTO ASSASSINS.Ruta_Aeronave(Ruta_ID, Aeronave_Numero)
	(SELECT DISTINCT r.Ruta_ID, a.Aeronave_Numero
	  FROM gd_esquema.Maestra m
	  LEFT JOIN ASSASSINS.Ciudad d ON(d.Ciudad_Nombre = m.Ruta_Ciudad_Destino)
	  LEFT JOIN ASSASSINS.Ciudad o ON(o.Ciudad_Nombre = m.Ruta_Ciudad_Origen)
	  LEFT JOIN ASSASSINS.Ruta r ON(r.Ruta_Ciudad_Destino = d.Ciudad_ID AND r.Ruta_Ciudad_Origen = o.Ciudad_ID AND m.Ruta_Codigo = r.Ruta_Codigo)
	  LEFT JOIN ASSASSINS.Aeronave a ON(a.Aeronave_Matricula = m.Aeronave_Matricula)
	  WHERE r.Ruta_ID IS NOT NULL AND a.Aeronave_Numero IS NOT NULL)
	
PRINT 'Tabla ASSASSINS.Ruta_Aeronave migrada'
GO  

-----------Viajes-----------
INSERT INTO ASSASSINS.Viaje(Ruta_ID, Aeronave_Numero, Viaje_Fecha_Salida, Viaje_Fecha_Llegada, Viaje_Fecha_Llegada_Estimada)
	(SELECT rut.Ruta_ID, aer.Aeronave_Numero, m.FechaSalida, m.FechaLLegada, m.Fecha_LLegada_Estimada
	FROM gd_esquema.Maestra m 
	LEFT JOIN ASSASSINS.Ruta rut ON(rut.Ruta_Codigo = m.Ruta_Codigo) 
	LEFT JOIN ASSASSINS.Aeronave aer ON(aer.Aeronave_Matricula = m.Aeronave_Matricula) 
	GROUP BY rut.Ruta_ID, aer.Aeronave_Numero, m.FechaSalida, m.FechaLLegada, m.Fecha_LLegada_Estimada)

PRINT 'Tabla ASSASSINS.Viajes migrada'
GO
	  
-----------Clientes-----------
INSERT INTO ASSASSINS.Cliente(Cliente_Nombre, Cliente_Apellido, Cliente_DNI, Cliente_Direccion, Cliente_Telefono, Cliente_Mail, Cliente_Fecha_Nacimiento)
	(SELECT DISTINCT Cli_Nombre, Cli_Apellido, Cli_Dni, Cli_Dir, Cli_Telefono, Cli_Mail, Cli_Fecha_Nac
	  FROM gd_esquema.Maestra
	WHERE Cli_Dni IS NOT NULL)

PRINT 'Tabla ASSASSINS.Cliente migrada'
GO
-----------Pasajes-----------
INSERT INTO ASSASSINS.Pasaje(Pasaje_Precio, Pasaje_Fecha_Compra, Cliente_ID, Usuario_ID, Butaca_ID, Viaje_ID, PNR)
	(SELECT m.Pasaje_Precio, m.Pasaje_FechaCompra, cli.Cliente_ID, NULL, bu.Butaca_ID, via.Viaje_ID , NULL
	  FROM gd_esquema.Maestra m 
	  LEFT JOIN ASSASSINS.Cliente cli ON(cli.Cliente_DNI = m.Cli_Dni) 
	  LEFT JOIN ASSASSINS.Aeronave aero ON(aero.Aeronave_Matricula = m.Aeronave_Matricula) 
	  LEFT JOIN ASSASSINS.Butaca bu ON( bu.Butaca_Nro = m.Butaca_Nro and bu.Aeronave_Numero = aero.Aeronave_Numero)
      LEFT JOIN ASSASSINS.Ciudad d ON(d.Ciudad_Nombre = m.Ruta_Ciudad_Destino)
	  LEFT JOIN ASSASSINS.Ciudad o ON(o.Ciudad_Nombre = m.Ruta_Ciudad_Origen)
	  LEFT JOIN ASSASSINS.Ruta r ON(r.Ruta_Ciudad_Destino = d.Ciudad_ID AND r.Ruta_Ciudad_Origen = o.Ciudad_ID AND m.Ruta_Codigo = r.Ruta_Codigo)
	  LEFT JOIN ASSASSINS.Viaje via ON(via.Aeronave_Numero = aero.Aeronave_Numero and r.Ruta_ID = via.Ruta_ID and Viaje_Fecha_Salida = m.FechaSalida) 
	  WHERE Pasaje_Codigo > 0
	  group by  m.Pasaje_Precio, m.Pasaje_FechaCompra, cli.Cliente_ID, bu.Butaca_ID, via.Viaje_ID)

PRINT 'Tabla ASSASSINS.Pasaje migrada'
GO

-----------Encomienda-----------

INSERT INTO ASSASSINS.Encomienda(Encomienda_Precio, Encomienda_Fecha_Compra, Cliente_ID, Viaje_ID, Cantidad_KG)
	(SELECT DISTINCT Paquete_Precio, Paquete_FechaCompra, c.Cliente_ID, Viaje_ID, Paquete_KG
	  FROM gd_esquema.Maestra m
	  LEFT JOIN ASSASSINS.Cliente c ON(m.Cli_Dni = c.Cliente_DNI)
	  LEFT JOIN ASSASSINS.Aeronave a ON(a.Aeronave_Matricula = m.Aeronave_Matricula)
	  LEFT JOIN ASSASSINS.Ciudad d ON(d.Ciudad_Nombre = m.Ruta_Ciudad_Destino)
	  LEFT JOIN ASSASSINS.Ciudad o ON(o.Ciudad_Nombre = m.Ruta_Ciudad_Origen)
	  LEFT JOIN ASSASSINS.Ruta r ON(r.Ruta_Ciudad_Destino = d.Ciudad_ID AND r.Ruta_Ciudad_Origen = o.Ciudad_ID AND m.Ruta_Codigo = r.Ruta_Codigo)
	  LEFT JOIN ASSASSINS.Viaje v ON(v.Aeronave_Numero = a.Aeronave_Numero AND v.Ruta_ID = r.Ruta_ID AND v.Viaje_Fecha_Salida = m.FechaSalida)
	  WHERE Pasaje_Codigo = 0 
	  GROUP BY Paquete_Precio, Paquete_FechaCompra, c.Cliente_ID, Viaje_ID, Paquete_KG)

PRINT 'Tabla ASSASSINS.Encomienda migrada'
GO

-----------Millas-----------
/*INSERT INTO ASSASSINS.Millas(Pasaje_ID, Cliente_ID, Millas, Fecha)
	(SELECT pas.Pasaje_ID, cli.Cliente_ID, (m.Pasaje_Precio+m.Paquete_Precio / 10), m.FechaLLegada
	FROM gd_esquema.Maestra m 
	LEFT JOIN ASSASSINS.Cliente cli ON(cli.Cliente_DNI = m.Cli_Dni AND Cli_Apellido=m.Cli_Apellido) 
	LEFT JOIN ASSASSINS.Pasaje pas ON(pas.Pasaje_Fecha_Compra = m.Pasaje_FechaCompra AND pas.Cliente_ID = cli.Cliente_ID)
	LEFT JOIN ASSASSINS.Encomienda enc ON(enc.Encomienda_Fecha_Compra = m.Pasaje_FechaCompra AND pas.Cliente_ID = cli.Cliente_ID)
	WHERE  m.Pasaje_Precio > 0 OR m.Paquete_Precio > 0
	GROUP BY pas.Pasaje_ID, cli.Cliente_ID, cli.Cliente_DNI, pas.Pasaje_Fecha_Compra, m.FechaLLegada,m.Pasaje_Precio,m.Paquete_Precio)

PRINT 'Tabla ASSASSINS.Millas migrada'
GO*/
