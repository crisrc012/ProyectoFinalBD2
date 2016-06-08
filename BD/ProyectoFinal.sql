create database proyectofinal;

use ProyectoFinal;

-- alter authorization on database::ProyectoFinal to sa

create table usuarios(
	id_usuarios integer,
	nombre varchar(20),
	apellido1 varchar(50),
	apellido2 varchar(50),
	constraint PK_id_usuarios PRIMARY KEY(id_usuarios)
);

create table persona(
	cedula integer,
	nombre varchar(20),
	apellido1 varchar(50),
	apellido2 varchar(50),
	activo bit,
	fecha_nacimiento date,
	constraint PK_id_persona PRIMARY KEY(id_persona)

);

create table direccion(
	id_direccion integer,
	cedula integer,
	descripcion varchar(200),
	ciudad varchar(30),
	constraint PK_id_direccion PRIMARY KEY(id_direccion),
	constraint FK_Dcedula FOREING KEY (cedula) 
	REFERENCES persona(cedula)

);

create table correo(
	id_correo integer,
	cedula integer,
	direccion varchar(50),
	constraint PK_id_correo PRIMARY KEY(id_correo),
	constraint FK_Ccedula FOREING KEY (cedula) 
	REFERENCES persona(cedula)

);

create table telefono(
	id_telefono integer,
	numero integer,
	cedula integer,
	descripcion varchar(200),
	constraint PK_id_telefono PRIMARY KEY(id_telefono),
	constraint FK_Tcedula FOREING KEY (cedula) 
	REFERENCES persona(cedula)

);

create table cliente(
	id_cliente integer,
	cedula integer,
	constraint PK_id_cliente PRIMARY KEY(id_cliente),
	constraint FK_cedula FOREING KEY (cedula) 
	REFERENCES persona(cedula)
);

create table compania(
	id_compania integer,
	nombre varchar(30),
	pais varchar(30),
	constraint PK_id_compania PRIMARY KEY(id_compania)

);

create table proveedor(
	id_proveedor integer,
	cedula integer,
	id_compania integer,
	cargo varchar(30),
	constraint PK_id_proveedor PRIMARY KEY(id_proveedor),
	constraint FK_Pcedula FOREING KEY (cedula) 
	REFERENCES persona(cedula),
	constraint FK_idcompania FOREING KEY (id_compania) 
	REFERENCES compania(id_compania)

);

create table vendedor(
	id_vendedor integer,
	cedula integer,
	salario integer,
	fecha_Contrato date,
	constraint PK_id_vendedor PRIMARY KEY(id_vendedor),
	constraint FK_Vcedula FOREING KEY (cedula) 
	REFERENCES persona(cedula)

);

create table factura(
	id_factura integer,
	id_cliente integer,
	id_vendedor integer,
	fecha date,
	subtotal integer,
	impuesto integer,
	total integer,
	constraint PK_id_factura PRIMARY KEY(id_factura),
	constraint FK_Fcedula FOREING KEY (cedula) 
	REFERENCES persona(cedula),
	constraint FK_idvendedor FOREING KEY (id_vendedor) 
	REFERENCES vendedor(id_vendedor)

);

create table producto(
	id_producto integer,
	id_proveedor integer,
	nombre varchar(20),
	cantidad integer,
	precio integer,
	constraint PK_id_producto PRIMARY KEY(id_producto),
	constraint FK_idproveedor FOREING KEY (id_proveedor) 
	REFERENCES proveedor(id_proveedor)

);

create table detalle(
	id_factura integer,
	id_producto integer,
	nombre varchar(20),
	cantidad integer,
	descuento integer,
	constraint FK_idfactura FOREING KEY (id_factura) 
	REFERENCES factura(idc_factura),
	constraint FK_idproducto FOREING KEY (id_producto) 
	REFERENCES producto(id_producto)
);

create table bitacora (
	id integer,
	id_usuario integer,
	conexion bit,
	constraint PK_id_bitacora PRIMARY KEY(id),
	constraint FK_idusuario FOREING KEY (id_usuario) 
	REFERENCES usuarios(id_usuarios)

);

--Creación de usuario SQL
CREATE LOGIN user1
WITH PASSWORD = 'Abc_1234'
,DEFAULT_DATABASE = [proyectofinal]
,DEFAULT_LANGUAGE = [us_english]
CHECK_EXPIRATION = OFF,
CHECK_POLICY = OFF;

USE proyectofinal;
GO
CREATE USER user1
FOR LOGIN user1
WITH DEFAULT_SCHEMA = [user1];

GRANT SELECT ON usuarios 
TO root;

--MySQL
CREATE USER 'user1'@'localhost'
IDENTIFIED BY 'Abc_1234';
GRANT SELECT ON proyectofinal.usuarios
TO root;
