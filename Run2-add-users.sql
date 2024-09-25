-- Use database
use ActivityDB
go

-- Create table
create table Users
(
	id int not null IDENTITY(1, 1),
	userName varchar(50) not null,
	email varchar(100) not null,
	constraint PK_Users primary key (id)
)