--DROP DATABASE proyectofinal;
create database proyectofinal;

use ProyectoFinal;

-- alter authorization on database::ProyectoFinal to sa

create table persona(
	cedula integer,
	nombre varchar(20),
	apellido1 varchar(50),
	apellido2 varchar(50),
	activo bit,
	constraint PK_Pcedula PRIMARY KEY(cedula)

);
create table rol (
	id_rol int identity(1,1),
	descripcion varchar(50),
	constraint PK_rol PRIMARY KEY(id_rol)
);

create table usuarios(
	id_usuarios integer identity(1,1),
	cedula integer,
	id_rol int,
	username varchar(10),
	contraseña varchar(15),
	constraint PK_id_usuarios PRIMARY KEY(id_usuarios),
	constraint FK_Ucedula FOREIGN KEY (cedula) 
	REFERENCES persona(cedula),
	constraint FK_Urol FOREIGN KEY (id_rol) 
	REFERENCES rol(id_rol)
);

create table direccion(
	id_direccion integer identity(1,1),
	cedula integer,
	descripcion varchar(200),
	ciudad varchar(30),
	constraint PK_id_direccion PRIMARY KEY(id_direccion),
	constraint FK_Dcedula FOREIGN KEY (cedula) 
	REFERENCES persona(cedula)

);

create table correo(
	id_correo integer identity(1,1),
	cedula integer,
	direccion varchar(50),
	constraint PK_id_correo PRIMARY KEY(id_correo),
	constraint FK_Ccedula FOREIGN KEY (cedula) 
	REFERENCES persona(cedula)

);

create table telefono(
	id_telefono integer identity(1,1),
	numero integer,
	cedula integer,
	descripcion varchar(200),
	constraint PK_id_telefono PRIMARY KEY(id_telefono),
	constraint FK_Tcedula FOREIGN KEY (cedula) 
	REFERENCES persona(cedula)

);

create table cliente(
	id_cliente integer identity(1,1),
	cedula integer,
	constraint PK_id_cliente PRIMARY KEY(id_cliente),
	constraint FK_cedula FOREIGN KEY (cedula) 
	REFERENCES persona(cedula)
);

create table compania(
	id_compania integer identity(1,1),
	nombre varchar(30),
	pais varchar(30),
	constraint PK_id_compania PRIMARY KEY(id_compania)

);

create table proveedor(
	id_proveedor integer identity(1,1),
	cedula integer,
	id_compania integer,
	cargo varchar(30),
	constraint PK_id_proveedor PRIMARY KEY(id_proveedor),
	constraint FK_Pcedula FOREIGN KEY (cedula) 
	REFERENCES persona(cedula),
	constraint FK_idcompania FOREIGN KEY (id_compania) 
	REFERENCES compania(id_compania)

);

create table vendedor(
	id_vendedor integer identity(1,1),
	cedula integer,
	salario integer,
	fecha_Contrato date,
	constraint PK_id_vendedor PRIMARY KEY(id_vendedor),
	constraint FK_Vcedula FOREIGN KEY (cedula) 
	REFERENCES persona(cedula)

);

create table factura(
	id_factura integer identity(1,1),
	id_cliente integer,
	id_vendedor integer,
	fecha date,
	subtotal integer,
	impuesto integer,
	total integer,
	constraint PK_id_factura PRIMARY KEY(id_factura),
	constraint FK_Fcedula FOREIGN KEY (id_cliente) 
	REFERENCES persona(cedula),
	constraint FK_idvendedor FOREIGN KEY (id_vendedor) 
	REFERENCES vendedor(id_vendedor)

);

create table producto(
	id_producto integer identity(1,1),
	id_proveedor integer,
	nombre varchar(20),
	cantidad integer,
	precio integer,
	constraint PK_id_producto PRIMARY KEY(id_producto),
	constraint FK_idproveedor FOREIGN KEY (id_proveedor) 
	REFERENCES proveedor(id_proveedor)

);

create table detalle(
	id_factura integer,
	id_producto integer,
	cantidad integer,
	descuento integer,
	constraint FK_idfactura FOREIGN KEY (id_factura) 
	REFERENCES factura(id_factura),
	constraint FK_idproducto FOREIGN KEY (id_producto) 
	REFERENCES producto(id_producto)
);

create table bitacora (
	id integer identity(1,1),
	id_usuario integer,
	conexion bit,
	constraint PK_id_bitacora PRIMARY KEY(id),
	constraint FK_idusuario FOREIGN KEY (id_usuario) 
	REFERENCES usuarios(id_usuarios)

);

create table bitac_cliente (
	codigo int identity(1,1),	
	id_cliente integer,
	evento varchar(10),
	fecha datetime,
	usuario varchar(20),
	constraint PK_cod_bitacora PRIMARY KEY(codigo)
);

--Creación de usuario SQL
CREATE LOGIN user1
WITH PASSWORD = 'Abc1234'
,DEFAULT_DATABASE = [proyectofinal]
,DEFAULT_LANGUAGE = [us_english]
,CHECK_EXPIRATION = OFF,
CHECK_POLICY = OFF;

USE proyectofinal;
GO
CREATE USER user1
FOR LOGIN user1
WITH DEFAULT_SCHEMA = [user1];

GRANT SELECT ON usuarios 
TO user1;
GRANT SELECT ON persona
TO user1;
