CREATE PROCEDURE [dbo].[AssignBalanceToManager]
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IsSuccess BIT;
    DECLARE @Message NVARCHAR(MAX);
    DECLARE @NumberOfManagers INT;
    DECLARE @BalancesAssigned INT = 0;
    DECLARE @Iterations INT = 0;


    DECLARE @AssignedAssignments TABLE (
        ManagerId INT,
        BalanceId INT
    );

    BEGIN TRY
        BEGIN TRANSACTION;


        SELECT @NumberOfManagers = COUNT(*) FROM Managers;

        IF @NumberOfManagers = 0
        BEGIN
            SET @IsSuccess = 0;
            SET @Message = 'No hay managers disponibles.';
            ROLLBACK TRANSACTION;
            GOTO EndProcedure;
        END


        DECLARE BalanceCursor CURSOR FOR
        SELECT BalanceId
        FROM Balance WITH (UPDLOCK, READPAST)
        WHERE IsAssignment = 0
        ORDER BY Balance DESC; 

        OPEN BalanceCursor;

        DECLARE @BalanceId INT;
        DECLARE @CurrentManager INT = 1;
        DECLARE @ManagerId INT;

        FETCH NEXT FROM BalanceCursor INTO @BalanceId;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            SELECT @ManagerId = ManagerId
            FROM (
                SELECT ManagerId, ROW_NUMBER() OVER (ORDER BY ManagerId) AS RowNum
                FROM Managers
            ) m
            WHERE m.RowNum = @CurrentManager;

 
            INSERT INTO BalanceManagersAssignment (ManagerId, BalanceId)
            VALUES (@ManagerId, @BalanceId);

            INSERT INTO @AssignedAssignments (ManagerId, BalanceId)
            VALUES (@ManagerId, @BalanceId);

            UPDATE Balance
            SET IsAssignment = 1
            WHERE BalanceId = @BalanceId;

            SET @BalancesAssigned = @BalancesAssigned + 1;

            SET @CurrentManager = @CurrentManager + 1;
            IF @CurrentManager > @NumberOfManagers
                SET @CurrentManager = 1;

            FETCH NEXT FROM BalanceCursor INTO @BalanceId;
        END

        CLOSE BalanceCursor;
        DEALLOCATE BalanceCursor;

        SET @Iterations = CEILING(CAST(@BalancesAssigned AS FLOAT) / @NumberOfManagers);

        COMMIT TRANSACTION;

        SET @IsSuccess = 1;
        SET @Message = 'Balances asignados exitosamente.';
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SET @IsSuccess = 0;
        SET @Message = ERROR_MESSAGE();
    END CATCH

    EndProcedure:
    SELECT @Message AS Message, @IsSuccess AS IsSuccess;

    SELECT @Iterations AS Iterations;

    SELECT 
        m.ManagerId,
        m.Name,
        COUNT(a.BalanceId) AS AssignedBalances
    FROM 
        @AssignedAssignments a
    INNER JOIN 
        Managers m ON a.ManagerId = m.ManagerId
    GROUP BY 
        m.ManagerId, m.Name
    ORDER BY 
        m.ManagerId;
	SELECT b.ManagerId,ba.Balance from BalanceManagersAssignment b join Balance ba on b.BalanceId = ba.BalanceId 
END