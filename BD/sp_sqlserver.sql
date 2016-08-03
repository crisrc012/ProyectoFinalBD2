-- Nombre completo
CREATE FUNCTION nombre_completo
(
	@cedula INT
)
returns VARCHAR(150)
AS
BEGIN
	DECLARE @nombre VARCHAR(50)
	DECLARE @apellido1 VARCHAR(50)
	DECLARE @apellido2 VARCHAR(50)
	DECLARE @nombre_completo VARCHAR(120)
	SELECT @nombre = LTRIM(RTRIM([proyectofinal].[dbo].[PADRON_COMPLETO].[Nombre]))
		,@apellido1 = LTRIM(RTRIM([proyectofinal].[dbo].[PADRON_COMPLETO].[1.Apellido]))
		,@apellido2 = LTRIM(RTRIM([proyectofinal].[dbo].[PADRON_COMPLETO].[2.Apellido]))
	FROM [proyectofinal].[dbo].[PADRON_COMPLETO]
	WHERE [proyectofinal].[dbo].[PADRON_COMPLETO].[Cedula] = @cedula
	SET @nombre_completo = CONCAT(@nombre, ' ', @apellido1, ' ', @apellido2)
	RETURN @nombre_completo
END;

-- Leer información de usuarios
CREATE PROC sp_usuarios
	@id_usuarios INT
	,@cedula INT
	,@id_rol INT
	,@username VARCHAR(10)
AS
BEGIN
	SELECT [proyectofinal].[dbo].[usuarios].[id_usuarios] AS "# Usuario"
			,[proyectofinal].[dbo].[usuarios].[cedula] AS "Cédula"
			,[dbo].[nombre_completo]([proyectofinal].[dbo].[usuarios].[cedula]) AS "Nombre completo"
			,[proyectofinal].[dbo].[usuarios].[username] AS Usuario
			,[proyectofinal].[dbo].[rol].[descripcion] AS Rol
			,CASE [proyectofinal].[dbo].[persona].[activo]
				WHEN 0 THEN 'No'
				WHEN 1 THEN 'Sí'
				ELSE NULL
			END AS Activo
	FROM [proyectofinal].[dbo].[usuarios]
	INNER JOIN [proyectofinal].[dbo].[persona]
	ON [proyectofinal].[dbo].[usuarios].[cedula] = [proyectofinal].[dbo].[persona].[cedula]
	INNER JOIN [proyectofinal].[dbo].[rol]
	ON [proyectofinal].[dbo].[usuarios].[id_rol] = [proyectofinal].[dbo].[rol].[id_rol]
	WHERE [proyectofinal].[dbo].[usuarios].[id_usuarios] = ISNULL(@id_usuarios,[proyectofinal].[dbo].[usuarios].[id_usuarios])
	and [proyectofinal].[dbo].[usuarios].[cedula] = ISNULL(@cedula,[proyectofinal].[dbo].[usuarios].[cedula])
	and [proyectofinal].[dbo].[usuarios].[id_rol] = ISNULL(@id_rol,[proyectofinal].[dbo].[usuarios].[id_rol])
	and [proyectofinal].[dbo].[usuarios].[username] LIKE '%' + ISNULL(@username,[proyectofinal].[dbo].[usuarios].[username]) + '%';
END;

--EXEC sp_usuarios null,null,null,null;

-- Leer información de proveedor
CREATE PROC sp_proveedor
	@id_proveedor INT
	,@cedula INT
	,@id_compania INT
	,@cargo VARCHAR(30)
AS
BEGIN
	SELECT [proyectofinal].[dbo].[proveedor].[id_proveedor] AS "# Proveedor"
		,[proyectofinal].[dbo].[proveedor].[cedula] AS "Cédula"
		,[dbo].[nombre_completo]([proyectofinal].[dbo].[persona].[cedula]) AS "Nombre completo"
		,[proyectofinal].[dbo].[compania].[nombre] AS "Compañía"
		,[proyectofinal].[dbo].[proveedor].[cargo] AS Cargo
		,CASE [proyectofinal].[dbo].[persona].[activo]
			WHEN 0 THEN 'No'
			WHEN 1 THEN 'Sí'
			ELSE NULL
		END AS Activo
	FROM [proyectofinal].[dbo].[proveedor]
	INNER JOIN [proyectofinal].[dbo].[persona]
	ON [proyectofinal].[dbo].[proveedor].[cedula] = [proyectofinal].[dbo].[persona].[cedula]
	INNER JOIN [proyectofinal].[dbo].[compania]
	ON [proyectofinal].[dbo].[proveedor].[id_compania] = [proyectofinal].[dbo].[compania].[id_compania]
	WHERE [proyectofinal].[dbo].[proveedor].[id_proveedor] = ISNULL(@id_proveedor,[proyectofinal].[dbo].[proveedor].[id_proveedor])
	and [proyectofinal].[dbo].[proveedor].[cedula] = ISNULL(@cedula,[proyectofinal].[dbo].[proveedor].[cedula])
	and [proyectofinal].[dbo].[proveedor].[id_compania] = ISNULL(@id_compania,[proyectofinal].[dbo].[proveedor].[id_compania])
	and [proyectofinal].[dbo].[proveedor].[cargo] LIKE '%' + ISNULL(@cargo,[proyectofinal].[dbo].[proveedor].[cargo]) + '%';
END;

--EXEC sp_proveedor null,null,null,null

-- Leer información de cliente
CREATE PROC sp_cliente
	@id_cliente INT
	,@cedula INT
AS
BEGIN
	SELECT [proyectofinal].[dbo].[cliente].[id_cliente] AS "# Cliente"
		,[proyectofinal].[dbo].[cliente].[cedula] AS "Cédula"
		,[proyectofinal].[dbo].[PADRON_COMPLETO].[Nombre] AS "Nombre"
		,[proyectofinal].[dbo].[PADRON_COMPLETO].[1.Apellido] AS "Apellido 1"
		,[proyectofinal].[dbo].[PADRON_COMPLETO].[2.Apellido] AS "Apellido 2"
		,CASE [proyectofinal].[dbo].[persona].[activo]
			WHEN 0 THEN 'No'
			WHEN 1 THEN 'Sí'
			ELSE NULL
		END AS Activo
	FROM [proyectofinal].[dbo].[cliente]
	INNER JOIN [proyectofinal].[dbo].[persona]
	ON [proyectofinal].[dbo].[cliente].[cedula] = [proyectofinal].[dbo].[persona].[cedula]
	INNER JOIN [proyectofinal].[dbo].[PADRON_COMPLETO]
	ON [proyectofinal].[dbo].[PADRON_COMPLETO].[Cedula] = [proyectofinal].[dbo].[persona].[cedula]
	WHERE [proyectofinal].[dbo].[cliente].[id_cliente] = ISNULL(@id_cliente,[proyectofinal].[dbo].[cliente].[id_cliente])
	and [proyectofinal].[dbo].[cliente].[cedula] = ISNULL(@cedula,[proyectofinal].[dbo].[cliente].[cedula]);
END;

--EXEC sp_cliente null,null;

-- Consumo de clientes (Facturas)
CREATE PROC sp_factura
	@id_factura INT
	,@id_cliente INT
	,@cedula INT
AS
BEGIN
	SELECT [proyectofinal].[dbo].[factura].[id_factura] AS "# Factura"
      ,[dbo].[nombre_completo]([proyectofinal].[dbo].[cliente].[cedula]) AS "Nombre del cliente"
      ,[dbo].[nombre_completo]([proyectofinal].[dbo].[vendedor].[cedula]) AS "Nombre del vendedor"
      ,[proyectofinal].[dbo].[factura].[fecha] AS Fecha
      ,[proyectofinal].[dbo].[factura].[subtotal] AS Subtotal
      ,[proyectofinal].[dbo].[factura].[impuesto] AS Impuesto
      ,[proyectofinal].[dbo].[factura].[total] AS Total
	FROM [proyectofinal].[dbo].[factura]
	INNER JOIN [proyectofinal].[dbo].[cliente] --Para la cédula
	ON [proyectofinal].[dbo].[factura].[id_cliente] = [proyectofinal].[dbo].[cliente].[id_cliente]
	INNER JOIN [proyectofinal].[dbo].[vendedor] -- Para el Vendedor
	ON [proyectofinal].[dbo].[factura].[id_vendedor] = [proyectofinal].[dbo].[vendedor].[id_vendedor]
	WHERE [proyectofinal].[dbo].[factura].[id_factura] = ISNULL(@id_factura,[proyectofinal].[dbo].[factura].[id_factura])
	AND [proyectofinal].[dbo].[factura].[id_cliente] = ISNULL(@id_cliente,[proyectofinal].[dbo].[factura].[id_cliente])
	AND [proyectofinal].[dbo].[cliente].[cedula] = ISNULL(@cedula,[proyectofinal].[dbo].[cliente].[cedula]);
END;

EXEC sp_factura null,null,null

--Insertar usuario, validando a Padrón
CREATE PROC sp_insert_usuarios
	 @cedula INT
	,@id_rol INT
	,@username VARCHAR(10)
	,@contraseña VARCHAR(15)
AS
BEGIN
	DECLARE @total TINYINT;
	DECLARE @exist TINYINT;
	SELECT @total = COUNT(*) 
	FROM [proyectofinal].[dbo].[PADRON_COMPLETO]
	WHERE [proyectofinal].[dbo].[PADRON_COMPLETO].[Cedula] = @cedula;
	
	SELECT @exist = COUNT(*) 
	FROM [proyectofinal].[dbo].[persona]
	WHERE [proyectofinal].[dbo].[persona].[Cedula] = @cedula;

	IF(@total = 0)
	BEGIN	
		RAISERROR('La cédula no existe dentro del Padrón Electoral, no se puede crear el usuario.',10,1);
	END
	ELSE
	BEGIN
		INSERT INTO [ProyectoFinal].[dbo].[usuarios]
		(cedula,id_rol,username,contraseña)
		VALUES(@cedula,@id_rol,@username,@contraseña);
		IF (@exist = 0)
		BEGIN
			INSERT INTO [proyectofinal].[dbo].[persona]
			(cedula,activo) VALUES (@cedula,1);
		END
		ELSE
		BEGIN
			UPDATE [proyectofinal].[dbo].[persona]
			SET [proyectofinal].[dbo].[persona].[activo] = 1
			WHERE [proyectofinal].[dbo].[persona].[cedula] = @cedula;
		END
	END
END

--EXEC sp_insert_usuarios 109990999,1,prueba,rootroot1;
--SELECT * FROM usuarios

create proc sp_update_persona
@cedula int
,@nombre varchar(50)
,@apellido1 varchar(50)
,@apellido2 varchar(50)
as
begin
	update [ProyectoFinal].[dbo].[PADRON_COMPLETO]
	set [ProyectoFinal].[dbo].[PADRON_COMPLETO].[Nombre] = @nombre,
	[ProyectoFinal].[dbo].[PADRON_COMPLETO].[1.Apellido] = @apellido1,
	[ProyectoFinal].[dbo].[PADRON_COMPLETO].[2.Apellido] = @apellido2
	where [ProyectoFinal].[dbo].[PADRON_COMPLETO].[Cedula] = @cedula
end;
