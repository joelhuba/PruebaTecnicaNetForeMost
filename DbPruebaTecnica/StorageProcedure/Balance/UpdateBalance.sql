CREATE PROCEDURE [dbo].[UpdateBalance]
	@BalanceId INT,
	@Balance DECIMAL(18,2)
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
		UPDATE Balance SET Balance = @Balance WHERE BalanceId = @BalanceId
		SET @IsSuccess = 1;
		SET @Message = 'Saldo Actualizado Con Exito'
	END TRY

	
	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess


END