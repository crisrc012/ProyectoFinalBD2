--Consulta en XML
use proyectofinal;

SELECT F.id_factura
	,F.total
	,(SELECT P.nombre as 'Cliente'
	FROM persona P
	INNER JOIN cliente C
	ON C.cedula = P.cedula
	INNER JOIN factura f
	ON f.id_cliente = c.id_cliente
	FOR XML AUTO, TYPE)
	,(SELECT P.nombre as 'Vendedor'
	FROM persona P
	INNER JOIN vendedor V
	ON V.cedula = P.cedula
	INNER JOIN factura f
	ON f.id_vendedor = v.id_vendedor
	FOR XML AUTO, TYPE)
	,(SELECT Pr.nombre as 'Producto'
	FROM Producto Pr
	INNER JOIN detalle D
	ON Pr.id_producto = D.id_producto
	INNER JOIN factura F
	ON F.id_factura = D.id_factura
	FOR XML AUTO, TYPE)
	,(SELECT D.cantidad as 'Cantidad'
	FROM detalle D
	INNER JOIN factura F
	ON F.id_factura = D.id_factura
	FOR XML AUTO, TYPE)
	,(SELECT  P.nombre as 'Proveedor'
	FROM persona P
	INNER JOIN proveedor Pv
	ON Pv.cedula = P.cedula
	INNER JOIN producto pr
	ON pr.id_proveedor = pv.id_proveedor
	INNER JOIN detalle d
	ON pr.id_producto=d.id_producto
	INNER JOIN factura f
	ON d.id_factura=f.id_factura
	FOR XML AUTO, TYPE)
FROM factura F
WHERE F.id_Factura = 1
FOR XML AUTO, TYPE;