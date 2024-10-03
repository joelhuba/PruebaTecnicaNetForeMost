CREATE PROCEDURE [dbo].[GetListBalanceManagersAssignment]
	@PageIndex  INT = 1,
	@PageSize INT = 10,
	@AssignmentId INT
AS
SELECT B.AssignmentId,BA.Balance,M.Name  FROM BalanceManagersAssignment B JOIN Balance BA ON B.BalanceId = BA.BalanceId JOIN Managers M ON B.ManagerId = M.ManagerId  WHERE (@AssignmentId IS NULL OR @AssignmentId = 0  OR B.AssignmentId = @AssignmentId)
 ORDER BY B.AssignmentId OFFSET(@PageIndex - 1) * @PageSize ROWS 
 FETCH NEXT @PageSize ROWS ONLY;
 SELECT COUNT(*) AS TotalRecords  FROM BalanceManagersAssignment B  WHERE (@AssignmentId IS NULL OR @AssignmentId = 0  OR B.AssignmentId = @AssignmentId)