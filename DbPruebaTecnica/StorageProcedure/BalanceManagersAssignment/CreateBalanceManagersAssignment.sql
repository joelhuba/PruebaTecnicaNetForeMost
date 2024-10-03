CREATE PROCEDURE [dbo].[CreateBalanceManagersAssignment]
	@ManagerId INT,
	@BalanceId INT
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
	DECLARE @IsAssigned BIT;
	  SELECT @IsAssigned = IsAssignment FROM Balance WHERE BalanceId = @BalanceId;
	  IF(@IsAssigned = 1)
	  BEGIN
		 SET @IsSuccess = 0;
         SET @Message = 'El saldo ya está asignado a un gestor.';
	  END
	  ELSE
	  BEGIN
		INSERT INTO BalanceManagersAssignment (ManagerId,BalanceId) VALUES (@ManagerId,@BalanceId)
		SET @IsSuccess = 1;
		SET @Message = 'Asignsion de saldo Creada Con Exito'
	  END
	  END TRY
	  BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END