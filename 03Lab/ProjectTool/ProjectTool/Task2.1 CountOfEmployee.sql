SELECT 
	t.TitleName as Title
	, COUNT(pm.ProjectMemberId) as EmployeeCount

FROM dbo.ProjectMember AS pm
	INNER JOIN dbo.Title as t
		ON pm.TitleId = t.TitleId
	INNER JOIN dbo.Project as p
		ON pm.ProjectId = p.ProjectId

WHERE 
	p.IsCompleted = 0

group by 
	t.TitleName
