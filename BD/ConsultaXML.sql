--Consulta en XML
CREATE PROCEDURE [dbo].[sp_ConsultaXML]
	@id_factura int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT F.id_factura AS IdFactura
	, F.fecha AS Fecha
	,(SELECT P.Nombre + P.apellido1 + P.apellido2 AS Nombre
	FROM persona P
	INNER JOIN cliente C
	ON P.cedula = C.cedula
	INNER JOIN factura F
	ON F.id_cliente = C.id_cliente
	AND F.id_factura = 1
	FOR XML AUTO, TYPE) AS Cliente
	,(SELECT P.Nombre + P.apellido1 + P.apellido2 AS Nombre
	FROM persona P
	INNER JOIN vendedor V
	ON P.cedula = V.cedula
	INNER JOIN factura F
	ON F.id_vendedor = V.id_vendedor
	AND F.id_factura = 1
	FOR XML AUTO, TYPE) AS Vendedor
	,(SELECT P.Nombre + P.apellido1 + P.apellido2 AS Nombre
	FROM persona P
	INNER JOIN proveedor PV
	ON P.cedula = PV.cedula
	INNER JOIN producto Pr
	ON Pr.id_proveedor = PV.id_proveedor
	INNER JOIN detalle D
	ON D.id_producto = Pr.id_producto
	AND D.id_factura = 1
	FOR XML AUTO, TYPE) AS Proveedor
	,(SELECT Pr.nombre AS Producto
	, D.descuento AS Descuento
	, D.cantidad AS Cantidad 
	FROM detalle D
	INNER JOIN producto Pr
	ON D.id_producto = Pr.id_producto
	AND D.id_factura = @id_factura
	FOR XML AUTO, TYPE) AS Detalle 
	, F.subtotal AS Subtotal
	, F.impuesto AS Impuesto
	, F.total AS Total
	FROM factura F
	WHERE F.id_factura = @id_factura
	FOR XML AUTO, ELEMENTS

END
GO
EXEC sp_ConsultaXML 1
