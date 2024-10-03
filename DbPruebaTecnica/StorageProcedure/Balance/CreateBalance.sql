CREATE PROCEDURE [dbo].[CreateBalance]
	@Balance DECIMAL(18,2)
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
		INSERT INTO Balance (Balance) VALUES (@Balance)
			SET @IsSuccess = 1;
		SET @Message = 'Saldo Creado Con Exito'
	END TRY

	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END