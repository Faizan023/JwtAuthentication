create database Authentication;
use Authentication; 

create table Users(
Id Int Identity(1,1) not null,
Name Varchar(20) not null,
Email varchar(50) not null,
Password varchar(15) not null,
Phone int not null,

constraint Pk_Id Primary key  (Id)
);

insert into Users (Name, Email, Password, Phone) values ('Faizan', 'mansurifaizan315@gmail.com', '123@@45%&8', 1234567890);

insert into Users (Name, Email, Password, Phone) values ('Afzal', 'mansuriafzal315@gmail.com', '123%%&*9', 1234567890);

insert into Users (Name, Email, Password, Phone) values ('Nam3', 'name3@gmail.com', '901##564', 1234567890);
 
 Select * from Users

 