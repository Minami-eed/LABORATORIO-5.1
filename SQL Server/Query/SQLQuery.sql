USE Negocios2022
GO

/*
	En el Manejador activamos la base de datos Negocios2022 y creamos los procedures de listado 
	para tb_clientes y tb_paises.*/
CREATE or ALTER proc usp_clientes
AS
SELECT * FROM CLIENTE
GO

CREATE or ALTER proc usp_paises
AS
SELECT * FROM PAIS
GO

/*
	A continuación, definimos los procedures para insertar y actualizar un registro de tb_clientes, 
	tal como se muestra.
*/

CREATE or ALTER proc usp_Agregar_Cliente
@cod varchar(5),
@nombre varchar(60) ,
@direccion varchar(80),
@idpais char(3),
@fono varchar(24)
AS
INSERT CLIENTE Values(@cod, @nombre, @direccion, @idpais, @fono); 
GO

CREATE or ALTER proc usp_Actua1izar_C1iente
@cod varchar(5),
@nombre varchar(60) ,
@direccion varchar(80),
@idpais char(3),
@fono varchar(24)
As
Update CLIENTE Set NombreCia=@nombre, Direccion=@direccion, idpais=@idpais, Telefono=@fono
Where IdCliente=@cod
GO