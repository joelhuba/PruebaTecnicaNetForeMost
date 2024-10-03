CREATE PROCEDURE [dbo].[GetListManagers]
	@PageIndex  INT = 1,
	@PageSize INT = 10,
	@ManagerId INT
AS
BEGIN
	SELECT M.ManagerId,M.Name  FROM Managers M  WHERE (@ManagerId IS NULL OR @ManagerId = 0  OR M.ManagerId = @ManagerId)
	 ORDER BY M.ManagerId OFFSET(@PageIndex - 1) * @PageSize ROWS 
	 FETCH NEXT @PageSize ROWS ONLY;
	 SELECT COUNT(*) AS TotalRecords  FROM Managers M   WHERE (@ManagerId IS NULL OR @ManagerId = 0  OR M.ManagerId = @ManagerId)
END
