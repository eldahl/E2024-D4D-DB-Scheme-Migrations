use ActivityDB
go

create table Users
(
	id int not null,
	userName varchar(50) not null,
	email varchar(100) not null,
	constraint PK_Users primary key (id)
)