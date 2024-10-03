CREATE PROCEDURE [dbo].[DeleteManager]
	@ManagerId INT
AS
BEGIN
	DECLARE @IsSuccess BIT;
	DECLARE @Message NVARCHAR(MAX);
	BEGIN TRY
	 DELETE FROM Managers WHERE ManagerId = @ManagerId
	 	SET @IsSuccess = 1;
		SET @Message = 'Gestor Eliminado Con Exito'
	END TRY

	BEGIN CATCH
		SET @IsSuccess = 0;
		SET @Message = ERROR_MESSAGE();
	END CATCH
	Select @Message AS Message,@IsSuccess AS  IsSuccess
END