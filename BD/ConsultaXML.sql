--Consulta en XML
CREATE PROCEDURE [dbo].[sp_ConsultaXML]
	@id_factura int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT F.id_factura AS IdFactura
	, F.fecha AS Fecha
	,(SELECT [dbo].[nombre_completo](C.cedula) AS NombreCliente
	FROM [ProyectoFinal].[dbo].[cliente] C
	INNER JOIN [ProyectoFinal].[dbo].[factura] F
	ON F.id_cliente = C.id_cliente
	AND F.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS Cliente
	,(SELECT [dbo].[nombre_completo](V.cedula) AS NombreVendedor
	FROM [ProyectoFinal].[dbo].[vendedor]  V
	INNER JOIN [ProyectoFinal].[dbo].[factura] F
	ON F.id_vendedor = V.id_vendedor
	AND F.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS Vendedor
	,(SELECT [dbo].[nombre_completo](PV.cedula) AS NombreProveedor
	,Pr.nombre AS Producto
	, D.descuento AS Descuento
	, D.cantidad AS Cantidad 
	FROM [ProyectoFinal].[dbo].[proveedor] PV
	INNER JOIN [ProyectoFinal].[dbo].[producto] Pr
	ON Pr.id_proveedor = PV.id_proveedor
	INNER JOIN [ProyectoFinal].[dbo].[detalle] D
	ON D.id_producto = Pr.id_producto
	AND D.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS DetalleFactura 
	, F.subtotal AS Subtotal
	, F.impuesto AS Impuesto
	, F.total AS Total
	FROM [ProyectoFinal].[dbo].[factura] F
	WHERE F.id_factura = @id_factura
	FOR XML AUTO, ELEMENTS

END
GO
EXEC sp_ConsultaXML 1
