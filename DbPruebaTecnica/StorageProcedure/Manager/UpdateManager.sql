CREATE PROCEDURE [dbo].[UpdateManager]
	@ManagerId int,
	@Name NVARCHAR(50)
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
		UPDATE Managers SET [Name] = @Name WHERE ManagerId = @ManagerId
			SET @IsSuccess = 1;
		SET @Message = 'Gestor Actualizado Con Exito'
	END TRY

	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END 

