CREATE PROCEDURE [dbo].[UpdateBalanceManagersAssignment]
	@AssignmentId INT,
	@ManagerId INT,
	@BalanceId INT
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
	UPDATE BalanceManagersAssignment SET ManagerId = @ManagerId, BalanceId = @BalanceId WHERE AssignmentId = @AssignmentId
	SET @IsSuccess = 1;
		SET @Message = 'Asignsion de saldo Actualizada Con Exito'
	END TRY

	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END