CREATE PROCEDURE [dbo].[CreateManager]
	@Name NVARCHAR(50)
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
		INSERT INTO Managers (Name) VALUES (@Name);
		SET @IsSuccess = 1;
		SET @Message = 'Gestor Creado Con Exito'
	END TRY

	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END