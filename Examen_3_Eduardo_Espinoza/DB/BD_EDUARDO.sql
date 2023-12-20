CREATE DATABASE BD_Eduardo
GO
USE	BD_Eduardo
GO

CREATE TABLE partido
(
numero INT IDENTITY,
nombre VARCHAR(50),
CONSTRAINT pk_numero_partido PRIMARY KEY(numero)
)

GO

INSERT INTO partido (nombre) VALUES ('PLN')
INSERT INTO partido (nombre) VALUES ('PAC')
INSERT INTO partido (nombre) VALUES ('PUSC')

GO

CREATE TABLE encuesta
(
numero INT IDENTITY, 
nombre VARCHAR(50) NOT NULL,
fecha_nacimiento DATE CONSTRAINT df_fecha_nacimiento DEFAULT GETDATE() NOT NULL, 
correo VARCHAR(50) NOT NULL,
npartido INT NOT NULL,
CONSTRAINT fk_npartido FOREIGN KEY (npartido) REFERENCES partido(numero),
CONSTRAINT pk_numero_encuesta PRIMARY KEY(numero)
)
GO 

CREATE PROCEDURE agregar_encuesta
@nombre VARCHAR(50), 
@fecha_nacimiento VARCHAR(50),
@correo VARCHAR(50),
@npartido INT
 AS 
   BEGIN 
     INSERT INTO  encuesta (nombre, fecha_nacimiento,correo, npartido) VALUES (@nombre,@fecha_nacimiento,@correo,@npartido)
   END
GO

CREATE PROCEDURE consulta_encuesta

AS
BEGIN

SELECT encuesta.numero as [#Encuesta],encuesta.nombre as [Nombre], encuesta.fecha_nacimiento as [Fecha de nacimiento], encuesta.correo as [Correo electronico], partido.nombre as [Partido seleccionado]
FROM partido

INNER JOIN encuesta ON encuesta.npartido=partido.numero

END
