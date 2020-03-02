USE [ProjectToolDB]
GO

UPDATE dbo.ProjectTask
   SET EstimatedCloseDate = DATEADD(DAY, 5, EstimatedCloseDate)
 WHERE 
	StatusId IN (1, 3)

GO