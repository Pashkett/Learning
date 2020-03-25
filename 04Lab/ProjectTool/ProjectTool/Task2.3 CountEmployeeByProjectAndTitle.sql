USE [ProjectToolDB]
GO

SELECT 
	p.ProjectName, 
	t.TitleName, 
	COUNT(pm.EmployeeId) AS CountOfEmployee
	
FROM dbo.Project AS p
	LEFT JOIN dbo.ProjectMember AS pm
		ON p.ProjectId = pm.ProjectId
	LEFT JOIN dbo.Employee AS e
		ON pm.EmployeeId = e.EmployeeId
	LEFT JOIN dbo.Title AS t
		ON pm.TitleId = t.TitleId

GROUP BY 
	p.ProjectName, 
	t.TitleName

ORDER BY p.ProjectName

GO