CREATE TRIGGER dbo.UdpCliente 
ON dbo.cliente
AFTER UPDATE 
AS
BEGIN
   insert bitac_cliente
	(id_cliente,
	evento,
	fecha,
	usuario ,
	servidor)

	select 
	id_cliente,
	'Update',
	getdate(),
	system_user,
	host_name()
	FROM inserted
END
GO

