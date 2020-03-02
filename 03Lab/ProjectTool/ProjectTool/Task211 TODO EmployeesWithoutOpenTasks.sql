USE [ProjectToolDB]
GO

SELECT 
	pt.ProjectId
	, e.FirstName + ' ' + e.LastName AS FullName
	, COUNT(pt.ProjectTaskId) AS TaskCount
FROM dbo.ProjectTask AS pt
	LEFT JOIN dbo.ProjectMember AS pm
		ON pt.ProjectMemberId = pm.ProjectMemberId
	RIGHT JOIN dbo.Employee AS e
		ON pm.EmployeeId = e.EmployeeId
WHERE 
	pm.ProjectMemberId IS NOT NULL 
	AND e.EmployeeId IS NOT NULL
	AND pt.StatusId IN (1, 3)
GROUP BY 
	pt.ProjectId, e.FirstName + ' ' + e.LastName



		   --('Open'),			--1
		   --('Completed'),		--2
		   --('Need Refinement'),	--3
		   --('Rejected'),		--4
		   --('Resolved')			--5