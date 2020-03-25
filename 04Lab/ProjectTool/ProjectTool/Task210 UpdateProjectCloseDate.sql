USE [ProjectToolDB]
GO

WITH PT(ProjectId, IsCompleted, ClosingDate, OpentTasksCount) AS
(
	SELECT 
		p.ProjectId
		,1 as IsCompleted
		,(SELECT MAX(pt2.EstimatedCloseDate)
		  FROM dbo.ProjectTask as pt2
		  WHERE pt2.ProjectId = p.ProjectId) AS MaxDateOfTask
		,COUNT(pt.ProjectTaskId) as OpenTaskCount

	FROM dbo.Project AS p
		LEFT JOIN dbo.ProjectTask AS pt
			ON (p.ProjectId = pt.ProjectId AND pt.StatusId IN (1, 3))

	WHERE 
		p.IsCompleted = 0 
		AND p.ClosingDate IS NULL

	GROUP BY 
		p.ProjectId

	HAVING COUNT(pt.ProjectTaskId) = 0
)
UPDATE dbo.Project
SET 
	ClosingDate = p2.ClosingDate,
	IsCompleted = p2.IsCompleted
FROM dbo.Project AS p
    INNER JOIN PT as p2
        ON p.ProjectId = p2.ProjectId

GO