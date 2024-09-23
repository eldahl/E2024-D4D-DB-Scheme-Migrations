use master
go

IF DB_ID('ActivityDB') IS NOT NULL    
BEGIN
	DROP DATABASE ActivityDB			
END

CREATE DATABASE ActivityDB
GO

USE ActivityDB	
GO

create table Activity
(
	id int not null IDENTITY(1, 1),
	nameActivity varchar(25) not null,
	activityDescription varchar(200) not null,
	constraint PK_Activity Primary key (id)
	
)

create table ActivityDuration
(
	id int not null IDENTITY(1, 1),
	activityId int not null,
	startTime datetime not null,
	durationTime time,
	constraint PK_ActivityDuration primary key (id)
)

create table ActivityCategory
(
	catName varchar(100) not null,
	constraint PK_ActivityCategory primary key (catName)
)