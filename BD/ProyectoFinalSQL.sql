--DROP DATABASE proyectofinal;
CREATE DATABASE [ProyectoFinal]

USE ProyectoFinal;

-- alter authorization on database::ProyectoFinal to sa

-- Se edita la columna para no permita nulos para que pueda ser llave primaria
ALTER TABLE PADRON_COMPLETO
ALTER COLUMN Cedula INTEGER NOT NULL;

-- Se hace la columna llave primaria
ALTER TABLE PADRON_COMPLETO
ADD CONSTRAINT PK_Cedula PRIMARY KEY(Cedula);

create table persona(
	cedula integer,
	activo bit,
	constraint FK_cedula FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
);

create table rol (
	id_rol integer identity(1,1),
	descripcion varchar(50),
	constraint PK_rol PRIMARY KEY(id_rol)
);

create table usuarios(
	id_usuarios integer identity(1,1),
	cedula integer,
	id_rol integer,
	username varchar(10),
	contraseña varchar(15),
	constraint PK_id_usuarios PRIMARY KEY(id_usuarios),
	constraint FK_Ucedula FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
	constraint FK_Urol FOREIGN KEY (id_rol)
	REFERENCES rol(id_rol)
);

create table direccion(
	id_direccion integer identity(1,1),
	cedula integer,
	descripcion varchar(200),
	ciudad varchar(30),
	constraint PK_id_direccion PRIMARY KEY(id_direccion),
	constraint FK_id_persona FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
);

create table correo(
	id_correo integer identity(1,1),
	cedula integer,
	direccion varchar(50),
	constraint PK_id_correo PRIMARY KEY(id_correo),
	constraint FK_id_cpersona FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
);

create table telefono(
	id_telefono integer identity(1,1),
	numero integer,
	cedula integer,
	descripcion varchar(200),
	constraint PK_id_telefono PRIMARY KEY(id_telefono),
	constraint FK_tid_persona FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
);

create table cliente(
	id_cliente integer identity(1,1),
	cedula integer,
	constraint PK_id_cliente PRIMARY KEY(id_cliente),
	constraint FK_clid_persona FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
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
	constraint FK_pid_persona FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
	constraint FK_idcompania FOREIGN KEY (id_compania)
	REFERENCES compania(id_compania)
);

create table vendedor(
	id_vendedor integer identity(1,1),
	cedula integer,
	salario integer,
	fecha_Contrato date,
	constraint PK_id_vendedor PRIMARY KEY(id_vendedor),
	constraint FK_vid_persona FOREIGN KEY(cedula)
	REFERENCES PADRON_COMPLETO(Cedula),
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
	constraint FK_fid_cliente FOREIGN KEY(id_cliente)
	REFERENCES cliente(id_cliente),
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
	constraint FK_id_proveedor FOREIGN KEY (id_proveedor)
	REFERENCES proveedor(id_proveedor)
);

create table detalle(
	id_factura integer,
	id_producto integer,
	cantidad integer,
	descuento integer,
	constraint FK_id_factura FOREIGN KEY (id_factura)
	REFERENCES factura(id_factura),
	constraint FK_id_producto FOREIGN KEY (id_producto)
	REFERENCES producto(id_producto)
);

create table bitacora (
	id integer identity(1,1),
	id_usuario integer,
	conexion bit,
	constraint PK_id_bitacora PRIMARY KEY(id),
	constraint FK_id_usuario FOREIGN KEY (id_usuario)
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
CREATE USER [user1]
FOR LOGIN [user1]
WITH DEFAULT_SCHEMA = [user1];

GRANT SELECT ON usuarios 
TO user1;
GRANT SELECT ON persona
TO user1;

GRANT EXECUTE ON OBJECT::[proyectofinal].[dbo].[sp_usuarios]
    TO user1;  
GO 
