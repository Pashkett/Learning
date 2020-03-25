USE [ProjectToolDB]
GO

SELECT 
    p.ProjectId
    , p.ProjectName
    , e.FirstName + ' ' + e.LastName AS FullName
    , COUNT(pt.ProjectTaskId) AS CountOfOpenTasks

FROM dbo.Project AS p
    LEFT JOIN dbo.ProjectMember AS pm
        ON p.ProjectId = pm.ProjectId
    LEFT JOIN dbo.Employee AS e
        ON pm.EmployeeId = e.EmployeeId
    LEFT JOIN dbo.ProjectTask AS pt
        ON (pt.ProjectId = p.ProjectId AND pt.StatusId IN (1, 3))
    
WHERE
    p.IsCompleted = 0

GROUP BY
    p.ProjectId
    , p.ProjectName
    , e.FirstName + ' ' + e.LastName

HAVING COUNT(pt.ProjectTaskId) = 0

GO