create database Library1
go 
use Library1
go
create table Countries
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(max) not null check(Name <> ''),
	AuthorId int foreign key references Authors(Id)
)
go 
create table Authors
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(100) not null check(Name <> ''),
	Surname nvarchar(100) not null check(Surname <> ''),
	BookId int foreign key references Books(Id)
)
go
create table Books
(
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name nvarchar(max) not null check(Name <> ''),
	Pages int NOT NULL check(Pages > 10) default(15)
)


