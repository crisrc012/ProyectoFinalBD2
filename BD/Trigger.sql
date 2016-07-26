--TRIGGER SQL
CREATE TRIGGER [dbo].[Udp_Cliente] 
ON [dbo].[persona]
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

AFTER UPDATE ON persona FOR EACH ROW

BEGIN
	
	DECLARE ced integer;
	
	DECLARE id integer;
    
   	
	SELECT cedula
    
	INTO ced
    
	FROM persona
    
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
