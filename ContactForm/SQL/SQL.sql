create database ContactForm
go

go
create table Contact(
	IDForm int IDENTITY(1,1) NOT NULL, 
    FirstName nvarchar(50),
    LastName nvarchar(50),
    Email nvarchar(50),
	FormQuestion nvarchar(200),
	FormAnswer nvarchar(200)

)



go
create procedure insertContactForm
	@IDForm int output,
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Email nvarchar(50),
	@fromQuestion nvarchar(200),
	@fromAnswer nvarchar(200)
AS
BEGIN
	insert into Contact 
		(
		FirstName,
		LastName,
		Email,
		FormQuestion
		) 
	
	values
		(
		@Name,
		@Surname,
		@Email,
		@FromQuestion
		)
	set @IDForm = SCOPE_IDENTITY()
END
go




create PROC updateContactForm
	@IDForm int,
	@Name nvarchar(50),
	@Surname nvarchar(50),
	@Email nvarchar(50),
	@fromQuestion nvarchar(200),
	@fromAnswer nvarchar(200)
AS
UPDATE Contact 
SET FirstName = @Name, LastName = @Surname, Email = @Email, FormQuestion = @fromQuestion, FormAnswer = @fromAnswer
WHERE IDForm = @IDForm
GO

CREATE PROC GetContact
	@IDForm int
AS
SELECT * FROM Contact WHERE IDForm = @IDForm
GO

create PROCEDURE GetAllContacts
AS
BEGIN
	select * from Contact
END
GO


--
insert into Contact(FirstName,LastName,Email,FormQuestion) values('Pero','peric','pero@gmail.com','My message to admin')
insert into Contact(FirstName,LastName,Email,FormQuestion) values('Ana','Anic','ana@gmail.com','My message to admin')
insert into Contact(FirstName,LastName,Email,FormQuestion) values('Miro','Miric','miro@gmail.com','My message to admin')
insert into Contact(FirstName,LastName,Email,FormQuestion) values('Damir','Danic','damir@gmail.com','My message to admin')
insert into Contact(FirstName,LastName,Email,FormQuestion) values('Zvonko','Zvonic','Zvonko@gmail.com','My message to admin')






drop table Contact
