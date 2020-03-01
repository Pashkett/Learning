--Create Database

USE master;
GO
IF DB_ID (N'ProjectToolDB') IS NOT NULL
DROP DATABASE ProjectToolDB;
GO
CREATE DATABASE ProjectToolDB;
GO

--Create DB Scheme
USE ProjectToolDB;
GO
--Employee table 
CREATE TABLE dbo.Employee
(
    EmployeeId INT NOT NULL PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(200),
	LastName NVARCHAR(200)
)
--Project table 
CREATE TABLE dbo.Project
(
    ProjectId INT NOT NULL PRIMARY KEY IDENTITY,
    ProjectName NVARCHAR(200),
	CreationDate DATETIME,
	ClosingDate DATETIME,
	IsCompleted BIT 
)
--Title table
CREATE TABLE dbo.Title
(
    TitleId INT NOT NULL PRIMARY KEY IDENTITY,
    TitleName NVARCHAR(200)
)
--Status table
CREATE TABLE dbo.TaskStatus
(
    StatusId INT NOT NULL PRIMARY KEY IDENTITY,
    StatusName NVARCHAR(200)
)
CREATE TABLE dbo.ProjectMember
(
    ProjectMemberId INT NOT NULL PRIMARY KEY IDENTITY,
	EmployeeId INT,
	ProjectId INT,
	TitleId INT,
	FOREIGN KEY (EmployeeId) REFERENCES Employee (EmployeeId),
	FOREIGN KEY (ProjectId) REFERENCES Project (ProjectId),
	FOREIGN KEY (TitleId) REFERENCES Title (TitleId),
)
CREATE TABLE dbo.ProjectTask
(
    ProjectTaskId INT NOT NULL PRIMARY KEY IDENTITY,
	TaskName NVARCHAR(200),
	ProjectMemberId INT,
	ProjectId INT,
	StatusId INT,
	StatusModifiedById INT,
	StatusModifiedOn DATETIME,
	EstimatedCloseDate DATETIME,
	FOREIGN KEY (ProjectMemberId) REFERENCES ProjectMember (ProjectMemberId),
	FOREIGN KEY (ProjectId) REFERENCES Project (ProjectId),
	FOREIGN KEY (StatusId) REFERENCES TaskStatus (StatusId),
	FOREIGN KEY (StatusModifiedById) REFERENCES ProjectMember (ProjectMemberId)
)
;