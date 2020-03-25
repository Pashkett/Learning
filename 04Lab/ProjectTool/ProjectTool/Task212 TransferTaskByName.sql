USE [ProjectToolDB]
GO

DECLARE @TaskName NVARCHAR(200) = 'ProjectTask5.488';
--Query for check
SELECT
	pt.ProjectMemberId
	, e.FirstName + ' ' + e.LastName AS EmployeeFullName
FROM dbo.ProjectTask AS pt
	INNER JOIN dbo.ProjectMember AS pm
		ON pt.ProjectMemberId = pm.ProjectMemberId
	INNER JOIN dbo.Employee AS e
		ON pm.EmployeeId = e.EmployeeId
WHERE 
	pt.TaskName = @TaskName;

--Main Query
WITH Temp(ProjectId, NewMemberToAssign, ProjectTaskId, OpenTasksCount) AS  
(  
    SELECT TOP 1
        pt2.ProjectId
        , pm.ProjectMemberId AS NewMemberToAssign
        , calc.ProjectTaskId
        , COUNT(pt2.ProjectTaskId) OpenTasksCount

    FROM 
        (SELECT 
            p.ProjectId
            , pt.ProjectTaskId
            
        FROM dbo.Project AS p
            INNER JOIN dbo.ProjectTask AS pt
                ON (p.ProjectId = pt.ProjectId)
        WHERE 
            p.IsCompleted = 0
            AND pt.StatusId IN (1, 3)
            AND pt.TaskName = @TaskName
                                ) AS calc
        INNER JOIN dbo.ProjectTask AS pt2
            ON calc.ProjectId = pt2.ProjectId
        INNER JOIN dbo.ProjectMember AS pm
            ON pt2.ProjectMemberId = pm.ProjectMemberId
        
    WHERE
        pt2.StatusId IN (1, 3)

    GROUP BY    
        pt2.ProjectId
        , pm.ProjectMemberId
        , calc.ProjectTaskId

    ORDER BY 
		COUNT(pt2.ProjectTaskId)
)
UPDATE dbo.ProjectTask
SET ProjectMemberId = t.NewMemberToAssign
FROM dbo.ProjectTask AS pt
    INNER JOIN Temp as t
        ON pt.ProjectTaskId = t.ProjectTaskId

--Query for Check
SELECT
	pt.ProjectMemberId
	, e.FirstName + ' ' + e.LastName AS EmployeeFullName
FROM dbo.ProjectTask AS pt
	INNER JOIN dbo.ProjectMember AS pm
		ON pt.ProjectMemberId = pm.ProjectMemberId
	INNER JOIN dbo.Employee AS e
		ON pm.EmployeeId = e.EmployeeId
WHERE 
	pt.TaskName = @TaskName;

GO