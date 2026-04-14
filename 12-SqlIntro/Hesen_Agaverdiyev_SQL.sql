create database Company

use Company

create table Employees(
EmployeeID int primary key identity(1,1),
FirstName nvarchar(30),
LastName nvarchar(50),
Email nvarchar(50),
PhoneNumber varchar(30),
HireDate date,
JobTitle nvarchar(50),
Salary decimal(10,2),
Department nvarchar(30)
)

insert into Employees(FirstName,LastName,Email,PhoneNumber,HireDate,JobTitle,Salary,Department)
values('Hasan','Agaverdiyev','hasan.agaverdiyev@gmail.com','0701234567','2017-07-23','SuperAdmin',3500,'IT'),
('Anar','Huseynov','anar.huseynov@gmail.com','0555678900','2019-03-14','Devoloper',2100,'IT'),
('Huseyn','Rzayev','huseyn.rzayev@company.az','05045678900','2024-01-09','Designer',2700,'UI'),
('Mehdi','Qurbanov','mehdi.qurbanov@gmail.com','0991234567','2024-10-27','Analitic',1500,'AI'),
('Ehmedaga','Ehmedov','ehmed.ehmedov@company.az','0102345432','2026-01-25','Admin',3000,'HR'),
('Leyla', 'Hesenova','leyla.hesenova@company.az','0510001022','2020-10-17','Data admin',2000.80,'IT')

Select * from Employees
select * from Employees where Salary>2000
select * from Employees where Department = 'IT'
select * from Employees order by Salary desc
select FirstName,Salary from Employees
select * from Employees where HireDate>'2020'
select * from Employees where Email like '%company.az%'


Select MAX(Salary) as 'En yuksek maas' from Employees
Select Min(Salary) as 'En asagi maas' from Employees
Select AVG(Salary) as 'Ortalama maas' from Employees
select COUNT(EmployeeID) as 'Iscilerin sayi' from Employees
select SUM(Salary) as 'Maaslarin cemi' from Employees

select Department,COUNT(EmployeeID) as 'Iscilerin sayi' from Employees Group by Department
select Department, AVG(Salary) As 'ortalama maas' from Employees group by Department
Select Department, max(Salary) as 'Maksimum maas' from Employees group by Department

update Employees set Salary = 2800 where EmployeeID = 1
update Employees set Salary = Salary*1.1 where Department = 'IT'
update Employees set JobTitle = 'HR Meneceri' where FirstName= 'Leyla' and LastName = 'Hesenova'

delete Employees where EmployeeID = 5
insert into Employees(FirstName,LastName,Email,PhoneNumber,HireDate,JobTitle,Salary,Department)
values('Resad', 'Eliyev', 'rashad@gmail.com', '0703334455', '2022-08-20', 'System Admin', 1200, 'IT'),
('Mehemmed','Huseynli','mehemmed@gmail.com','0607568754','2020-10-10','Desighner',1000,'UI')
delete Employees where Salary<1500

Select * from Employees where FirstName like '%a%'
select * from Employees where Salary between 2000 and 2500
select * from Employees where Department in ('IT','UI') -- tablede maliyye departamenti olmadigina gore ui yazdim
