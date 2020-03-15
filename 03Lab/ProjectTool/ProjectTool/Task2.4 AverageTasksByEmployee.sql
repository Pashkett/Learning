USE [ProjectToolDB]
GO

SELECT 
	p.ProjectId,
	p.ProjectName, 
	AVG(summary.TaskCount) AS AverageTasks

FROM dbo.Project AS p
		LEFT JOIN 
			(SELECT 
				pt.ProjectId, 
				COUNT(pt.ProjectTaskId) AS TaskCount
			FROM dbo.ProjectTask AS pt
				LEFT JOIN dbo.ProjectMember AS pm
					ON pt.ProjectMemberId = pm.ProjectMemberId
				LEFT JOIN dbo.Employee AS e
					ON pm.EmployeeId = e.EmployeeId
			WHERE 
				pm.ProjectMemberId IS NOT NULL 
				AND e.EmployeeId IS NOT NULL
			GROUP BY 
				pt.ProjectId, e.EmployeeId) AS summary
		
			ON summary.ProjectId = p.ProjectId

GROUP BY 
	p.ProjectId, p.ProjectName

ORDER BY p.ProjectId

GO