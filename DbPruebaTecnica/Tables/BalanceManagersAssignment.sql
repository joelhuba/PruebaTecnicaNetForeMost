CREATE TABLE [dbo].[BalanceManagersAssignment]
(
	[AssignmentId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [ManagerId] INT NULL, 
    [BalanceId] INT NULL, 
    CONSTRAINT [FK_BalanceManagersAssignment_Managers] FOREIGN KEY (ManagerId) REFERENCES Managers(ManagerId),
    CONSTRAINT [FK_BalanceManagersAssignment_Balance] FOREIGN KEY (BalanceId) REFERENCES Balance(BalanceId)

)
