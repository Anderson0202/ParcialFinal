--CREATE DATABASE Final
CREATE TABLE IPS 
(
IdIPS VARCHAR(4) NOT NULL,
NombreIPS VARCHAR(30) NOT NULL

)
--DROP TABLE IPS

Insert Into IPS (IdIPS, NombreIPS) VALUES (2001, 'Laboratorio Yesenia Ovalle')
Insert Into IPS (IdIPS, NombreIPS) VALUES (2001, 'Laboratorio Nacy Florez')
Insert Into IPS (IdIPS, NombreIPS) VALUES (2001, 'Laboratorio Cristiam Gram')

Delete From IPS

CREATE TABLE Laboratorio 
(
IdLaboratorio VARCHAR(4) NOT NULL, 
NombreLaboratorio VARCHAR(30) NOT NULL, 
ValorLaboratorio REAL 

)

--DROP TABLE Laboratorio
Insert Into Laboratorio (IdLaboratorio, NombreLaboratorio, ValorLaboratorio) VALUES (1, 'Cuadro Hematico', 12000)
Insert Into Laboratorio (IdLaboratorio, NombreLaboratorio, ValorLaboratorio) VALUES (2, 'Coprologico', 5000)
Insert Into Laboratorio (IdLaboratorio, NombreLaboratorio, ValorLaboratorio) VALUES (3, 'Glicemia', 25000)
Insert Into Laboratorio (IdLaboratorio, NombreLaboratorio, ValorLaboratorio) VALUES (4, 'Trigliceridos', 8000)

Select * from Laboratorio

CREATE TABLE Servicios 
(
IdIPS VARCHAR(4) NOT NULL, 
IdentificacionPaciente VARCHAR(4) NOT NULL, 
NombrePaciente VARCHAR(30) NOT NULL,
IdLaboratorio VARCHAR (4) NOT NULL,
ValorLaboratorio REAL NULL
)

--Drop table servicios;