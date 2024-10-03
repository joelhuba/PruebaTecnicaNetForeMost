CREATE PROCEDURE [dbo].[GetListBalance]
	@PageIndex  INT = 1,
	@PageSize INT = 10,
	@BalanceId INT
AS
BEGIN
	SELECT B.BalanceId,B.Balance  FROM Balance B  WHERE (@BalanceId IS NULL OR @BalanceId = 0  OR B.BalanceId = @BalanceId)
	 ORDER BY B.BalanceId OFFSET(@PageIndex - 1) * @PageSize ROWS 
	 FETCH NEXT @PageSize ROWS ONLY;
	 SELECT COUNT(*) AS TotalRecords  FROM Balance B   WHERE (@BalanceId IS NULL OR @BalanceId = 0  OR B.BalanceId = @BalanceId)

END
