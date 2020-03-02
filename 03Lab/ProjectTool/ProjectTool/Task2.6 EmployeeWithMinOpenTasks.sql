SELECT
	e.EmployeeId
	, e.FirstName + ' ' + e.LastName AS FullName
	, CASE WHEN OpenTasksCount IS NULL THEN 0 
		   ELSE OpenTasksCount END AS OpenTasksCount

FROM dbo.Employee AS e
	LEFT JOIN
		(SELECT DISTINCT
			pm.EmployeeId
			, COUNT(pt.ProjectTaskId) OVER (PARTITION BY pm.EmployeeId) AS OpenTasksCount

		FROM dbo.ProjectMember AS pm
			LEFT JOIN dbo.ProjectTask AS pt
				ON pt.ProjectMemberId = pm.ProjectMemberId
		WHERE
			pt.StatusId IN (1, 3)
		) AS summary
			ON e.EmployeeId = summary.EmployeeId

Order by OpenTasksCount