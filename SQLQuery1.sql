--CREATE DATABASE Final
CREATE TABLE IPS 
(
IdIPS VARCHAR(4) PRIMARY KEY NOT NULL,
NombreIPS VARCHAR(30) NOT NULL

)

CREATE TABLE Laboratorios 
(
IdLaboratorios VARCHAR(4) PRIMARY KEY NOT NULL, 
NombreLaboratorios VARCHAR(30) NOT NULL, 
ValorLaboratorio REAL 

)

CREATE TABLE Servicios 
(
IdIPS VARCHAR(4) NOT NULL, 
IdentificacionPaciente VARCHAR(4) NOT NULL, 
NombrePaciente VARCHAR(30) NOT NULL,
IdLaboratorio VARCHAR (4) NOT NULL,
ValorLaboratorio REAL NULL
)

Drop table servicios;