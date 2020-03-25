USE [ProjectToolDB]
GO

SELECT DISTINCT
	p.ProjectId
	, p.ProjectName
	, DATEDIFF(day
		, MIN(pt.EstimatedCloseDate) OVER (PARTITION BY p.ProjectId)
		, MAX(pt.EstimatedCloseDate) OVER (PARTITION BY p.ProjectId)
	) AS Duration

FROM dbo.Project AS p
	INNER JOIN dbo.ProjectTask AS pt
		ON p.ProjectId = pt.ProjectId

GO