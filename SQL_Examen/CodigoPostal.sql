create database examen_WCF
create table DomicilioConsulta
(
id int IDENTITY(1,1) primary key,
codigoPostal int,
colonia varchar(50),
municipio varchar(50),
ciudad varchar(50),
estado varchar(50)

)

select * into  examen_WCF.dbo.DomicilioConsulta
from DomicilioConsulta

select * from DomicilioConsulta