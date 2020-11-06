
ALTER PROCEDURE dbo.AddressBookHandilng 
(
@first_name varchar(30),
@last_name varchar(30),
@address varchar(30),
@city varchar(20),
@state varchar(20),
@zip int,
@phone float,
@emailid varchar(30)
)
AS
BEGIN

	SET NOCOUNT ON;
update dbo.Address_Model set city='Tezpur' where first_name ='Jatin'
END
GO
