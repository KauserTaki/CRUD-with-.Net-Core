use crud_m_table

create table tblDepartment(

	ID int primary key,
	DepartmentName nvarchar(50),
	Location nvarchar(50),
	DepartmentHead nvarchar(50)
)

insert into tblDepartment values(1, 'CSE', 'Dhanmondi', 'Alfred')
insert into tblDepartment values(1, 'ECE', 'Dhanmondi', 'Thomas')
insert into tblDepartment values(1, 'BBA', 'Dhanmondi', 'David')


create table tblStudent(
	
	ID int primary key,
	Name nvarchar(50),
	Gender nvarchar(50),
	Age int,
	Department_Name int foreign key references tblDepartment(ID)
)

insert into tblStudent values(1, 'Kauser', 'Male', 27, 1)
