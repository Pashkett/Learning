USE [ProjectToolDB]
GO

UPDATE dbo.Project
	SET 
		[ClosingDate] = 
		   (SELECT
				MAX(pt.EstimatedCloseDate)

			FROM dbo.Project AS p
				LEFT JOIN dbo.ProjectTask AS pt
					ON (p.ProjectId = pt.ProjectId)
			WHERE p.ProjectId = dbo.Project.ProjectId 
				AND EXISTS 
					(SELECT
						p2.ProjectId
						, COUNT(pt2.ProjectTaskId)

					FROM dbo.Project AS p2
						LEFT JOIN dbo.ProjectTask AS pt2
							ON (p2.ProjectId = pt2.ProjectId AND pt2.StatusId IN (1, 3))
					WHERE 
						p2.IsCompleted = 0 AND p2.ProjectId = p.ProjectId
	
					GROUP BY 
						p2.ProjectId
					HAVING COUNT(pt2.ProjectTaskId) = 0)
	
			GROUP BY 
				p.ProjectId)

	WHERE IsCompleted = 0
GO




		   --('Open'),			--1
		   --('Completed'),		--2
		   --('Need Refinement'),	--3
		   --('Rejected'),		--4
		   --('Resolved')			--5