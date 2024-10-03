CREATE PROCEDURE [dbo].[DeleteBalanceManagersAssignment]
		@AssignmentId INT
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
		DELETE FROM BalanceManagersAssignment WHERE AssignmentId = @AssignmentId
		SET @IsSuccess = 1;
		SET @Message = 'Asignsion de saldo Eliminada Con Exito'
	END TRY

	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END