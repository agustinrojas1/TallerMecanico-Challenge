-- Automovil:

-- AddAutomovil
CREATE PROCEDURE AddAutomovil
    @Marca NVARCHAR(100),
    @Modelo NVARCHAR(100),
    @Patente NVARCHAR(10),
    @Tipo INT,
    @CantidadPuertas INT
AS
BEGIN   
        DECLARE @IdVehiculo INT;

        INSERT INTO Vehiculos (Marca, Modelo, Patente)
        VALUES (@Marca, @Modelo, @Patente);

        SET @IdVehiculo = SCOPE_IDENTITY();

        INSERT INTO Automoviles (Id, Tipo, CantidadPuertas)
        VALUES (@IdVehiculo, @Tipo, @CantidadPuertas);

        SELECT @IdVehiculo as Id;
END
GO

-- DeleteAutomovil
CREATE PROCEDURE DeleteAutomovil
    @Id INT
AS
BEGIN
    DELETE FROM Vehiculos
	WHERE Id = @Id
END
GO

-- GetAllAutomoviles
CREATE PROCEDURE GetAllAutomoviles
AS
BEGIN
    SELECT *
    FROM Automoviles
END
GO

-- GetAllAutomovilesDto
CREATE PROCEDURE GetAllAutomovilesDto
AS
BEGIN
    SELECT v.Id, v.Marca, v.Modelo, v.Patente, a.Tipo, a.CantidadPuertas
    FROM Vehiculos v
    INNER JOIN Automoviles a ON v.Id = a.Id
END
GO

-- GetAutomovilById
CREATE PROCEDURE GetAutomovilById
    @Id INT
AS
BEGIN
    SELECT * FROM Automoviles
    WHERE Id = @Id
END
GO

-- GetAutomovilDtoById
CREATE PROCEDURE GetAutomovilDtoById
    @Id INT
AS
BEGIN
    SELECT v.Id, v.Marca, v.Modelo, v.Patente, a.Tipo, a.CantidadPuertas
    FROM Vehiculos v
    INNER JOIN Automoviles a ON v.Id = a.Id
    WHERE a.Id = @id
END
GO


-- UpdateAutomovil
CREATE PROCEDURE UpdateAutomovil
    @Id INT,
    @Marca NVARCHAR(100),
    @Modelo NVARCHAR(100),
    @Patente NVARCHAR(10),
    @Tipo INT,
    @CantidadPuertas INT
AS
BEGIN
        DECLARE @IdVehiculo INT;
        
        UPDATE Vehiculos
        SET Marca = @Marca,
            Modelo = @Modelo,
            Patente = @Patente
        WHERE Id = @Id;

        UPDATE Automoviles
        SET Tipo = @Tipo,
            CantidadPuertas = @CantidadPuertas
        WHERE Id = @Id;
END;
GO

-- GetAutomovilesByIds
CREATE PROCEDURE GetAutomovilesByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT * FROM Automoviles
    WHERE Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
END
GO

-- GetAutomovilesByIds
CREATE PROCEDURE GetAutomovilesDtoByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT v.Id, v.Marca, v.Modelo, v.Patente, a.Tipo, a.CantidadPuertas
    FROM Vehiculos v
    INNER JOIN Automoviles a ON v.Id = a.Id
    WHERE a.Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
END
GO


-- ---------------------------------------------------

-- Moto


-- AddMoto
CREATE PROCEDURE AddMoto
    @Marca NVARCHAR(100),
    @Modelo NVARCHAR(100),
    @Patente NVARCHAR(10),
    @Cilindrada NVARCHAR(10)
AS
BEGIN
        DECLARE @IdVehiculo INT;

        INSERT INTO Vehiculos (Marca, Modelo, Patente)
        VALUES (@Marca, @Modelo, @Patente);

        SET @IdVehiculo = SCOPE_IDENTITY();

        INSERT INTO Motos (Id, Cilindrada)
        VALUES (@IdVehiculo, @Cilindrada);

        SELECT @IdVehiculo as Id;
END;
GO

-- DeleteMoto
CREATE PROCEDURE DeleteMoto
    @Id INT
AS
BEGIN
	DELETE FROM Vehiculos
	WHERE Id = @Id
END
GO

-- GetAllMotos
CREATE PROCEDURE GetAllMotos
AS
BEGIN
    SELECT * FROM Motos
END
GO

-- GetAllMotosDto
CREATE PROCEDURE GetAllMotosDto
AS
BEGIN
    SELECT v.Id, v.Marca, v.Modelo, v.Patente, m.Cilindrada
    FROM Vehiculos v
    INNER JOIN Motos m ON v.Id = m.Id
END
GO

-- GetMotoById
CREATE PROCEDURE GetMotoById
    @Id INT
AS
BEGIN
    SELECT * FROM Motos
    WHERE Id = @Id
END
GO

-- GetMotoDtoById
CREATE PROCEDURE GetMotoDtoById
    @Id INT
AS
BEGIN
    SELECT v.Id, v.Marca, v.Modelo, v.Patente, m.Cilindrada
    FROM Vehiculos v
    INNER JOIN Motos m ON v.Id = m.Id
    WHERE m.Id = @id
END
GO

-- UpdateMoto
CREATE PROCEDURE UpdateMoto
    @Id INT,
    @Marca NVARCHAR(100),
    @Modelo NVARCHAR(100),
    @Patente NVARCHAR(10),
    @Cilindrada NVARCHAR(10)
AS
BEGIN
        UPDATE Vehiculos
        SET Marca = @Marca,
            Modelo = @Modelo,
            Patente = @Patente
        WHERE Id = @Id;

        UPDATE Motos
        SET Cilindrada = Cilindrada
        WHERE Id = @Id;
END;
GO

-- GetMotosByIds
CREATE PROCEDURE GetMotosByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT * FROM Motos
    WHERE Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
END
GO


-- GetMotosDtoByIds
CREATE PROCEDURE GetMotosDtoByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT v.Id, v.Marca, v.Modelo, v.Patente, m.Cilindrada
    FROM Vehiculos v
    INNER JOIN Motos m ON v.Id = m.Id
    WHERE m.Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
END
GO


-- -----------------------------

-- Repuesto:

-- AddRepuesto
CREATE PROCEDURE AddRepuesto
    @Nombre NVARCHAR(100),
    @Precio DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Repuestos (Nombre, Precio)
    VALUES (@Nombre, @Precio)

    DECLARE @IdRepuesto INT;
    SET @IdRepuesto = SCOPE_IDENTITY()

    SELECT @IdRepuesto AS Id
END
GO

-- DeleteRepuesto
CREATE PROCEDURE DeleteRepuesto
    @Id INT
AS
BEGIN
    DELETE FROM Repuestos
    WHERE Id = @Id
END
GO

-- GetAllRepuestos
CREATE PROCEDURE GetAllRepuestos
AS
BEGIN
    SELECT * FROM Repuestos
END
GO

-- GetRepuestoById
CREATE PROCEDURE GetRepuestoById
    @Id INT
AS
BEGIN
    SELECT * FROM Repuestos
    WHERE Id = @Id
END
GO

-- UpdateRepuesto
CREATE PROCEDURE UpdateRepuesto
    @Id INT,
    @Nombre NVARCHAR(100),
    @Precio DECIMAL(18,2)
AS
BEGIN
    UPDATE Repuestos
    SET Nombre = @Nombre,
        Precio = @Precio
    WHERE Id = @Id
END
GO

-- GetRepuestosByIds
CREATE PROCEDURE GetRepuestosByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT * FROM Repuestos
    WHERE Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
END
GO

-- -------------------------------

-- DesperfectoRepuestos

-- AddDesperfectoRepuesto
CREATE PROCEDURE AddDesperfectoRepuesto
    @DesperfectoId INT,
    @RepuestoId INT
AS
BEGIN
    INSERT INTO DesperfectoRepuestos (DesperfectoId, RepuestoId)
    VALUES (@DesperfectoId, @RepuestoId)
END
GO

-- --------------------------

-- Desperfecto

-- AddDesperfecto
CREATE PROCEDURE AddDesperfecto
    @IdPresupuesto INT,
    @Descripcion NVARCHAR(MAX),
    @ManoDeObra DECIMAL(18,2),
    @Tiempo INT
AS
BEGIN
    INSERT INTO Desperfectos (IdPresupuesto, Descripcion, ManoDeObra, Tiempo)
    VALUES (@IdPresupuesto, @Descripcion, @ManoDeObra, @Tiempo)

    DECLARE @IdDesperfecto INT;
    SET @IdDesperfecto = SCOPE_IDENTITY()

    SELECT @IdDesperfecto AS Id
    
END
GO

-- DeleteDesperfecto
CREATE PROCEDURE DeleteDesperfecto
    @Id INT
AS
BEGIN
    DELETE FROM Desperfectos
    WHERE Id = @Id
END
GO

-- GetAllDesperfectos
CREATE PROCEDURE GetAllDesperfectos
AS
BEGIN
    SELECT * FROM Desperfectos
END
GO


-- GetDesperfectoById
CREATE PROCEDURE GetDesperfectoById
    @Id INT
AS
BEGIN
    SELECT * FROM Desperfectos
    WHERE Id = @Id
END
GO


-- UpdateDesperfecto
CREATE PROCEDURE UpdateDesperfecto
	@Id INT,
    @IdPresupuesto INT,
    @Descripcion NVARCHAR(MAX),
    @ManoDeObra DECIMAL(18,2),
    @Tiempo INT
AS
BEGIN
    UPDATE Desperfectos
    SET IdPresupuesto = @IdPresupuesto,
        Descripcion = @Descripcion,
        ManoDeObra = @ManoDeObra,
        Tiempo = @Tiempo
    WHERE Id = @Id
END
GO


-- GetDesperfectosByIds
CREATE PROCEDURE GetDesperfectosByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT * FROM Desperfectos
    WHERE Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
END
GO

-- --------------------------

-- Presupuesto


-- AddPresupuesto
CREATE PROCEDURE AddPresupuesto
    @IdVehiculo INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Email NVARCHAR(100),
    @Total DECIMAL(18,2)
AS
BEGIN
    INSERT INTO Presupuestos (IdVehiculo, Nombre, Apellido, Email, Total)
    VALUES (@IdVehiculo, @Nombre, @Apellido, @Email, @Total)

    DECLARE @IdPresupuesto INT;
    SET @IdPresupuesto = SCOPE_IDENTITY()

    SELECT @IdPresupuesto AS Id
END
GO

-- DeletePresupuesto
CREATE PROCEDURE DeletePresupuesto
    @Id INT
AS
BEGIN
    DELETE FROM Presupuestos
    WHERE Id = @Id
END
GO

-- GetAllPresupuestos
CREATE PROCEDURE GetAllPresupuestos
AS
BEGIN
    SELECT * FROM Presupuestos
END
GO

-- GetPresupuestoById
CREATE PROCEDURE GetPresupuestoById
    @Id INT
AS
BEGIN
    SELECT * FROM Presupuestos
    WHERE Id = @Id
END
GO

-- UpdatePresupuesto
CREATE PROCEDURE UpdatePresupuesto
    @Id INT,
    @IdVehiculo INT,
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @Email NVARCHAR(100),
    @Total DECIMAL(18,2)
AS
BEGIN
    UPDATE Presupuestos
    SET IdVehiculo = @IdVehiculo,
        Nombre = @Nombre,
        Apellido = @Apellido,
        Email = @Email,
        Total = @Total
    WHERE Id = @Id
END
GO

-- GetPresupuestosByIds
CREATE PROCEDURE GetPresupuestosByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT * FROM Presupuestos
    WHERE Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
END
GO

-- GetAllPresupuestosDto
CREATE PROCEDURE GetAllPresupuestosDto
AS
BEGIN
    SELECT p.Id, p.IdVehiculo, p.Nombre, p.Apellido, p.Email, p.Total,
           (SELECT d.Id, d.Descripcion, d.ManoDeObra, d.Tiempo,
                   (SELECT r.Id, r.Nombre, r.Precio
                    FROM DesperfectoRepuestos dr
                    INNER JOIN Repuestos r ON dr.RepuestoId = r.Id
                    WHERE dr.DesperfectoId = d.Id
                    FOR JSON PATH) AS Repuestos
            FROM Desperfectos d
            WHERE d.IdPresupuesto = p.Id
            FOR JSON PATH) AS Desperfectos
    FROM Presupuestos p
    FOR JSON PATH
END
GO

-- GetPresupuestoDtoById
CREATE PROCEDURE GetPresupuestoDtoById
    @Id INT
AS
BEGIN
    SELECT p.Id, p.IdVehiculo, p.Nombre, p.Apellido, p.Email, p.Total,
           (SELECT d.Id, d.Descripcion, d.ManoDeObra, d.Tiempo,
                   (SELECT r.Id, r.Nombre, r.Precio
                    FROM DesperfectoRepuestos dr
                    INNER JOIN Repuestos r ON dr.RepuestoId = r.Id
                    WHERE dr.DesperfectoId = d.Id
                    FOR JSON PATH) AS Repuestos
            FROM Desperfectos d
            WHERE d.IdPresupuesto = p.Id
            FOR JSON PATH) AS Desperfectos
    FROM Presupuestos p
    WHERE p.Id = @Id
    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
END
GO

-- GetPresupuestosDtoByIds
CREATE PROCEDURE GetPresupuestosDtoByIds
    @Ids NVARCHAR(MAX)
AS
BEGIN
    SELECT p.Id, p.IdVehiculo, p.Nombre, p.Apellido, p.Email, p.Total,
           (SELECT d.Id, d.Descripcion, d.ManoDeObra, d.Tiempo,
                   (SELECT r.Id, r.Nombre, r.Precio
                    FROM DesperfectoRepuestos dr
                    INNER JOIN Repuestos r ON dr.RepuestoId = r.Id
                    WHERE dr.DesperfectoId = d.Id
                    FOR JSON PATH) AS Repuestos
            FROM Desperfectos d
            WHERE d.IdPresupuesto = p.Id
            FOR JSON PATH) AS Desperfectos
    FROM Presupuestos p
    WHERE p.Id IN (SELECT value FROM STRING_SPLIT(@Ids, ','))
    FOR JSON PATH
END
GO


-- -------------------------------------------------
-- 1) Repuesto mas utilizado agrupado por Marca/Modelo en las reparaciones realizadas
--(mostrar Descripcion del Repuesto y cantidad de veces usado)

--GET /api/consultas/repuestos-mas-utilizados

CREATE PROCEDURE RepuestoMasUtilizadoPorMarcaModelo
AS
BEGIN
    SELECT 
        r.Nombre AS RepuestoNombre,
        COUNT(*) AS CantidadVecesUsado,
        v.Marca,
        v.Modelo
    FROM
        DesperfectoRepuestos dr
        INNER JOIN Repuestos r ON dr.RepuestoId = r.Id
        INNER JOIN Desperfectos d ON dr.DesperfectoId = d.Id
        INNER JOIN Presupuestos p ON d.IdPresupuesto = p.Id
        INNER JOIN Vehiculos v ON p.IdVehiculo = v.Id
    GROUP BY
        r.Nombre, v.Marca, v.Modelo
    ORDER BY
        CantidadVecesUsado DESC
END
GO

--2)Promedio del Monto Total de Presupuestos agrupado por Marca/Modelo
--GET /api/consultas/promedio-montos-presupuestos

CREATE PROCEDURE PromedioMontoTotalPresupuestoPorMarcaModelo
AS
BEGIN
    SELECT
        v.Marca,
        v.Modelo,
        CAST(ROUND(AVG(p.Total), 2) AS DECIMAL(10, 2)) AS PromedioMontoTotal
    FROM
        Presupuestos p
        INNER JOIN Vehiculos v ON p.IdVehiculo = v.Id
    GROUP BY
        v.Marca, v.Modelo
END
GO

--3)Sumatoria del Monto Total de Presupuestos para Autos y para Motos
--GET /api/consultas/sumatoria-montos-presupuestos

CREATE PROCEDURE SumatoriaMontoTotalPresupuestosPorTipoVehiculo
AS
BEGIN
    SELECT
        'Auto' AS TipoVehiculo,
        SUM(p.Total) AS SumatoriaMontoTotal
    FROM
        Presupuestos p
        INNER JOIN Automoviles a ON p.IdVehiculo = a.Id
    
    UNION ALL
    
    SELECT
        'Moto' AS TipoVehiculo,
        SUM(p.Total) AS SumatoriaMontoTotal
    FROM
        Presupuestos p
        INNER JOIN Motos m ON p.IdVehiculo = m.Id
END
GO






----------------------------------------------------------------------------------
--Adicional



/*
EXEC dbo.MassiveCharge 
*/

/*****************************************************************************************/
/*+                                                                                      */
/*+ Nombre  : dbo.MassiveCharge                                                          */
/*+ Objetivo: Insertar en la BD una serie de Respuestos con sus Precios                  */
/*+                                                                                      */
/*****************************************************************************************/

CREATE PROC [dbo].[MassiveCharge] AS
BEGIN

/*+ Creacion de la tabla Temporal que contendra los Repuestos con sus precios*/

    CREATE TABLE #TMP_RESPUESTO (Nombre VARCHAR(100),
                                 Precio DECIMAL(18,6))
    CREATE TABLE #Reporte_Repuestos_Excluidos (RepuestoNombre VARCHAR(100), Precio DECIMAL(18,6))

/*+ Se generan los registros en la tabla temporal que posteriormente se evaluarán para ver si procede su carga en la tabla definitiva de Repuestos*/

    BEGIN /*+ BEGIN INSERT EN LA TEMPORAL DE RESPUESTOS*/
        INSERT INTO #TMP_RESPUESTO VALUES ('B356963821', 17.61)
        INSERT INTO #TMP_RESPUESTO VALUES ('B881468337', 40.88)
        INSERT INTO #TMP_RESPUESTO VALUES ('B867719836', 87.76)
        INSERT INTO #TMP_RESPUESTO VALUES ('B397571688', 13.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B852883143', 47.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B461882670', 22.68)
        INSERT INTO #TMP_RESPUESTO VALUES ('B333520964', 82.28)
        INSERT INTO #TMP_RESPUESTO VALUES ('B388445039', 50.71)
        INSERT INTO #TMP_RESPUESTO VALUES ('B648201513', 21.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B436759416', 35.39)
        INSERT INTO #TMP_RESPUESTO VALUES ('B317533243', 22.84)
        INSERT INTO #TMP_RESPUESTO VALUES ('B666592414', 58.67)
        INSERT INTO #TMP_RESPUESTO VALUES ('B443568817', 53.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B316416378', 17.74)
        INSERT INTO #TMP_RESPUESTO VALUES ('B252543362', 16.98)
        INSERT INTO #TMP_RESPUESTO VALUES ('B453148609', 14.23)
        INSERT INTO #TMP_RESPUESTO VALUES ('B254958806', 41.19)
        INSERT INTO #TMP_RESPUESTO VALUES ('B356963821', 62.58)
        INSERT INTO #TMP_RESPUESTO VALUES ('B846487171', 92.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B397571688', 1.04)
        INSERT INTO #TMP_RESPUESTO VALUES ('B535169105', 90.14)
        INSERT INTO #TMP_RESPUESTO VALUES ('B628263302', 78.64)
        INSERT INTO #TMP_RESPUESTO VALUES ('B608816685', 93.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B660755442', 43.62)
        INSERT INTO #TMP_RESPUESTO VALUES ('B659053715', 90.59)
        INSERT INTO #TMP_RESPUESTO VALUES ('B556344166', 71.62)
        INSERT INTO #TMP_RESPUESTO VALUES ('B216140665', 93.15)
        INSERT INTO #TMP_RESPUESTO VALUES ('B843858581', 66.52)
        INSERT INTO #TMP_RESPUESTO VALUES ('B790077756', 8.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B916071768', 85.46)
        INSERT INTO #TMP_RESPUESTO VALUES ('B317533243', 7.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B343454513', 22.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B986574036', 65.10)
        INSERT INTO #TMP_RESPUESTO VALUES ('B662139869', 3.50)
        INSERT INTO #TMP_RESPUESTO VALUES ('B618792223', 6.87)
        INSERT INTO #TMP_RESPUESTO VALUES ('B578485476', 49.70)
        INSERT INTO #TMP_RESPUESTO VALUES ('B132813434', 32.58)
        INSERT INTO #TMP_RESPUESTO VALUES ('B776163235', 73.64)
        INSERT INTO #TMP_RESPUESTO VALUES ('B215908676', 92.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B871139440', 31.83)
        INSERT INTO #TMP_RESPUESTO VALUES ('B564893705', 18.91)
        INSERT INTO #TMP_RESPUESTO VALUES ('B634131771', 70.35)
        INSERT INTO #TMP_RESPUESTO VALUES ('B321187273', 91.96)
        INSERT INTO #TMP_RESPUESTO VALUES ('B444737823', 78.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B413525993', 9.93)
        INSERT INTO #TMP_RESPUESTO VALUES ('B229547877', 97.08)
        INSERT INTO #TMP_RESPUESTO VALUES ('B545788950', 11.84)
        INSERT INTO #TMP_RESPUESTO VALUES ('B658514562', 8.84)
        INSERT INTO #TMP_RESPUESTO VALUES ('B736313138', 78.47)
        INSERT INTO #TMP_RESPUESTO VALUES ('B840888802', 93.85)
        INSERT INTO #TMP_RESPUESTO VALUES ('B883572821', 21.57)
        INSERT INTO #TMP_RESPUESTO VALUES ('B493478663', 76.98)
        INSERT INTO #TMP_RESPUESTO VALUES ('B718838840', 7.41)
        INSERT INTO #TMP_RESPUESTO VALUES ('B183671709', 45.53)
        INSERT INTO #TMP_RESPUESTO VALUES ('B908384721', 14.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B566417680', 44.04)
        INSERT INTO #TMP_RESPUESTO VALUES ('B633833113', 33.28)
        INSERT INTO #TMP_RESPUESTO VALUES ('B829258206', 41.74)
        INSERT INTO #TMP_RESPUESTO VALUES ('B350041352', 85.13)
        INSERT INTO #TMP_RESPUESTO VALUES ('B548168477', 7.44)
        INSERT INTO #TMP_RESPUESTO VALUES ('B765657146', 89.79)
        INSERT INTO #TMP_RESPUESTO VALUES ('B830231322', 81.42)
        INSERT INTO #TMP_RESPUESTO VALUES ('B816385774', 9.30)
        INSERT INTO #TMP_RESPUESTO VALUES ('B857448796', 77.36)
        INSERT INTO #TMP_RESPUESTO VALUES ('B302875266', 54.89)
        INSERT INTO #TMP_RESPUESTO VALUES ('B790507487', 50.41)
        INSERT INTO #TMP_RESPUESTO VALUES ('B723629401', 65.36)
        INSERT INTO #TMP_RESPUESTO VALUES ('B595728629', 19.94)
        INSERT INTO #TMP_RESPUESTO VALUES ('B472436824', 65.69)
        INSERT INTO #TMP_RESPUESTO VALUES ('B235859870', 66.44)
        INSERT INTO #TMP_RESPUESTO VALUES ('B874178252', 42.38)
        INSERT INTO #TMP_RESPUESTO VALUES ('B777713850', 40.26)
        INSERT INTO #TMP_RESPUESTO VALUES ('B550221285', 8.72)
        INSERT INTO #TMP_RESPUESTO VALUES ('B816043247', 73.97)
        INSERT INTO #TMP_RESPUESTO VALUES ('B607313788', 15.95)
        INSERT INTO #TMP_RESPUESTO VALUES ('B396482694', 45.17)
        INSERT INTO #TMP_RESPUESTO VALUES ('B504021331', 24.52)
        INSERT INTO #TMP_RESPUESTO VALUES ('B651475349', 86.77)
        INSERT INTO #TMP_RESPUESTO VALUES ('B470409863', 11.81)
        INSERT INTO #TMP_RESPUESTO VALUES ('B264135435', 62.58)
        INSERT INTO #TMP_RESPUESTO VALUES ('B755636151', 33.88)
        INSERT INTO #TMP_RESPUESTO VALUES ('B382183955', 0.92)
        INSERT INTO #TMP_RESPUESTO VALUES ('B667316286', 0.29)
        INSERT INTO #TMP_RESPUESTO VALUES ('B783117048', 41.57)
        INSERT INTO #TMP_RESPUESTO VALUES ('B812952354', 86.25)
        INSERT INTO #TMP_RESPUESTO VALUES ('B621838237', 80.54)
        INSERT INTO #TMP_RESPUESTO VALUES ('B665465223', 53.69)
        INSERT INTO #TMP_RESPUESTO VALUES ('B881682635', 64.78)
        INSERT INTO #TMP_RESPUESTO VALUES ('B646289861', 72.01)
        INSERT INTO #TMP_RESPUESTO VALUES ('B852115667', 48.73)
        INSERT INTO #TMP_RESPUESTO VALUES ('B144635415', 34.23)
        INSERT INTO #TMP_RESPUESTO VALUES ('B874863828', 24.70)
        INSERT INTO #TMP_RESPUESTO VALUES ('B333841476', 41.57)
        INSERT INTO #TMP_RESPUESTO VALUES ('B587386017', 45.27)
        INSERT INTO #TMP_RESPUESTO VALUES ('B874270576', 42.38)
        INSERT INTO #TMP_RESPUESTO VALUES ('B300733136', 25.55)
        INSERT INTO #TMP_RESPUESTO VALUES ('B611446656', 60.12)
        INSERT INTO #TMP_RESPUESTO VALUES ('B801300387', 61.04)
        INSERT INTO #TMP_RESPUESTO VALUES ('B845153562', 60.09)
        INSERT INTO #TMP_RESPUESTO VALUES ('B943846621', 37.05)
    END /*+ END INSERT EN LA TEMPORAL DE RESPUESTOS*/

    --declaracion del cursor
   DECLARE repuestos_cursor CURSOR FOR
        SELECT Nombre, Precio FROM #TMP_RESPUESTO

    OPEN repuestos_cursor

    DECLARE @Nombre VARCHAR(100)
    DECLARE @Precio DECIMAL(18,6)

    FETCH NEXT FROM repuestos_cursor INTO @Nombre, @Precio

    --arranco a iterar cada fila del cursor, una por una
    WHILE @@FETCH_STATUS = 0
    BEGIN
        IF @Precio < 20
        BEGIN
            -- chequeo si el respuesto ya se inserto antes
            IF EXISTS (SELECT 1 FROM Repuestos WHERE Nombre = @Nombre)
            BEGIN
                -- si ya existe, actualizo el precio sumandole el valor del duplicado 
                UPDATE Repuestos 
                SET Precio = Precio + @Precio 
                WHERE Nombre = @Nombre
            END
            ELSE
            BEGIN
                -- si no existe inserto un repuesto nuevo
                INSERT INTO Repuestos (Nombre, Precio) 
                VALUES (@Nombre, @Precio)
            END
        END
        ELSE
        BEGIN
            -- guardo los repuestos que no se insertaron/actualizaron
            INSERT INTO #Reporte_Repuestos_Excluidos (RepuestoNombre, Precio) VALUES (@Nombre, @Precio)
        END

        FETCH NEXT FROM repuestos_cursor INTO @Nombre, @Precio
    END

    CLOSE repuestos_cursor
    DEALLOCATE repuestos_cursor

    SELECT * FROM #Reporte_Repuestos_Excluidos

    DROP TABLE #Reporte_Repuestos_Excluidos;
    DROP TABLE #TMP_RESPUESTO;
END
GO
