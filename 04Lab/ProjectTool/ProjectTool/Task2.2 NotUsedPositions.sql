USE [ProjectToolDB]
GO

SELECT 
	t.TitleId, 
	t.TitleName
	
FROM dbo.Title AS t
	LEFT JOIN dbo.ProjectMember AS pm
		ON t.TitleId = pm.TitleId

WHERE
	pm.TitleId IS NULL

GO