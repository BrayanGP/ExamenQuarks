--create database examen

create table cliente
(
id int IDENTITY(1,1) PRIMARY KEY,
nombre varchar(60),
apellidoPaterno varchar(60),
apellidoMaterno varchar(60),
fechaNacimiento varchar(60),
idDomicilio int
)
go

create table domicilio 
(
id int IDENTITY(1,1) primary key,
calle varchar(50),
numeroExterior varchar(20),
numeroInterior varchar(20),
codigoPostal varchar(20),
colonia varchar(50),
municipio varchar(50),
ciudad varchar(50),
estado varchar(50)
)
go

create table contacto
(
id int IDENTITY(1,1) PRIMARY KEY,
NumTeleDomicilio varchar(20),
celular varchar(20),
correoElectronico varchar(60),
idCliente int
)
go

ALTER TABLE cliente
ADD FOREIGN KEY (idDomicilio) REFERENCES domicilio(id);
go
ALTER TABLE contacto
ADD FOREIGN KEY (idCliente) REFERENCES cliente(id);
go

select * from cliente

select * from domicilio

select * from contacto
go
