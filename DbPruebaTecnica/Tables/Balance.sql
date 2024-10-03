CREATE TABLE [dbo].[Balance]
(
	[BalanceId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Balance] DECIMAL(18, 2) NULL, 
    [IsAssignment] BIT NULL DEFAULT 0
)
