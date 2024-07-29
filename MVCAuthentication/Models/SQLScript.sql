
Create database MvcAuthenticationDb
 use MvcAuthenticationDb

 create table users	 (
 ID int primary key identity,
 Email varchar(100) not null,
 Password varchar(40) not null,
 IsActive bit,
 CreatedDate datetime2
 
 )
 go 
 create table Roles(
  RoleId int primary key identity,
 RoleName varchar(50),
 )
 go
 create table UserRoles(
 UserRoleId int primary key identity,
 UserID int foreign key references users( ID),
 RoleID int foreign key references Roles(RoleId)

 )
 go 
 create table Product(
 ProductId int primary key identity,
 Name varchar(50),
 price int ,
 AddedDate datetime2
 
 ) 
 insert into Roles values('Admin'),('Seller'),('User')

















