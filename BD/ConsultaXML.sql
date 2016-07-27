--Consulta en XML
CREATE PROCEDURE [dbo].[sp_ConsultaXML]
	@id_factura int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT F.id_factura AS IdFactura
	, F.fecha AS Fecha
	,(SELECT [dbo].[nombre_completo](P.cedula) AS Nombre
	FROM [ProyectoFinal].[dbo].[persona] P
	INNER JOIN [ProyectoFinal].[dbo].[cliente] C
	ON P.cedula = C.cedula
	INNER JOIN [ProyectoFinal].[dbo].[factura] F
	ON F.id_cliente = C.id_cliente
	AND F.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS Cliente
	,(SELECT [dbo].[nombre_completo](P.cedula) AS Nombre
	FROM [ProyectoFinal].[dbo].[persona] P
	INNER JOIN [ProyectoFinal].[dbo].[vendedor]  V
	ON P.cedula = V.cedula
	INNER JOIN [ProyectoFinal].[dbo].[factura] F
	ON F.id_vendedor = V.id_vendedor
	AND F.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS Vendedor
	,(SELECT [dbo].[nombre_completo](P.cedula) AS Nombre
	FROM [ProyectoFinal].[dbo].[persona] P
	INNER JOIN [ProyectoFinal].[dbo].[proveedor] PV
	ON P.cedula = PV.cedula
	INNER JOIN [ProyectoFinal].[dbo].[producto] Pr
	ON Pr.id_proveedor = PV.id_proveedor
	INNER JOIN [ProyectoFinal].[dbo].[detalle] D
	ON D.id_producto = Pr.id_producto
	AND D.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS Proveedor
	,(SELECT Pr.nombre AS Producto
	, D.descuento AS Descuento
	, D.cantidad AS Cantidad 
	FROM [ProyectoFinal].[dbo].[detalle] D
	INNER JOIN [ProyectoFinal].[dbo].[producto] Pr
	ON D.id_producto = Pr.id_producto
	AND D.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS Detalle 
	, F.subtotal AS Subtotal
	, F.impuesto AS Impuesto
	, F.total AS Total
	FROM [ProyectoFinal].[dbo].[factura] F
	WHERE F.id_factura = @id_factura
	FOR XML AUTO, ELEMENTS

END
GO
EXEC sp_ConsultaXML 1
