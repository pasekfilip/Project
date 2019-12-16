use master
go

if exists(select * from sys.databases where name = 'FilipsDb')
begin
drop database FilipsDb
end
go

create database FilipsDb
go
use FilipsDb
go

if exists(select * from sys.tables where name ='Users')
drop table Users
go
create table Users
(
	id int identity(1,1),
	UserName nvarchar(20),
	Email nvarchar(20),
	primary key(id)
)
if exists(select * from sys.tables where name ='Friends')
drop table Friends
go
create table Friends
(
	id_User int,
	id_Friend int,
	created_date date
	foreign key(id_User) references Users(id),
	foreign key(id_Friend) references Users(id)
)
if exists(select * from sys.tables where name ='Chats')
drop table Chats
go
create table Chats
(
	id int identity(1,1),
	id_Admin int
	primary key(id)
)
if exists(select * from sys.tables where name ='Chat_Members')
drop table Chat_Members
go
create table Chat_Members
(
	id_User int,
	id_Chat int,
)
if exists(select * from sys.tables where name ='Messages')
drop table Messages
go
create table Messages 
(
	id int identity(1,1),
	id_User int,
	Message nvarchar(1000),
	id_Chat int 
	primary key(id),
	foreign key(id_User) references Users(id),
	foreign key(id_Chat) references Chats(id)
)
if exists(select * from sys.tables where name ='Filee')
drop table Filee
go
create table Filee
(
	id_Message int,
	filee nvarchar(255)
	foreign key(id_Message) references Messages(id)
)




alter table Chat_Members add foreign key(id_User) references Users(id)
alter table Chat_Members add foreign key(id_Chat) references Chats(id)
alter table Chats add foreign key(id_Admin) references Users(id)


insert into Users (UserName,Email) values('Filip','Filip@dsss.cz'),('Dan','Dan@dsss.cz'),('Tom','Tom@dsss.cz')
insert into Friends (id_User,id_Friend) values(1,2),(1,3),(2,1),(3,1)
insert into Chats (id_Admin) values(1),(2)
insert into Chat_Members(id_User,id_chat) values(1,1),(1,2),(2,1)
insert into Messages (id_User,id_Chat,Message) values(1,1,'èus bois'),(1,2,'ahoj druhý chate'),(1,1,'ahoj znovu do prvního chatu')
insert into Filee(id_Message,filee) values(1,'C:\Users\something'),(1,'C:\Users\coolstuff')

delete from Chats
select * from Friends
select * from Users
select * from Chats
select * from Chat_Members
select * from Filee

select * from Users u
inner join Friends f on u.id = f.id_User  

select * from Chats ch 
inner join Chat_Members chm on ch.id = chm.id_Chat

select * from Messages me
inner join Users u on me.id_User = u.id
inner join Chats ch on me.id_Chat = ch.id


select id_User,id_Chat,id_message,filee from Messages me
inner join Filee f on me.id = f.id_Message
group by id_User,id_Chat,id_message,filee