SELECT 
	p.ProjectName
	, COUNT(pt.ProjectTaskId) AS CountOfNotStartedTasks

FROM dbo.Project AS p
	LEFT JOIN dbo.ProjectTask AS pt
		ON p.ProjectId = pt.ProjectId

WHERE
	pt.IsStarted = 0

GROUP BY 
	p.ProjectName