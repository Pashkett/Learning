USE [ProjectToolDB]
GO

INSERT INTO [dbo].[Employee]
           ([FirstName]
           ,[LastName])
     VALUES
		    ('Ivan', 'Ivanov'),		--1
			('Viktor', 'Petrov'),	--2
			('Petro', 'Stoyko'),	--3
			('Vitaliy', 'Hamov'),	--4
			('Roman', 'Romanov'),	--5
			('Greg', 'Hansberg'),	--6
			('Tom', 'Scott'),		--7
			('John', 'Dou'),		--8
			('Neo', 'Sidorov')		--9
GO

INSERT INTO [dbo].[Project]
           ([ProjectName]
           ,[CreationDate]
           ,[ClosingDate]
           ,[IsCompleted])
     VALUES
           ('Lanch E-Commerce', '2018-01-01 00:00:000', '2019-01-01 00:00:000', 1),		--1
		   ('Lanch Business Portal', '2019-01-01 00:00:000', '2019-07-01 00:00:000', 1),--2
		   ('Lanch CRM', '2020-01-01 00:00:000', NULL, 0),								--3
		   ('Lanch Call Center', '2020-04-01 00:00:000', NULL, 0),						--4
		   ('Lanch ERP', '2019-01-01 00:00:000', NULL, 0)								--5

GO

INSERT INTO [dbo].[Title]
           ([TitleName])
     VALUES
           ('DM'),	--1
		   ('PM'),	--2
		   ('BA'),	--3
		   ('SE')	--4
GO

INSERT INTO [dbo].[TaskStatus]
           ([StatusName])
     VALUES
           ('Open'),			--1
		   ('Completed'),		--2
		   ('Need Refinement'),	--3
		   ('Rejected'),		--4
		   ('Resolved')			--5
GO

INSERT INTO [dbo].[ProjectMember]
           ([EmployeeId]
           ,[ProjectId]
           ,[TitleId])
     VALUES
           (1, 1, 1), --1
		   (2, 1, 3), --2
		   (3, 1, 4), --3
		   (4, 1, 4), --4

		   (3, 2, 1), --5
		   (4, 2, 2), --6
		   (5, 2, 3), --7
		   (6, 2, 4), --8
		   (7, 2, 4), --9
		   (8, 2, 4), --10

		   (4, 3, 1), --11
		   (5, 3, 2), --12
		   (6, 3, 3), --13
		   (7, 3, 4), --14
		   (8, 3, 4), --15
		   (9, 3, 4), --16

		   (1, 4, 1), --17
		   (2, 4, 3), --18
		   (3, 4, 4), --19
		   (4, 4, 4), --20

		   (6, 5, 1), --21
		   (7, 5, 3), --22
		   (8, 5, 4), --23
		   (9, 5, 4)  --24
GO

USE [ProjectToolDB]
GO

--INSERT INTO [dbo].[ProjectTask]
--           ([TaskName]
--           ,[ProjectMemberId]
--           ,[ProjectId]
--           ,[StatusId]
--           ,[StatusModifiedById]
--           ,[StatusModifiedOn]
--           ,[EstimatedCloseDate])
--     VALUES
--           --(<TaskName, nvarchar(200),>
--           --,<ProjectMemberId, int,>
--           --,<ProjectId, int,>
--           --,<StatusId, int,>
--           --,<StatusModifiedById, int,>
--           --,<StatusModifiedOn, datetime,>
--           --,<EstimatedCloseDate, datetime,>)
--GO