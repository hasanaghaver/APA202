Create database Company

use Company

Create table Countries(
Id int primary key identity,
Name nvarchar(30) unique not null
)

Create table Cities(
Id int primary key identity,
Name nvarchar(50) unique not null,
CountryId int foreign key references Countries(Id)
)


 Create table Employees(
 Id int primary key identity,
 Name nvarchar(30) not null,
 Surname nvarchar(50),
 Age int not null,
 Salary decimal(6,2),
 Position nvarchar(30),
 IsDeleted bit default 0,
 CityId int foreign key references Cities(Id)
 )

 INSERT INTO Countries (Name)
 VALUES  ('Azerbaijan'),
('Turkey'),
('USA'),
('Russia')

INSERT INTO Cities (Name, CountryId) VALUES 
('Baku', 1),     
('Sumqayit', 1),  
('Istanbul', 2), 
('Ankara', 2),   
('New York', 3), 
('Moscowa', 4),
('Peterburq',4)

INSERT INTO Employees (Name, Surname, Age, Salary, Position, IsDeleted, CityId) 
VALUES 
('Huseyn', 'Rzayev', 22, 2500.50, 'Developer', 0, 1),      
('Ali', 'Memmedov', 28, 1800.00, 'Reception', 0, 1),      
('Aysel', 'Qurbanova', 25, 2100.00, 'Reception', 0, 2), 
('Murat', 'Yilmaz', 30, 2200.00, 'Manager', 0, 3),        
('Emre', 'Can', 27, 1950.00, 'Reception', 1, 4),        
('John', 'Smith', 35, 4500.00, 'Architect', 0, 5),       
('Ivan', 'Petrov', 40, 3200.00, 'Analyst', 1, 6),        
('Svetlana', 'Ivanova', 29, 2300.00, 'Reception', 0, 7);   

--Ishcilerin ozlerini, yashadiqi sheherlerini ve olkelerini gosterin.
Select e.Name,e.Surname,e.Age,e.Salary,e.Position,co.Name as [Country],ct.Name as [City] from Employees as e
join Cities  as ct on CityId= ct.Id
join Countries as co on ct.CountryId = co.Id

 --Maashi 2000-den yuxari olan ishcilerin adlari ve yashadiqi olkeleri gosterin.
Select e.Name,e.Surname,e.Age,e.Salary,e.Position,co.Name as [Country],ct.Name as [City] from Employees as e
join Cities  as ct on CityId= ct.Id
join Countries as co on ct.CountryId = co.Id
where e.Salary >2000

--  Hansi sheherin hansi olkeye aid olduqunu gosterin.
Select ci.Name as [City],co.Name as [Country] from Cities as ci
join Countries as co on CountryId= co.Id

--Positioni "Reseption" olan ishcilerin table-larin id-leri daxil olmamaq sherti ile daxil olmamaq sherti ile butun melumatlarini gostermek.
Select e.Name,e.Surname,e.Age,e.Salary,e.Position,co.Name as [Country],ct.Name as [City] from Employees as e
join Cities  as ct on CityId= ct.Id
join Countries as co on ct.CountryId = co.Id
Where e.Position = 'Reception'

 --ishden cixan ishcilerin yashadiqi sheher ve olkeleri, hemcinin ishcilerin oz ad ve soyadlarini gosteren query yazin.
Select e.Name,e.Surname,co.Name as [Country],ct.Name as [City] from Employees as e
join Cities  as ct on CityId= ct.Id
join Countries as co on ct.CountryId = co.Id
Where e.IsDeleted = 1