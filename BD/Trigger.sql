--TRIGGER SQL
--Si se modifica el nombre
CREATE TRIGGER [dbo].[Udp_Cliente] 
ON [dbo].[PADRON_COMPLETO]
AFTER UPDATE 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ced int = 0;
	DECLARE @id int = 0;
   	SELECT @ced = cedula
	FROM inserted;
	
	SELECT @id = id_cliente 
	FROM [dbo].[cliente]
	WHERE cedula = @ced;
	
	IF(@id != 0)
	BEGIN
		INSERT INTO [dbo].[bitac_cliente]
		(id_cliente, evento, fecha, usuario)
		VALUES (@ced, 'UPDATE', GETDATE(), SYSTEM_USER);
	END
END
GO
--si se modifica el telefono
CREATE TRIGGER [dbo].[Udp_tel_Cliente] 
ON [dbo].[telefono]
AFTER UPDATE 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ced int = 0;
	DECLARE @id int = 0;
   	SELECT @ced = cedula
	FROM inserted;
	
	SELECT @id = id_cliente 
	FROM [dbo].[cliente]
	WHERE cedula = @ced;
	
	IF(@id != 0)
	BEGIN
		INSERT INTO [dbo].[bitac_cliente]
		(id_cliente, evento, fecha, usuario)
		VALUES (@ced, 'UPDATE', GETDATE(), SYSTEM_USER);
	END
END
GO

--Si se modifica el correo
CREATE TRIGGER [dbo].[Udp_correo_Cliente] 
ON [dbo].[correo]
AFTER UPDATE 
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ced int = 0;
	DECLARE @id int = 0;
   	SELECT @ced = cedula
	FROM inserted;
	
	SELECT @id = id_cliente 
	FROM [dbo].[cliente]
	WHERE cedula = @ced;
	
	IF(@id != 0)
	BEGIN
		INSERT INTO [dbo].[bitac_cliente]
		(id_cliente, evento, fecha, usuario)
		VALUES (@ced, 'UPDATE', GETDATE(), SYSTEM_USER);
	END
END
GO


--TRIGGER MYSQL
use ProyectoFinal;

DROP TRIGGER Udp_Cliente;
DELIMITER //
CREATE TRIGGER Udp_Cliente

AFTER UPDATE ON padron_completo FOR EACH ROW

BEGIN
	
DECLARE ced integer;
	
DECLARE id integer;
   	
	
SELECT cedula
	
INTO ced    
	
FROM padron_completo 
	
WHERE cedula = NEW.cedula;
	
	
SELECT id_cliente
	
INTO id
	FROM cliente
	
WHERE cedula = ced;
	
	
IF id != 0 THEN 	
		
INSERT INTO bitac_cliente	
		
(id_cliente, evento, fecha, usuario)
		
VALUES (ced, 'UPDATE', NOW(), CURRENT_USER());
	
END IF;


END//

DELIMITER ;`proyectofinal`

--Si se modifica telefono
USE proyectofinal;

-- DROP TRIGGER Udp_tel_Cliente;

DELIMITER //

CREATE TRIGGER Udp_tel_Cliente

AFTER UPDATE ON telefono 
FOR EACH ROW

BEGIN
	
DECLARE ced integer;
	
DECLARE id integer;
   	
	
SELECT cedula
	
INTO ced    
	
FROM telefono 
	
WHERE cedula = NEW.cedula;
	
	
SELECT id_cliente
	
INTO id
	FROM cliente
	
WHERE cedula = ced;
	
	
IF id != 0 THEN 	
		
INSERT INTO bitac_cliente	
		
(id_cliente, evento, fecha, usuario)
		
VALUES (ced, 'UPDATE', NOW(), CURRENT_USER());
	
END IF;


END//

DELIMITER ;`proyectofinal`

--Si se modifica correo
USE proyectofinal;

-- DROP TRIGGER Udp_correo_Cliente;

DELIMITER //

CREATE TRIGGER Udp_corre_Cliente

AFTER UPDATE ON correo
FOR EACH ROW

BEGIN
	
DECLARE ced integer;
	
DECLARE id integer;
   	
	
SELECT cedula
	
INTO ced    
	
FROM correo 
	
WHERE cedula = NEW.cedula;
	
	
SELECT id_cliente
	
INTO id
	FROM cliente
	
WHERE cedula = ced;
	
	
IF id != 0 THEN 	
		
INSERT INTO bitac_cliente	
		
(id_cliente, evento, fecha, usuario)
		
VALUES (ced, 'UPDATE', NOW(), CURRENT_USER());
	
END IF;


END//

DELIMITER ;`proyectofinal`
