create database CompanyMM

use CompanyMM


create table  Employees(
EmployeeID int primary key identity,
FirstName nvarchar(30) not null,
LastName nvarchar(50),
BirthDate date not null,
Email varchar(80) not  null unique,
Constraint CheckBrithday Check (DateDiff(Year, BirthDate, GetDate())>= 18),
Constraint CheckFirstName Check (len(FirstName)>=3)
)

create table Projects(
ProjectID int primary key identity,
ProjectName nvarchar(50) not null,
StartDate date,
EndDate date,
Constraint CheckDate Check(EndDate>StartDate)
)

create table EmployeeProjects(
EmployeeID int foreign key references Employees(EmployeeID),
ProjectID int foreign key references Projects(ProjectID),
AsignedDate date,
Primary key(EmployeeID,ProjectID)
)

INSERT INTO Employees (FirstName, LastName, BirthDate, Email) VALUES 
('Farid', 'Alizade', '1995-03-12', 'farid.a@company.com'),
('Nermin', 'Mammadova', '1998-07-20', 'nermin.m@company.com'),
('Tural', 'Hasanov', '1990-11-05', 'tural.h@company.com'),
('Laman', 'Karimova', '2001-01-15', 'laman.k@company.com'),
('Seymur', 'Rzayev', '1988-05-30', 'seymur.r@company.com')

INSERT INTO Projects (ProjectName, StartDate, EndDate) VALUES 
('Cyber Security Upgrade', '2024-01-01', '2024-12-31'),
('Mobile Banking App', '2024-03-15', '2025-03-15'),
('Data Analytics Platform', '2024-06-01', '2024-11-30')

INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AsignedDate) VALUES 
(1, 1, '2024-01-05'), 
(1, 2, '2024-03-20'),
(2, 2, '2024-04-01'), 
(3, 3, '2024-06-10'), 
(4, 1, '2024-02-01'), 
(5, 1, '2024-01-10'), 
(5, 2, '2024-04-15'), 
(5, 3, '2024-06-15')

--A. SELECT / JOIN / GROUP BY
--1. Bütün employees siyahýsý.
Select * from Employees
 --2. Bütün projects siyahýsý.
Select * from Projects
--3. H?r employee-nin hansý project(l?r)-d? iþl?diyini göst?r?n sorðu (JOIN il?).
select e.FirstName,e.LastName,e.BirthDate,e.Email,ep.AsignedDate,pr.ProjectName,pr.StartDate,pr.EndDate
from Employees as e
join EmployeeProjects as ep on ep.EmployeeID = e.EmployeeID
join Projects as pr on pr.ProjectID = ep.ProjectID
--4. H?r project-? assign edilmiþ employee sayý (GROUP BY il?).
Select pr.ProjectName,COUNT(ep.EmployeeID) as [Employee Count] from Projects as pr
join EmployeeProjects as ep on pr.ProjectID = ep.ProjectID
group By pr.ProjectName
--5. 2-d?n çox project-d? iþl?y?n employee-l?ri tapýn (HAVING istifad? edin).
Select e.FirstName, e.LastName , COUNT(ep.ProjectID) as [Project Count] from Employees as e
join EmployeeProjects as ep on ep.EmployeeID = e.EmployeeID
group by e.FirstName, e.LastName
having COUNT(ep.ProjectID)>2

--B. Views
--6. EmployeeProjectView adlý VIEW yaradýn: h?r s?trd? EmployeeID, FullName, ProjectID, ProjectName, AssignedDate olsun.
Create view EmployeeProjectView
as
select e.EmployeeID,e.FirstName + ' '+ e.LastName as FullName ,pr.ProjectID, pr.ProjectName , ep.AsignedDate
from Employees as e
join EmployeeProjects as ep on ep.EmployeeID = e.EmployeeID
join Projects as pr on pr.ProjectID = ep.ProjectID
--7. View-dan istifad? ed?r?k bir employee üçün (m?s?l?n EmployeeID = 1) bütün project-l?ri göst?rin
Select * from dbo.EmployeeProjectView
where EmployeeID =1

--C. Procedures v? Functions
--8. Stored procedure yazýn: sp_AssignEmployeeToProject(IN empId INT, IN projId INT) — ?g?r t?yinat yoxdursa, EmployeeProjects-? INSERT etsin; varsa heç n? etm?sin.
create procedure sp_AssignEmployeeToProject(@empId INT,@projId INT)
as
begin
	if not exists (select 1 from EmployeeProjects where EmployeeID= @empId and ProjectID =@projId) 
	begin
		insert into EmployeeProjects(EmployeeID, ProjectID, AsignedDate)
		values(@empId,@projId,GETDATE())
	end
end
--9. Function yazýn: fn_GetProjectCount(empId INT) RETURNS INT — veril?n employee üçün project sayýný döndürsün. Function-u çaðýrýb n?tic?ni göst?rin (SELECT il?).
create function fn_GetProjectCount(@empId INT)
returns int
as
begin
	declare @count int
	select @count = count(EmployeeID) from EmployeeProjects where EmployeeID = @empId
	return @count
end

select dbo.fn_GetProjectCount(2) as [Project Count]

--E. D?yiþiklik v? silm?
--10. sp_AssignEmployeeToProject istifad? ed?r?k yeni t?yinat ?lav? edin v? n?tic?ni yoxlayýn.
exec dbo.sp_AssignEmployeeToProject 2 ,3
select * from dbo.EmployeeProjectView

--11. Bir employee-nin bütün project-l?rind?n çýxarýn (DELETE FROM EmployeeProjects WHERE EmployeeID = X) 
DELETE FROM EmployeeProjects WHERE EmployeeID = 2
select * from dbo.EmployeeProjectView
