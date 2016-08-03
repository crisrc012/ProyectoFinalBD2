-- funcion Nombre Completo
DELIMITER //

CREATE FUNCTION nombre_completo

(cedula INT)

returns VARCHAR(150)

BEGIN
	
DECLARE nombre VARCHAR(50);
	
DECLARE apellido1 VARCHAR(50);
	
DECLARE apellido2 VARCHAR(50);
	
DECLARE nombre_completo VARCHAR(120);
	
SELECT LTRIM(RTRIM(PADRON_COMPLETO.Nombre)) INTO nombre
    
FROM PADRON_COMPLETO
	
WHERE PADRON_COMPLETO.Cedula = cedula;
	
SELECT LTRIM(RTRIM(PADRON_COMPLETO.Apellido1)) INTO apellido1
    
FROM PADRON_COMPLETO
	
WHERE PADRON_COMPLETO.Cedula = cedula;
	
SELECT apellido2 = LTRIM(RTRIM(PADRON_COMPLETO.Apellido2)) INTO apellido2
	
FROM PADRON_COMPLETO
	
WHERE PADRON_COMPLETO.Cedula = cedula;
	
SET nombre_completo = CONCAT(nombre, ' ', apellido1, ' ', apellido2);
	
RETURN nombre_completo;

END//

DELIMITER ;

-- sp leer usuarios
DELIMITER //

CREATE PROCEDURE sp_usuarios 
(IN id_usuarios INT	
,IN cedula INT	
,IN id_rol INT
,IN username VARCHAR(10))
BEGIN
SELECT usuarios.id_usuarios AS Usuario			
,usuarios.cedula AS Cédula			
,nombre_completo(usuarios.cedula) AS NombreCompleto			
,usuarios.username AS Usuario			
,rol.descripcion AS Rol			
,CASE persona.activo				
WHEN 0 THEN 'No'				
WHEN 1 THEN 'Sí'				
ELSE NULL			
END AS Activo
,telefono.numero AS Telefono	
FROM usuarios	
INNER JOIN persona	
ON usuarios.cedula = persona.cedula	
INNER JOIN rol	
ON usuarios.id_rol = rol.id_rol
INNER JOIN telefono
ON telefono.cedula = usuarios.cedula
WHERE usuarios.id_usuarios = IFNULL(id_usuarios,usuarios.id_usuarios)	
and usuarios.cedula  = IFNULL(cedula,usuarios.cedula)	
and usuarios.id_rol = IFNULL(id_rol,usuarios.id_rol)	
and usuarios.username LIKE CONCAT('"' + IFNULL(username,usuarios.username) + '"');
END//

DELIMITER ;

--sp leer proveedores
DELIMITER //

CREATE PROCEDURE sp_proveedor	
(IN id_proveedor INT	
,IN cedula INT	
,IN id_compania INT	
,IN cargo VARCHAR(30))
BEGIN	
SELECT proveedor.id_proveedor AS "# Proveedor"		
,proveedor.cedula AS "Cédula"		
,nombre_completo(persona.cedula) AS "Nombre Completo"		
,compania.nombre AS "Compañía"		
,proveedor.cargo AS "Cargo"		
,CASE persona.activo			
WHEN 0 THEN 'No'			
WHEN 1 THEN 'Sí'		
ELSE NULL		
END AS Activo
,telefono.numero AS Telefono	
FROM proveedor	
INNER JOIN persona
ON proveedor.cedula = persona.cedula
INNER JOIN compania
ON proveedor.id_compania = compania.id_compania
INNER JOIN telefono

ON telefono.cedula = proveedor.cedula
WHERE proveedor.id_proveedor = IFNULL(@id_proveedor,proveedor.id_proveedor)
and proveedor.cedula = IFNULL(@cedula,proveedor.cedula)
and proveedor.id_compania = IFNULL(@id_compania,proveedor.id_compania)
and proveedor.cargo LIKE CONCAT('"', IFNULL(@cargo,proveedor.cargo), '"');
END//

DELIMITER ;


-- sp leer cliente
DELIMITER //
CREATE PROCEDURE sp_cliente
(IN id_cliente INT
,IN cedula INT)
BEGIN
SELECT cliente.id_cliente AS "# Cliente"
,cliente.cedula AS "Cédula"
,PADRON_COMPLETO.Nombre AS "Nombre"
,PADRON_COMPLETO.`1.Apellido` AS "Apellido 1"
,PADRON_COMPLETO.`2.Apellido` AS "Apellido 2"
,CASE persona.activo
WHEN 0 THEN 'No'
WHEN 1 THEN 'Sí'
ELSE NULL
END AS Activo
,telefono.numero AS Telefono
FROM cliente
INNER JOIN persona
ON cliente.cedula = persona.cedula
INNER JOIN PADRON_COMPLETO
ON PADRON_COMPLETO.Cedula = persona.cedula
INNER JOIN telefono

ON telefono.cedula = cliente.cedula
WHERE cliente.id_cliente = IFNULL(@id_cliente.,cliente.id_cliente)
and cliente.cedula = IFNULL(@cedula,cliente.cedula);
END//
DELIMITER ;

-- SP CONSUMO FACTURA
DELIMITER //
CREATE PROCEDURE sp_factura
(IN id_factura INT
,IN id_cliente INT
,IN cedula INT)
BEGIN
SELECT factura.id_factura AS Factura 
,nombre_completo(cliente.cedula) AS NombreCliente
,nombre_completo(vendedor.cedula) AS NombreVendedor
,factura.fecha AS Fecha
,factura.subtotal AS Subtotal      
,factura.impuesto AS Impuesto     
,factura.total AS Total	
FROM factura	
INNER JOIN cliente -- Para la cédula	
ON factura.id_cliente = cliente.id_cliente	
INNER JOIN vendedor -- Para el Vendedor	
ON factura.id_vendedor = vendedor.id_vendedor	
WHERE factura.id_factura = IFNULL(id_factura,factura.id_factura)	
AND factura.id_cliente = IFNULL(id_cliente,factura.id_cliente)	
AND cliente.cedula = IFNULL(cedula,cliente.cedula);
END//

DELIMITER ;

<<<<<<< HEAD
--sp insertar usuarios
DELIMITER //

CREATE PROCEDURE sp_insert_usuarios
	 
(IN cedula INT
	
,IN id_rol INT
	
,IN username VARCHAR(10)
	
,IN contraseña VARCHAR(15))

BEGIN
	
DECLARE total TINYINT;
	
DECLARE exist TINYINT;
    
	
SELECT COUNT(*) 
    
INTO total
	
FROM PADRON_COMPLETO
	
WHERE PADRON_COMPLETO.Cedula = cedula;
	
	
SELECT COUNT(*) 
    
INTO exist
	
FROM persona
	
WHERE persona.Cedula = cedula;

	
IF (total = 0) THEN	
		
SELECT 'La cédula no existe dentro del Padrón Electoral, no se puede crear el usuario.' as mensaje;
	
ELSE
		
INSERT INTO usuarios
		
(cedula,id_rol,username,contraseña)
		
VALUES(cedula,id_rol,username,contraseña);
		
IF (exist = 0) THEN
			
INSERT INTO persona
			
(cedula,activo) VALUES (cedula,1);
		
END IF;
	
END IF;


END//

DELIMITER ;
=======
-- SP UPDATE PERSONA
DELIMITER //
create procedure sp_update_persona
(in cedula int
,in nombre varchar(50)
,in apellido1 varchar(50)
,in apellido2 varchar(50))
begin
	update ProyectoFinal.PADRON_COMPLETO
	set ProyectoFinal.PADRON_COMPLETO.Nombre = nombre,
	ProyectoFinal.PADRON_COMPLETO.`1.Apellido` = apellido1,
	ProyectoFinal.PADRON_COMPLETO.`2.Apellido` = apellido2
	where ProyectoFinal.PADRON_COMPLETO.Cedula = cedula;
end//
>>>>>>> origin/master
