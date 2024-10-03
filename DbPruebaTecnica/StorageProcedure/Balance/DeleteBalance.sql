CREATE PROCEDURE [dbo].[DeleteBalance]
	@BalanceId INT
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
	 DELETE FROM Balance WHERE BalanceId = @BalanceId
	 SET @IsSuccess = 1;
		SET @Message = 'Saldo Eliminado Con Exito'
	END TRY
	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END